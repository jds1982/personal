using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Globalization;
using System.Configuration;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace BDI_Pre_Process
{
    /// <summary>
    /// Interaction logic for XML_Form.xaml
    /// </summary>
    public partial class XML_Form : Window
    {
        public string jobFolder;
        public string zipFile;
        
        public XML_Form()
        {
            
           InitializeComponent();
          
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; 
            this.Close();
        }

        private void btn_Continue_Click(object sender, RoutedEventArgs e)
        {
            string strMission=this.Title.Replace(" XML Builder","");
            string strXMLAppealCode = tb_XMLAppealCode.Text;
            string XMLAppealDescription = tb_XMLAppealDescription.Text;
            string str_XMLMailDate = tb_MailDate.Text;
            string str_XMLPackCost = tb_XMLPackCost.Text;
            string str_XMLPostCost = tb_XMLPostCost.Text;
            string str_XMLCleanse = "0";
            if(cb_Cleanse.IsChecked.ToString()=="True")
            {
                str_XMLCleanse= "1";
            } 
            string str_XMLStylist = "0";
            if(cb_Stylist.IsChecked.ToString()=="True")
            {
                str_XMLStylist="1";
            }
            string str_XMLDedupe = "0";
            if(cb_Dedupe.IsChecked.ToString()=="True")
            {
                str_XMLDedupe="1";
            }
            string str_XMLData = tb_DataFile.Text;
            string str_XMLActivity = tb_ActFile.Text;
            string str_XMLEligible = tb_ElFile.Text;
            string str_XMLSuppression = tb_SupFile.Text;

            //The filter is used to limit the final zip file to only files listed on the form.
            List<string> filterArray = new List<string> { str_XMLData, str_XMLActivity, str_XMLEligible, str_XMLSuppression };
            string strFilter = "\\\\" + string.Join("$;\\\\", filterArray.Where(m => !string.IsNullOrEmpty(m)).ToList());

            StringBuilder sb_XML_Segments = new StringBuilder();
            string Append;
           //Gathers information from the Datagrid and populates the stringbuilder for the segments section of the XML
            dg_Segments.UpdateLayout();
            var segments = dg_Segments.ItemsSource as System.Collections.IEnumerable;
           if (segments != null)
           {
               strFilter = strFilter + "$;\\\\";
               foreach (var seg in segments)
               {

                   var drow = dg_Segments.ItemContainerGenerator.ContainerFromItem(seg) as DataGridRow;
                   if (drow != null)
                   {
                       string strFile=((BDI_Pre_Process.Segment)(drow.Item)).FileName;
                       string strSegCode=((BDI_Pre_Process.Segment)(drow.Item)).SegmentCode;
                       string strSegName=((BDI_Pre_Process.Segment)(drow.Item)).SegmentName;
                       string strPriority=((BDI_Pre_Process.Segment)(drow.Item)).Priority.ToString();
                       Append = String.Format("<file fileName=\"{0}\" segmentCode=\"{1}\" segmentName=\"{2}\" priority=\"{3}\" />\r\n"
                           , strFile,strSegCode,strSegName,strPriority);
                       
                       sb_XML_Segments.Append(Append);
                       strFilter = strFilter + strFile + "$;\\\\";
                   }
               }
           }
           
           string XML_file = String.Format(ConfigurationManager.AppSettings["configFile"], strMission, strXMLAppealCode, XMLAppealDescription,
               str_XMLMailDate, str_XMLCleanse, str_XMLStylist, str_XMLDedupe, str_XMLData, str_XMLActivity, str_XMLSuppression,
               str_XMLEligible, sb_XML_Segments.ToString(), str_XMLPackCost, str_XMLPostCost);

           StreamWriter sw_Config = new StreamWriter(jobFolder+@"\\config.xml");
           sw_Config.WriteLine(XML_file);
           sw_Config.Close();
           sw_Config.Dispose();

           strFilter = strFilter + "config.xml$";
           MoveZipToProcess(zipFile, jobFolder, strFilter);

           this.DialogResult = true; 
           this.Close();
        }

        //private void dg_Segments_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        
        //{

        //}
        private void MoveZipToProcess(string zip, string folder,string filter)
        {

            string oldzip = System.IO.Path.GetFileName(zip);
            string newzip = System.IO.Path.Combine(folder, oldzip);
            FastZip zipper = new FastZip();
            zipper.CreateZip(newzip, folder, false, filter);

            File.Copy(newzip, System.IO.Path.Combine(@"\\IDM5\Vol2\Client\BDI_\RFM Processes\RFM Mission Load", oldzip));
        }


        //Method that allows updates to the XML data grid to be displayed
        private void dg_Segments_CellChangedValue(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (this.dg_Segments.SelectedItem != null)
            {
                (sender as DataGrid).CellEditEnding -= dg_Segments_CellChangedValue;//Stops endless loops
                (sender as DataGrid).CommitEdit();
                (sender as DataGrid).CommitEdit();//Need this second one for some reason
                (sender as DataGrid).Items.Refresh();//refreshes what you see/
            }
            else return;
            (sender as DataGrid).CellEditEnding += dg_Segments_CellChangedValue;//Set the value back so you can see more of the applied edits
        }
 
    }
}
