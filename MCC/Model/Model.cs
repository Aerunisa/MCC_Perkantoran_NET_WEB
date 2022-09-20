using System;
using System.Collections.Generic;
using System.Text;

namespace MCC.Model
{
    public class Pegawai
    {
        public int IDPegawai { get; set; }
        public string PegawaiName { get; set; }
        public int DeptID { get; set; }
        public int PositionID { get; set; }
        public string PegPhoneNum { get; set; }
        public string PegAddres { get; set; }
        public string EmailPegawai { get; set; }
        public int Salary { get; set; }

    }
    public class Salary
    {
        public int SalaryID  { get; set; }
        public int SalaryAmount  { get; set; }
        public int PositionID { get; set; }
    }
}
