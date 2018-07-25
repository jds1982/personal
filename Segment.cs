
//Segment class
//Jeremy Snyder with assist from Greg Gaydos
//06/18/2018


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;

namespace BDI_Pre_Process
{
    public class Segment : INotifyPropertyChanged//Class for determining Segment information on XML form
    //Segment inherits properties from INotifyPropertyChanged so that changes to the datagrid can be applied and displayed
    {
       public string zipFile;
       private string _FileName;
       private string _SegmentCode;
       private string _SegmentName;
       private int _Priority;
       public event PropertyChangedEventHandler PropertyChanged;       

       public string FileName //{ get; set; }
       {
           get
           {
               return _FileName;
           }
           set
           {
               if (value != this._FileName)
               {
                   this._FileName = value;
                   OnPropertyChanged("_FileName");
               }
           }
       }




       public string SegmentName 
       { 
           get 
           { 
               return _SegmentName; 
           } 
           set 
           { 
               if(value != this._SegmentName)
               { 
                   this._SegmentName = value;
                   OnPropertyChanged("_SegmentName");
               }
           } 
       }

       public string SegmentCode { get { return _SegmentCode; } set { _SegmentCode = value; } }// OnPropertyChanged("_SegmentCode");


       public int Priority { get { return _Priority; } set { _Priority = value; } }//OnPropertyChanged("_Priority");
        
      public Segment(){}//Need this for new additions to the class

       public Segment(string file)
       {
           _FileName = file;
           
           if (_FileName != null)
           {
               _SegmentName = GetSegmentName();
               _SegmentCode = GetSegCode();
               _Priority = GetPriority();
           }
           else
           {
               _SegmentName = null;
               _SegmentCode = "00";
               _Priority = 0;
           }
           

       }



       public Segment(string zip, string file)
       {
           _FileName = file;
           zipFile = zip;
           if (_FileName != null)
           {
               _SegmentName = GetSegmentName();
               _SegmentCode = GetSegCode();
               _Priority = GetPriority();
           }
           else
           {
               _SegmentName = null;
               _SegmentCode = "00";
               _Priority = 0;
           }
          
       }

       public Segment(string file, string segCode, string segName, int priority)
       {
           _FileName = file;
           _SegmentName = segName;
           _SegmentCode = segCode;
           _Priority = priority;
       }



        public void Save()
        {

        }
        
     public string GetSegmentName()
      {
           string strSeg = "";

           string strZip="";
           string file = System.IO.Path.GetFileName(_FileName).ToLower();
         
           if(zipFile!=null)
            { 
               strZip = System.IO.Path.GetFileNameWithoutExtension(zipFile).ToLower().Replace("data", "");
            }
           if(strZip!="")
            { 
               file = file.Replace(strZip, "");
            }
           strSeg = file;
           strSeg = System.IO.Path.GetFileNameWithoutExtension(strSeg);
           if (strSeg.Contains("nl "))
            {
                strSeg = "newsletter only";
            }
           TextInfo ti = new CultureInfo("en-US", true).TextInfo;
           strSeg = ti.ToTitleCase(strSeg);
           return strSeg;
      }


        public int GetPriority()//Populates Priority section in datagrid
        {

            int intPriority = 0;
            
            switch (SegmentName.ToUpper())
            {
                case "MID-LEVEL":
                case "MID LEVEL":
                    intPriority = 1;
                    break;
                case "SOCIETY":
                    intPriority = 2;
                    break;
                case "MONTHLY GIVERS":
                case "MONTHLY-GIVERS":
                case "MONTHLYGIVERS":
                case "MONTHLY":
                    intPriority = 3;
                    break;
                case "NEW":
                    intPriority = 4;
                    break;
                case "REACTIVATED":
                    intPriority = 5;
                    break;
                case "BUSINESSES/ CHURCHES":
                case "BUSINESSES/CHURCHES":
                case "BUSINESSES":
                case "BUSINESS":
                case "CHURCHES":
                case "CHURCH":
                    intPriority = 6;
                    break;
                case "NEWSLETTER ONLY (NL ONLY)":
                case "NEWSLETTER ONLY":
                case "(NL ONLY)":
                case "NL ONLY":
                case "NEWSLETTER":
                case "NL":
                    intPriority = 7;
                    break;
                case "VOLUNTEERS":
                case "VOLUNTEER":
                    intPriority = 8;
                    break;
                case "BOARD/ STAFF":
                case "BOARD/STAFF":
                case "BOARD":
                case "STAFF":
                    intPriority = 9;
                    break;
                case "IN-KIND/ NON-GIVERS":
                case "IN-KIND/NON-GIVERS":
                case "IN KIND/ NON-GIVERS":
                case "IN KIND/NON-GIVERS":
                case "IN-KIND/ NON GIVERS":
                case "IN-KIND/NON GIVERS":
                case "IN KIND/ NON GIVERS":
                case "IN KIND/NON GIVERS":
                case "IN-KIND":
                case "IN KIND":
                case "INKIND":
                case "NON-GIVERS":
                case "NON GIVERS":
                case "NONGIVERS":
                    intPriority = 10;
                    break;


            }
            return intPriority;
        }

        public string GetSegCode()//Populates segment code field in datagrid
        {

            string strSegmentCode="00";

            switch (SegmentName.ToUpper())
            {
                case "MID-LEVEL":
                case "MID LEVEL":
                    strSegmentCode = "29";
                    break;
                case "SOCIETY":
                    strSegmentCode = "09";
                    break;
                case "MONTHLY GIVERS":
                case "MONTHLY-GIVERS":
                case "MONTHLYGIVERS":
                case "MONTHLY":
                    strSegmentCode = "08";
                    break;
                case "NEW":
                    strSegmentCode = "05";
                    break;
                case "REACTIVATED":
                    strSegmentCode = "06";
                    break;
                case "BUSINESSES":
                case "BUSINESS":
                    strSegmentCode = "25";
                    break;
                case "CHURCHES":
                case "CHURCH":
                    strSegmentCode = "13";
                    break;
                case "NEWSLETTER ONLY (NL ONLY)":
                case "NEWSLETTER ONLY":
                case "(NL ONLY)":
                case "NL ONLY":
                case "NEWSLETTER":
                case "NL":
                    strSegmentCode = "07";
                    break;
                case "VOLUNTEERS":
                case "VOLUNTEER":
                    strSegmentCode = "97";
                    break;
                case "BOARD/ STAFF":
                case "BOARD/STAFF":
                case "BOARD":
                case "STAFF":
                    strSegmentCode = "24";
                    break;
                case "IN-KIND/ NON-GIVERS":
                case "IN-KIND/NON-GIVERS":
                case "IN KIND/ NON-GIVERS":
                case "IN KIND/NON-GIVERS":
                case "IN-KIND/ NON GIVERS":
                case "IN-KIND/NON GIVERS":
                case "IN KIND/ NON GIVERS":
                case "IN KIND/NON GIVERS":
                case "IN-KIND":
                case "IN KIND":
                case "INKIND":
                case "NON-GIVERS":
                case "NON GIVERS":
                case "NONGIVERS":
                    strSegmentCode = "26";
                    break;


            }
            return strSegmentCode;


        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
                if(name=="_FileName")
                {
                    _SegmentName = GetSegmentName();
                    _SegmentCode = GetSegCode();
                    _Priority = GetPriority();
                }
                else if (name == "_SegmentName")
                {
                    _SegmentCode = GetSegCode();
                    _Priority = GetPriority();
                }
            }
        }
    }
    }


