using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALLibrary
{
    class BBooks
    {
        //DateTime IssueDate;
        //DateTime DueDate;
        //private int BBID;
        //private int MNo;
        //private int NofBB;
        //private int BNo;
        //private int NoCopies;

        public int BBID { get; set; }
        public int MNo { get; set; }
        public int NofBB { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public int BNo { get; set; }
        public int NoCopies { get; set; }
        public bool Status { get; set; }

        public BBooks(int _BBID, int _MNo,int _NofBB, DateTime _IssueDate, DateTime _DueDate)
        {
            this.BBID = _BBID;
            this.MNo = _MNo;
            this.NofBB = _NofBB;
            this.IssueDate = _IssueDate;
            this.DueDate = _DueDate;
        }

        public BBooks(int _BBID, int _BNo, int _NoCopies, bool _Status)
        {
            this.BBID = _BBID;
            this.BNo = _BNo;
            this.NoCopies = _NoCopies;
            this.Status = _Status;
        }

        public BBooks(int _BBID, int _BNo, int _NoCopies)
        {
            this.BBID = _BBID;
            this.BNo = _BNo;
            this.NoCopies = _NoCopies;
        }

        public BBooks(int _BBID)
        {
            this.BBID = _BBID;
        }

        public BBooks(int _BBID, int _NofBB, DateTime _DueDate)
        {
            this.BBID = _BBID;
            this.NofBB = _NofBB;
            this.DueDate = _DueDate;
        }

        public BBooks()
        {

        }
        
    }
}
