using System;
using System.Collections.Generic;
using System.Text;

namespace ADOEmployee_Payroll
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public char Gender { get; set; }
        public string EmployeeDepartment { get; set; }
        public double EmployeePhoneNumber { get; set; }
        public double BasicPay { get; set; }
        public double Deduction { get; set; }
        public double TaxabalePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }

        public int ActiveCheck { get; set; }

    }
}
