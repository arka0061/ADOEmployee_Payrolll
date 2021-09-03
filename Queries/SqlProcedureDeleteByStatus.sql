Create or Alter procedure spDeleteEmployeeByStatus
(	
	@ActiveCheck bit
)
As
Begin Try
Delete from  
employee_payroll 
where  ActiveCheck=@ActiveCheck

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