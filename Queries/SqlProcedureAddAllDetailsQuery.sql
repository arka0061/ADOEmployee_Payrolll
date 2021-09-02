Create or Alter procedure spAddAllEmployeeDetails
(
	@Name varchar(20),
	@StartDate varchar(20),
	@Gender char(1),
	@EmployeeDepartment varchar(20),
	@EmployeePhoneNumber bigint,
	@BasicPay float,
	@Deduction float,
	@TaxablePay float,
	@IncomeTax float,
	@NetPay float
)
As
Begin Try
Insert into employee_payroll Values (@Name,@StartDate,@Gender,@EmployeeDepartment,@EmployeePhoneNumber,@BasicPay,@Deduction,@TaxablePay,@IncomeTax,@NetPay);
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH   