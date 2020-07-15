using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALLibrary
{
    class MRegistration
    {
        //private int MNo;
        //private string MName;
        //private string Address;
        //private string Gender;
        //private string NIC;
        //private int TpNo;

        public int MNo { get; set; }
        public string MName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string NIC { get; set; }
        public int TpNo { get; set; }
        public MRegistration()
        {

        }

        public MRegistration(int _MNo)
        {
            this.MNo = _MNo;
        }

        public MRegistration(int _MNo, string _MName, string _Address, string _Gender, string _NIC, int _TpNo)
        {
            this.MNo = _MNo;
            this.MName = _MName;
            this.Address = _Address;
            this.Gender = _Gender;
            this.NIC = _NIC;
            this.TpNo = _TpNo;
        }

    }
}
