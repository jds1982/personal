using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDI_Pre_Process
{
    //Original Clean class created by Mike Rowland.
    class Clean
    {
        private string cleanRecord = string.Empty;
        private string dirtyRecord = string.Empty;
        private bool status = false;


        // does the current record contain a double quote
        public bool isDirty()
        {
            return status;
        }


        // does the searching through each record looking for double quotes
        public void processRecord(String s)
        {
            dirtyRecord = s;
            cleanRecord = string.Empty;
            status = false;

            char[] recordArray = s.ToCharArray();
            
            cleanRecord = Convert.ToString(recordArray[0]); // appends the first character of the record into the cleanRecord variable

            char doubleQuote = Convert.ToChar(34);  // converting the integer value of a double quote
            char comma = Convert.ToChar(44);  // converting the integer value of a comma

            // To prevent from having an index out of bounds error we do not look at the first or last character
            for (int i = 1; i < s.Length - 1; i++)
            {
                // if the position before and after is not a comma and the current character is a double quote then it should be removed
                if (!recordArray[i - 1].Equals(comma) && recordArray[i].Equals(doubleQuote) && !recordArray[i + 1].Equals(comma))
                {
                    status = true;
                    cleanRecord += ""; // If the current character is a double quote it is replaced with a blank character
                }
           
                else // the record does not contain double quotes
                {
                    cleanRecord += recordArray[i]; // if the current character is not a double quote it appends the current character
                }
            }
            cleanRecord += recordArray[recordArray.Length - 1]; // appends the last character of the record into the cleanRecord variable
        }


        // returns the cleaned record
        public string getCleanRecord()
        {
            return cleanRecord;
        }


        // returns the record as it was prior to cleaning
        public string getDirtyRecord()
        {
            return dirtyRecord;
        }
    }
}

