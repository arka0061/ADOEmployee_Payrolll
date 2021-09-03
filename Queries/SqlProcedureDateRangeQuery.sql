ALTER TABLE employee_payroll
ALTER COLUMN StartDate date;
Select * from employee_payroll
Create or Alter procedure spDateRangeEmployee
(	
	@StartDate date
)
As
Begin Try
SELECT * FROM employee_payroll 
WHERE StartDate BETWEEN CAST('2021-02-20' AS DATE ) AND '2021-05-20'
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH   

Select * from employee_payroll