using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALLibrary
{
    class BRegistration
    {
        //string BName, Language, Author, PublisherName;
        //DateTime PublicationDate, BPurchasingDate;
        //int CategoryID, BNo, ISBN, Edition, NoCopies, BillNo;
        //double Price;
        //bool Status;

        public int CategoryID { get; set; }
        public int BNo { get; set; }
        public string BName { get; set; }
        public int Language { get; set; }
        public int ISBN { get; set; }
        public int Author { get; set; }
        public int PublisherName { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Edition { get; set; }
        public int NoCopies { get; set; }
        public int BillNo { get; set; }
        public DateTime BPurchasingDate { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public BRegistration()
        {

        }

        public BRegistration(int BNo)
        {
            this.BNo = BNo;
        }

        public BRegistration(int CategoryID, int BNo, string BName, int Language, int ISBN, int Author, int PublisherName, DateTime PublicationDate, int Edition, int NoCopies, DateTime BPurchasingDate, int BillNo, decimal Price, bool Status)
        {
            // TODO: Complete member initialization
            this.CategoryID = CategoryID;
            this.BNo = BNo;
            this.BName = BName;
            this.Language = Language;
            this.ISBN = ISBN;
            this.Author = Author;
            this.PublisherName = PublisherName;
            this.PublicationDate = PublicationDate;
            this.Edition = Edition;
            this.NoCopies = NoCopies;
            this.BPurchasingDate = BPurchasingDate;
            this.BillNo = BillNo;
            this.Price = Price;
            this.Status = Status;
        }

        



    }
}
