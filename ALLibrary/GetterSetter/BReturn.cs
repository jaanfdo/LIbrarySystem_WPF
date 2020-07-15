using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALLibrary
{
    class BReturn
    {
        //string LateEarly;
        //int BRID, MNo, NofRB, Dates, BNo, NoRCopies;
        //DateTime IssueDate, DueDate, LateEarly;
        //Double Fines;

        public int BRID { get; set; }
        public int MNo { get; set; }
        public int NofRB { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string LateEarly { get; set; }
        public int Dates { get; set; }
        public decimal Fines { get; set; }
        public int BNo { get; set; }
        public int NoRCopies { get; set; }
        public decimal TotalFines { get; set; }

        public BReturn(int BRID, int MNo, int NofRB, DateTime ReturnDate, decimal TotalFines)
        {
            this.BRID = BRID;
            this.MNo = MNo;
            this.NofRB = NofRB;
            this.ReturnDate = ReturnDate;
            this.TotalFines = TotalFines;
        }

        public BReturn(int BRID, int NofRB, DateTime ReturnDate, decimal TotalFines)
        {
            this.BRID = BRID;
            this.NofRB = NofRB;
            this.ReturnDate = ReturnDate;
            this.TotalFines = TotalFines;
        }

        public BReturn(int BRID)
        {
            this.BRID = BRID;
        }

        public BReturn(int BRID, int BNo, int NoRCopies, DateTime IssueDate, DateTime DueDate, string LateEarly, int Dates, decimal Fines)
        {
            this.BRID = BRID;
            this.BNo = BNo;
            this.NoRCopies = NoRCopies;
            this.IssueDate = IssueDate;
            this.DueDate = DueDate;
            this.LateEarly = LateEarly;
            this.Dates = Dates;
            this.Fines = Fines;
        }

        public BReturn()
        {

        }
        

    }
}
