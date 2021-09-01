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
       
    }
}


