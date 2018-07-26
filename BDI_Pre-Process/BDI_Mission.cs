//BDI_Mission
//Jeremy Snyder
//06/18/2018
//Class holds data for all BDI missions being loaded in current job.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDI_Pre_Process
{
    class BDI_Mission
    {
        public string Zip { get; set; }
        public string Mission
        {
            get { return GetMission(); }
            set { Mission = value; }
        }
        public string Folder
        {
            get { return GetFolder(); }
            set { Folder = value; }
        }

        public bool Unzipped { get; set; }//set to true when unzipped
        public bool Cleaned { get; set; }//set to true when files are cleaned or uniqued
        public bool Processing { get; set; }//set to true when files sent to BDI processing
        public bool Fail { get; set; }//set to true if part of process encounters an error
        public int Result { get; set; }//set to 1 if BDI processing completes, or 2 if it fails

        public string GetMission()
        {

            int Start = Zip.LastIndexOf('\\') + 1;
            string strMission = Zip.Substring(Start, Zip.Length - Start);
            strMission = strMission.Substring(0, strMission.IndexOf(" "));
            return strMission;
        }

        public string GetFolder()
        {

            string strFolder = Zip.Replace("ORIG DATA", Mission);
            strFolder = strFolder.Substring(0, strFolder.LastIndexOf('\\'));
            return strFolder;
        }
    }
}
