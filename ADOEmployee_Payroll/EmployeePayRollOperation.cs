using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADOEmployee_Payroll
{
    public class EmployeePayRollOperation
    {
        public int choice;
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayroll";
        public static List<Employee> EmpList = new List<Employee>();
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public List<Employee> GetAllEmployeeDetails()
        {
            SqlCommand com = new SqlCommand("spGetAllEmployeeDetails", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            da.Fill(dt);
            sqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(

                    new Employee
                    {
                        ID = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        StartDate = Convert.ToString(dr["StartDate"]),
                        Gender = Convert.ToChar(dr["Gender"]),
                        EmployeeDepartment = Convert.ToString(dr["EmployeeDepartment"]),
                        EmployeePhoneNumber = Convert.ToDouble(dr["EmployeePhoneNumber"]),
                        BasicPay = Convert.ToDouble(dr["BasicPay"]),
                        Deduction = Convert.ToDouble(dr["Deduction"]),
                        TaxabalePay = Convert.ToDouble(dr["TaxablePay"]),
                        IncomeTax = Convert.ToDouble(dr["IncomeTax"]),
                        NetPay = Convert.ToInt32(dr["NetPay"]),
                    });
            }
            return EmpList;
        }
        public void Display()
        {
            foreach (var item in EmpList)
            {
                Console.WriteLine("ID is : " + item.ID);
                Console.WriteLine("Name is : " + item.Name);
                Console.WriteLine("StartDate is : " + item.StartDate);
                Console.WriteLine("Gender is : " + item.Gender);
                Console.WriteLine("EmployeeDepartment is : " + item.EmployeeDepartment);
                Console.WriteLine("EmployeePhoneNumber is : " + item.EmployeePhoneNumber);
                Console.WriteLine("BasicPay is : " + item.BasicPay);
                Console.WriteLine("Deduction is : " + item.Deduction);
                Console.WriteLine("TaxablePay is : " + item.TaxabalePay);
                Console.WriteLine("IncomeTax is : " + item.IncomeTax);
                Console.WriteLine("NetPay is : " + item.NetPay);
                Console.WriteLine("----------End of Record of an Employee---------------------");
            }
        }

    }
}


