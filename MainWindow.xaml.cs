
//BDI Pre Process
//Jeremy Snyder
//06/18/2018
//Takes BDI zip files, unzips and moves to proper folders.
//Cleans files and loads to BDI system.

//CHANGE LOG
//07/18/2018 - Added code in CleanCSV() that combines multiple data files, instead of only two.
//07/20/2018 - Moved MoveZipToProcess() to the XML_Form, and added code to create a filter for the zip file creation.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.SharpZipLib.Zip;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.ComponentModel;
//using System.Object;

//using Rebex;  //Come back to SFTP portion when the more important stuff is done.
//using Rebex.Net;
//string host= "SFTP.IDMI.COM";
//            string user = "sftpbdi";
//            string pass = "RcD3xpXH";

//            var sftp = new Rebex.Net.Sftp();

//            sftp.Connect(host);
//            sftp.Login(user,pass);

//            SftpItemCollection items = sftp.GetList();




using Microsoft.Win32;



namespace BDI_Pre_Process
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
     



    public partial class MainWindow : Window
    {
        string strPath = @"\\IDM5\VOL2\CLIENT\BDI_";
        List<BDI_Mission> BDI_Missions = new List<BDI_Mission>();

        //USED TO CONNECT TO DATABASES, PLACED HERE SO WHOLE PROGRAM CAN USE.
        SqlConnection m_cnSQLConnection = new SqlConnection();
        SqlDataAdapter m_daDataAdapter = new SqlDataAdapter();
        SqlCommandBuilder m_coCommand = new SqlCommandBuilder();
        DataTable m_dtMissionInfo = new DataTable();
        StringBuilder emailString = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();

            m_cnSQLConnection.ConnectionString = "Data Source=DPLISTENER;Database=DATAPROCESSING_GLOBAL;Integrated Security=True";
            m_cnSQLConnection.Open();
            m_daDataAdapter= new SqlDataAdapter("SELECT * FROM DATAPROCESSING_GLOBAL.[dbo].[BDI_PRE_PROCESS_MISSION_DATA]",m_cnSQLConnection);
            m_daDataAdapter.Fill(m_dtMissionInfo);
            m_cnSQLConnection.Close();
            m_cnSQLConnection.Dispose();
            JobNumPopulate(strPath);
            cb_JobNumber.Focus();

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            emailString.Append("Please review the counts of files received.\r\n \r\n");
            if(cb_JobNumber.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid job number.");
            }
            else
            {
                string strJobButton=strPath+"\\"+cb_JobNumber.SelectedValue;
                
                
                bool blFail = false;
                CheckEnteredValues(ref blFail);

                if(blFail==true)
                {
                    return;
                }

                ListLoad(strJobButton);
                FileMove(strJobButton);
                CleanDataFile();
                Email("jdsnyder@innovairre.com, dlbell@innovairre.com", "Received File Counts for " + tb_AppealDescription.Text, emailString.ToString());
                XML_Load();
                MessageBox.Show("Opening file location now.","Processing Complete");
                System.Diagnostics.Process.Start("explorer.exe", @"\\IDM5\Vol2\Client\BDI_\RFM Processes\RFM Mission Load");
                this.Close();
            }
                     
            
        }

        private void CheckEnteredValues(ref bool bl_FailCheck)
        {
            if (tb_AppealCode.Text == "")
            {
                bl_FailCheck = true;
                MessageBox.Show("Please enter a valid Appeal Code.");
                return;
            }

            if(tb_AppealDescription.Text=="")
            {
                bl_FailCheck = true;
                MessageBox.Show("Please enter a valid Appeal Description.");
                return;
            }
            if (!dp_MailDate.SelectedDate.HasValue)
            {
                bl_FailCheck = true;
                MessageBox.Show("Please enter a valid Mail Date.");
                return;
            }
        }

        private void XML_Load()//Process loads as much data as possible to XML form
        {
            foreach(var item in BDI_Missions.Where(i => i.Fail != true))
            {
                string exp = "MISSION_ID =\'" + item.Mission+"\'";
                DataRow[] result = m_dtMissionInfo.Select(exp);
                string[] files = Directory.GetFiles(item.Folder);
                List<Segment> segments = new List<Segment>(); 
                
                XML_Form frmXML = new XML_Form();
                frmXML.jobFolder = item.Folder;
                frmXML.zipFile = item.Zip;
                frmXML.Title = item.Mission + " XML Builder";
                frmXML.tb_XMLAppealCode.Text = tb_AppealCode.Text;
                frmXML.tb_XMLAppealDescription.Text = tb_AppealDescription.Text;
                frmXML.tb_MailDate.Text = dp_MailDate.SelectedDate.Value.ToShortDateString();
                frmXML.tb_XMLPackCost.Text = result[0]["PackageCost"].ToString();
                frmXML.tb_XMLPostCost.Text = result[0]["PostageCost"].ToString();
                
                if (result[0]["nameCleanse"].ToString() == "True")
                {
                    frmXML.cb_Cleanse.IsChecked = true;

                }
                if (result[0]["runStylelist"].ToString() == "True")
                {
                    frmXML.cb_Stylist.IsChecked = true;

                }
                if (result[0]["runHouseholdDedupe"].ToString() == "True")
                {
                    frmXML.cb_Dedupe.IsChecked = true;

                }
                foreach (string file in files)//Loads files to requisite text boxes, etc...
                {
                    if (((System.IO.Path.GetExtension(file).ToUpper() != ".PDF")) && ((System.IO.Path.GetExtension(file).ToUpper() != ".ZIP")) && ((System.IO.Path.GetExtension(file).ToUpper() != ".XML")))
                    { 
                        if ((file.ToUpper().Contains("DATA")) || (file.ToUpper().Contains("DONOR")))
                        {
                            frmXML.tb_DataFile.Text = System.IO.Path.GetFileName(file);
                        }
                        else if ((file.ToUpper().Contains("GIFT")) || (file.ToUpper().Contains("ACTIVITY")))
                        {
                            frmXML.tb_ActFile.Text = System.IO.Path.GetFileName(file); 
                        }
                        else if (file.ToUpper().Contains("ELIGIBLE"))
                        {
                            frmXML.tb_ElFile.Text = System.IO.Path.GetFileName(file);
                        }
                        else if ((file.ToUpper().Contains("SUPPRESS"))||(file.ToUpper().Contains("PURGE")))
                        {
                            frmXML.tb_ElFile.Text = System.IO.Path.GetFileName(file);
                        }
                        else
                        {
                            segments.Add(new Segment(item.Zip, System.IO.Path.GetFileName(file)));
                            
                        }
                    }
                }
                frmXML.dg_Segments.ItemsSource = segments;
                   
                Nullable<bool> xmlResult = frmXML.ShowDialog();//have to add more here
                //MessageBox.Show(xmlResult.ToString());
                if(xmlResult==true)
                {
                    //MoveZipToProcess(item.Zip,item.Folder);
                    item.Processing = true;
                }
            }
        }

        //Gets list of Folders in the BDI_ directory and loads them to Job Number drop down list.
        private void JobNumPopulate(string strPathPop)
        {
            string[] strFolders = Directory.GetDirectories(strPathPop);
            int x = 0;
            int y = strFolders.Length - 1;
             
                while(x<=y)
                {
                    strFolders[x] = strFolders[x].Replace(strPathPop + "\\", "");
                    cb_JobNumber.Items.Add(strFolders[x].ToString());
                    x++;
                }

        }

        //Creates a list of all zip files in the Orig Data folder and loads it to the BDI_Missions list
        private void ListLoad(string strPathLoad)
        {
            string strPathOrig = strPathLoad + "\\ORIG DATA";            
            if (!Directory.Exists(strPathOrig) == true)
            {
                MessageBox.Show("Orig Data folder not found!", "Orig Data");
                return;
            }
            else
            {
                foreach (string file in Directory.GetFiles(strPathOrig, "*.zip", SearchOption.TopDirectoryOnly))
                {
                    BDI_Missions.Add(new BDI_Mission() { Zip = file});//Load all present BDI Missions into List.
                }
            }
        }

        //Sends emails
        private void Email(string recipient,string subject,string body)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(recipient);
            message.Subject = subject;
            message.From = new System.Net.Mail.MailAddress("BDI_PRE_PROCESS@innovairre.com");
            message.Body = body;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.idmi.com");
            smtp.Send(message);
        }

        //Copies zip files from Orig Data to Mission folder and unzips them.
        private void FileMove(string strPathMove)
            {
                FastZip zipper = new FastZip();
                string strDate=DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Today.Year.ToString();
                string strPathOrigDate = strPathMove + "\\ORIG DATA\\" + strDate;
                if(!Directory.Exists(strPathOrigDate))
                {
                    Directory.CreateDirectory(strPathOrigDate);
                }

                foreach(var item in BDI_Missions)
                {
                    //int total = BDI_Missions.Count();
                    //float percent = 100/total;
                    
                    if (Directory.Exists(item.Folder) == true)
                    {
                        foreach(string file in Directory.EnumerateFiles(item.Folder))
                        {
                            File.Delete(file);
                        }
                    }
                    else if (Directory.Exists(item.Folder) == false)
                    {
                        //Create Mission folder and subfolders
                        Directory.CreateDirectory(item.Folder);
                        Directory.CreateDirectory(item.Folder + "\\DONOTUSE");
                        Directory.CreateDirectory(item.Folder + "\\IMPORT");
                        Directory.CreateDirectory(item.Folder + "\\POST");
                        Directory.CreateDirectory(item.Folder + "\\SHIP");
                    }
                    

                    try
                    {
                        File.Copy(item.Zip, item.Zip.Replace(strPathMove + "\\ORIG DATA",item.Folder).Replace(".zip","_orig.zip"),true);
                        //Window_ContentRendered();
                        zipper.ExtractZip(item.Zip, item.Folder, @"\.csv$;\.xls$;\.xlsx$;\.txt$;\.pdf$;\.mrg$");
                        item.Unzipped = true;
                        //Dispatcher.Invoke(new Action(() => { progressbar.Value = progressbar.Value + percent; }));
                    }
                    catch (Exception e)
                    {
                        item.Fail = true;
                        MessageBox.Show("Unable to extract: " + item.Zip + "\r\n" + e.ToString());
                        
                        string recipient = "jdsnyder@innovairre.com, dlbell@innovairre.com";
                        string subject = "Bad Zip";
                       
                        string body = "Unable to extract: " + item.Zip + "\r\n \r\n" + e.ToString();

                        Email(recipient, subject, body);


                    }
                    File.Copy(item.Zip, item.Zip.Replace(strPathMove + "\\ORIG DATA", strPathOrigDate),true);
                    File.Delete(item.Zip);
                    //Dispatcher.Invoke(new Action(() => { progressbar.Value = progressbar.Value + percent; }));
                   // this.InvalidateVisual();
                }
            }

        

        private void CleanDataFile()//Cleans CSV files and uniques other files
        {
            bool blFail;
            foreach(var item in BDI_Missions.Where(i => i.Fail != true))
            {
                emailString.AppendLine();
                emailString.AppendLine(item.Mission);
                    //.Append(item.Mission+"\r\n");
                int count;
                string[] files = Directory.GetFiles(item.Folder);
                blFail = false;
                foreach(string file in files)
                {
                    
                    string inFile;
                    string outFile;
                    if (System.IO.Path.GetExtension(file).ToUpper() == ".MRG")
                    {
                        inFile = file.ToUpper();
                        outFile = inFile.Replace(".MRG", ".TXT");
                        //File.Delete(inFile);
                        File.Move(inFile, outFile);
                    }

                    if ((System.IO.Path.GetExtension(file).ToUpper() == ".TXT") || (System.IO.Path.GetExtension(file).ToUpper() == ".CSV"))
                    {
                        count = File.ReadLines(file).Count();
                        emailString.AppendLine(System.IO.Path.GetFileName(file) + ": " + count.ToString());
                    }
                    if(System.IO.Path.GetExtension(file).ToUpper().Contains(".XLS"))
                    {
                        emailString.AppendLine(System.IO.Path.GetFileName(file) + ": Count will be provided");
                    }

                    if ((System.IO.Path.GetExtension(file).ToUpper() == ".CSV")) 
                    {
                        inFile = file.ToUpper();
                        outFile = inFile.Replace(".CSV", "_CLEAN.CSV");

                        if((file.ToUpper().Contains("DATA")) || (file.ToUpper().Contains("DONOR")))
                        { 
                            CleanCSV(inFile, outFile, ref blFail);
                        }
                        else
                        {
                            if(!file.ToUpper().Contains("GIFT"))
                            {
                                UniqueFile(inFile, outFile,ref blFail);
                            }
                        }



                        if (!file.ToUpper().Contains("GIFT"))
                        {
                            File.Delete(inFile);
                            if(File.Exists(outFile)==true)
                            { 
                                File.Move(outFile, file);
                            }
                        }
                        item.Cleaned = true;
                        item.Fail = blFail;
                    }
                    if(blFail==true)//breaks file loop
                    {
                        break;
                    }
                }
                
            }
            emailString.AppendLine();
            emailString.AppendLine("This is an automated message.  Please do not respond.");
        }


        //Method that removes duplicate records from the supplemental files and renames column to DONOR_ID
        public void UniqueFile(string inFile, string outFile, ref bool blFail)
        {
            StreamReader sr = new StreamReader(inFile);
            StreamWriter sw = new StreamWriter(outFile);
            

            try
            {

               while(!sr.EndOfStream)
               {
                   string readData = string.Empty;
                   string writeData = string.Empty;                   
                   readData = sr.ReadToEnd().ToString();
                   string[] inrows = readData.Split('\n');
                   int y = inrows.Length;

                   for (int x = 0; x < y; x++)
                   {
                       int i= inrows[x].IndexOf('\r');
                       if(i!=-1)
                       {
                           inrows[x] = inrows[x].Remove(i);
                       }
                   }
                   inrows[0] = "DONOR_ID";


                   string[] outrows = inrows.Distinct().ToArray();
                   foreach(string row in outrows)
                   {
                       writeData = writeData + row.ToString() + "\r\n";
                   }
                   sw.WriteLine(writeData);
               }
               sr.Close();
               sw.Close();

            }
            catch (IOException error)
            {
                
                MessageBox.Show("The file specified is currently in use. Please\n" +
                                "close the file and try again.\r\n" + error);
                blFail = true;
            }

            catch (Exception error)
            {
                
                MessageBox.Show("An error has occurred and the program needs to close.\r\n" + error);
                blFail = true;
            }

            finally
            {
                sr.Close();
                sw.Close();
                
            }
        }
        

        // This is the method that cleans csvs.
        public void CleanCSV(string inFile, string outFile, ref bool blFail)
        {
            StreamReader sr = new StreamReader(inFile);

            string str_CleanCSV_Replace_String;
            if (System.IO.Path.GetFileName(inFile).ToUpper().Contains("DONOR"))
            {
                str_CleanCSV_Replace_String = "DONOR";
            }
            else
            {
                str_CleanCSV_Replace_String = "DATA";
            }
            if ((!System.IO.Path.GetFileName(inFile).Contains(str_CleanCSV_Replace_String + ".CSV")))
            {
                string path = System.IO.Path.GetDirectoryName(inFile);
                string file = System.IO.Path.GetFileName(inFile);
                int index = file.IndexOf(str_CleanCSV_Replace_String);
                file = file.Substring(0, index) + str_CleanCSV_Replace_String + ".CSV";

                outFile = System.IO.Path.Combine(path, file); 
            }

               StreamWriter sw = new StreamWriter(outFile,append: true);
            

            try

            {
               

                // The Clean class has the logic and is doing the actual searching/cleaning for embedded quotes
                Clean c = new Clean();


                // Declare status and strings to use for reading and writing data
                bool status;
                string readData = string.Empty;
                string writeData = string.Empty;
                string header = "";

                if ((!System.IO.Path.GetFileName(inFile).Contains("1"))&&(!System.IO.Path.GetFileName(inFile).ToUpper().Contains(str_CleanCSV_Replace_String+".CSV")))//Hopefully combines data files
                {
                    header = sr.ReadLine();
                }

                while ((readData = sr.ReadLine()) != null) // While there are records to process && (readData != header)
                {
                    c.processRecord(readData);
                    status = c.isDirty();

                    if (status) // if the record sent to clean contains a double quote 
                    {
                        sw.WriteLine(c.getCleanRecord());
                     
                    }
                    else // if the record does not contain a double quote
                    {
                        sw.WriteLine(readData);
                    }
                  
                }

                // when processing has finished, close the streams. 
                //Don’t cross the streams.
                //Why?
                //It would be bad.
                //I’m fuzzy on the whole good/bad thing. What do you mean “bad”?
                //Try to imagine all life as you know it stopping instantaneously and every molecule in your body exploding at the speed of light.
                //Total protonic reversal.

                sr.Close();
                sw.Close();
                
            }

            catch (IOException error)
            {
                MessageBox.Show("The file specified is currently in use. Please " +
                                "close the "+inFile+" and try again./r/n" + error);
                blFail = true;
            }

            catch (Exception error)
            {
                MessageBox.Show("An error has occurred on file " + inFile + "and the program needs to close./r/n" + error);
                blFail = true;
            }

            finally
            {
                sr.Close();
                sw.Close();
                
            }
        }

        private void btn_Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tb_AppealCode_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_AppealCode.Text = "";
        }

        private void tb_AppealDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_AppealDescription.Text = "";
        }

        private void tb_AppealCode_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tb_AppealCode.Text=="")
            {
                tb_AppealCode.Text = "Appeal Code";
            }
        }

        private void tb_AppealDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tb_AppealDescription.Text == "")
            {
                tb_AppealDescription.Text = "Appeal Description";
            }
        }

        //private void MoveZipToProcess(string zip,string folder)
        //{
            
        //    string oldzip=System.IO.Path.GetFileName(zip);
        //    string newzip=System.IO.Path.Combine(folder,oldzip);
        //    FastZip zipper = new FastZip();
        //    zipper.CreateZip(newzip, folder,false,@"-.pdf$;-.zip$");

        //    File.Copy(newzip, System.IO.Path.Combine(@"\\IDM5\Vol2\Client\BDI_\RFM Processes\RFM Mission Load", oldzip));
        //}

        //private void Window_ContentRendered()
        //{
        //    throw new NotImplementedException();
        //}

        ////For progressbar update
        //private void Window_ContentRendered(object sender, EventArgs e)
        //{
        //    BackgroundWorker worker = new BackgroundWorker();
        //    worker.WorkerReportsProgress = true;
        //    worker.DoWork += worker_DoWork;
        //    worker.ProgressChanged += worker_ProgressChanged;
        //    worker.RunWorkerAsync();
        //}

        //void worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        (sender as BackgroundWorker).ReportProgress(i);
        //        Thread.Sleep(100);
        //    }
        //}

        //void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    progressbar.Value = e.ProgressPercentage;
        //}

          
            }

            
        }


       


