using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALLibrary
{
    class BReserve
    {

        
        public int BResID { get; set; }
        public string ResName { get; set; }
        public int ResTpNo { get; set; }
        public DateTime ResDateTime { get; set; }
        public DateTime ResEDateTime { get; set; }
        public int NofBB { get; set; }
        public int BNo { get; set; }
        public int NoCopies { get; set; }

        public BReserve(int BResID, string ResName, int ResTpNo, DateTime ResDateTime, DateTime ResEDateTime, int NofBB)
        {
            this.BResID = BResID;
            this.ResName = ResName;
            this.ResTpNo = ResTpNo;
            this.ResDateTime = ResDateTime;
            this.ResEDateTime = ResEDateTime;
            this.NofBB = NofBB; 
        }

        public BReserve(int BResID, DateTime ResDateTime, DateTime ResEDateTime, int NofBB)
        {
            this.BResID = BResID;
            this.ResDateTime = ResDateTime;
            this.ResEDateTime = ResEDateTime;
            this.NofBB = NofBB; 
        }

        public BReserve(int BResID)
        {
            this.BResID = BResID;
        }
        public BReserve(int BResID, int BNo, int NoCopies)
        {
            this.BResID = BResID;
            this.BNo = BNo;
            this.NoCopies = NoCopies;
        }

        public BReserve()
        {

        }
    }
}
