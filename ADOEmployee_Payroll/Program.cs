using System;

namespace ADOEmployee_Payroll
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To ADO Employee Payroll Assignment");
            EmployeePayRollOperation emp = new EmployeePayRollOperation();
            emp.GetAllEmployeeDetails();
            emp.Choice(); 
        }
    }
}
