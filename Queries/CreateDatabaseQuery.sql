create DataBase EmployeePayroll
use EmployeePayroll
select * from employee_payroll

Create Table employee_payroll (
Id int not null identity (1,1)primary key,
Name varchar(20),
Salary varchar(20),
StartDate varchar(20)
)

insert into employee_payroll (Name,Salary,StartDate)values ('arka','50000','2021-05-20')
insert into employee_payroll (Name,Salary,StartDate)values ('rahul','30000','2021-02-20')
insert into employee_payroll (Name,Salary,StartDate)values ('Pankaj','45000','2021-03-20')
insert into employee_payroll (Name,Salary,StartDate)values ('priyanka','60000','2021-07-20')

select * from employee_payroll

Alter table employee_payroll
add Gender char(1)

Update employee_payroll 
set Gender='M' where name='arka' or name='rahul' or name='Pankaj'
Update employee_payroll 
set Gender='F' where name='priyanka'

Alter table employee_payroll
add BasicPay float,Deduction float,TaxablePay float, IncomeTax float,NetPay float;

Update employee_payroll 
set EmployeePhoneNumber='9078563476',EmployeeDepartment='Editing',BasicPay=50000,Deduction=3000,TaxablePay=2000,IncomeTax=0,NetPay=45000
where name='arka';

Update employee_payroll 
set EmployeePhoneNumber='9045673829',EmployeeDepartment='Painting',BasicPay=60000,Deduction=3000,TaxablePay=2000,IncomeTax=0,NetPay=55000
where name='rahul';

Update employee_payroll 
set EmployeePhoneNumber='7890657890',EmployeeDepartment='Engineer',BasicPay=30000,Deduction=3000,TaxablePay=2000,IncomeTax=0,NetPay=25000
where name='Pankaj';

Update employee_payroll 
set EmployeePhoneNumber='6235467890',EmployeeDepartment='Manager',BasicPay=70000,Deduction=3000,TaxablePay=2000,IncomeTax=0,NetPay=65000
where name='priyanka';

select * from employee_payroll

