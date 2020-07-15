using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALLibrary
{
    class Functions
    {
        public int FunctionID { get; set; }
        public string FunctionName { get; set; }

        public Functions(int FunctionID, string FunctionName)
        {
            this.FunctionID = FunctionID;
            this.FunctionName = FunctionName;
        }
    }
}
