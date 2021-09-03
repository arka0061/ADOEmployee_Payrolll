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
            try
            {
                sqlConnection.Open();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
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
                        ActiveCheck = Convert.ToInt32(dr["ActiveCheck"])
                    }) ;
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
                Console.WriteLine("ActiveCheck is : " + item.ActiveCheck);
                Console.WriteLine("----------End of Record of an Employee---------------------");
            }
        }
        public void ADDEmployeeDetails()
        {
            try
            {
                SqlCommand com = new SqlCommand("spAddAllEmployeeDetails", sqlConnection);
                com.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                com.Parameters.AddWithValue("@Name", "Terissa");
                com.Parameters.AddWithValue("@StartDate", "2021-10-20");
                com.Parameters.AddWithValue("@Gender", 'F');
                com.Parameters.AddWithValue("@EmployeeDepartment", "Yoga");
                com.Parameters.AddWithValue("@EmployeePhoneNumber", 9845689876);
                com.Parameters.AddWithValue("@BasicPay", 67000);
                com.Parameters.AddWithValue("@Deduction", 3000);
                com.Parameters.AddWithValue("@TaxablePay", 2000);
                com.Parameters.AddWithValue("@IncomeTax", 0);
                com.Parameters.AddWithValue("@NetPay", 62000);
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    Console.WriteLine("Employee Added Sucessfully");
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Choice()
        {
            int choice = 10;
            Console.WriteLine("Enter 1 to Display DataBase");
            Console.WriteLine("Enter 2 to Add a new Employee");
            Console.WriteLine("Enter 3 to Update Employee Details");
            Console.WriteLine("Enter 4 to Delete Employee Details");
            Console.WriteLine("Enter 5 to Delete Employee Details By Status");
            Console.WriteLine("Enter 0 to Stop Execution");
            while (choice != 0)
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Display();
                        break;

                    case 2:
                        ADDEmployeeDetails();
                        break;

                    case 3:
                        UpdateEmployeeDetails();
                        break;

                    case 4:
                        DeleteEmployeeDetails();
                        break;

                    case 5:
                        CheckStatusActive();
                        break;
                }
            }
        }
        public void UpdateEmployeeDetails()
        {
            Employee emp = new Employee();
            emp.Name = "Terissa";
            emp.BasicPay = 3000000;
            try
            {
                this.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployeeDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", emp.Name);
                sqlCommand.Parameters.AddWithValue("@BasicPay", emp.BasicPay);
                int check = sqlCommand.ExecuteNonQuery();
                if (check == 1)
                {
                    Console.WriteLine("BasicPay is updated!");
                }
                else
                {
                    Console.WriteLine("BasicPay Updation Failed!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        public void DeleteEmployeeDetails()
        {
            Employee emp = new Employee();
            emp.ID = 6;
            try
            {
                this.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spDeleteEmployeeDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", emp.ID);
                int check = sqlCommand.ExecuteNonQuery();
                if (check == 1)
                {
                    Console.WriteLine("Employee is Deleted!");
                }
                else
                {
                    Console.WriteLine("Employee Deletion Failed!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        public void CheckStatusActive()
        {
            List<Employee> inactive = new List<Employee>();
            foreach (var item in EmpList)
            {
                if(item.ActiveCheck==0)
                {
                    Console.WriteLine("Employee :" + item.Name + " is inactive");
                    inactive.Add(item);
                }
            }
            Console.WriteLine("Do u want to Delete inactive Records?'Y' Or 'N'");
            char ch = Convert.ToChar(Console.ReadLine());
            if(ch.Equals('Y'))
            {
                foreach(var item in inactive)
                {
                    DeleteEmployeeDetailsByStatus(item.ActiveCheck);

                }
            }
            else
            {
                return;
            }
        }
        public void DeleteEmployeeDetailsByStatus(int status)
        {
            Employee emp = new Employee();
            emp.ActiveCheck = status;
            try
            {
                this.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spDeleteEmployeeByStatus", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ActiveCheck", emp.ActiveCheck);
                int check = sqlCommand.ExecuteNonQuery();
                if (check == 1)
                {
                    Console.WriteLine("Employee is Deleted!");
                }
                else
                {
                    Console.WriteLine("Employee Deletion Failed!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}



