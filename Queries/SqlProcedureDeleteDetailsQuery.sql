Create or Alter procedure spDeleteEmployeeDetails
(	
	@Id int	
)
As
Begin Try
Delete from  
employee_payroll 
where  Id=@Id

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