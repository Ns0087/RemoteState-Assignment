USE [AssignmentDB]
GO
/****** Object:  StoredProcedure [dbo].[uspUserDetails]    Script Date: 09-03-2023 11:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[uspUserDetails] 
@PolicyNumber varchar(100),
@ProductCode varchar(20)
as
BEGIN
	SELECT [Id]
      ,[Name]
      ,[PolicyNumber]
      ,[Salary]
      ,[Occupation]
      ,[PolicyExpiryDate]
      ,[ProductCode]
      ,[emailAddress]
      ,[Age]
  FROM [AssignmentDB].[dbo].[tblUser]
  where PolicyNumber = @PolicyNumber AND ProductCode = @ProductCode
END