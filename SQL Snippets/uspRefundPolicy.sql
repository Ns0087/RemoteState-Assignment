USE [AssignmentDB]
GO
/****** Object:  StoredProcedure [dbo].[uspUserDetails]    Script Date: 09-03-2023 11:36:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[uspUserDetails] 'A121', 'DS1'
@PolicyNumber varchar(100),
@ProductCode varchar(20)
as
BEGIN
INSERT INTO [AssignmentDB].[dbo].[tblRefundPolicy] 
	   ([PolicyNumber]
      ,[TemplateCode]
      ,[ChannelCode]
      ,[Destination]
      ,[Subject]
      ,[Body]
      ,[CreatedUserId])

SELECT @PolicyNumber as PolicyNumber, 
t.DocumentCode  as TemplateCode, 
'Email' as ChannelCode, 
u.emailAddress as Destination, 
'Your Policy info ' + @PolicyNumber as Subject,
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(t.Content,
'{{Name}}', u.Name),
'{{PolicyNumber}}', @PolicyNumber),
'{{Age}}', u.Age),
'{{Salary}}', u.Salary),
'{{Occupation}}', u.Occupation),
'{{ProductCode}}', @ProductCode),
'{{PolicyExpiryDate}}', u.PolicyExpiryDate) as Body,
u.Name as CreatedUserId
FROM [AssignmentDB].[dbo].[tblHtmlTemplate] as t
JOIN [AssignmentDB].[dbo].[tblUser] as u ON t.createdUser = u.id 
where u.PolicyNumber = @PolicyNumber AND u.ProductCode = @ProductCode AND u.emailAddress LIKE '%_@__%.__%';

--Declare @Body VARCHAR(MAX)
Select * from [AssignmentDB].[dbo].[tblRefundPolicy];

END

