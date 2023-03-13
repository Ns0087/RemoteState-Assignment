USE [AssignmentDB]
GO

/****** Object:  StoredProcedure [dbo].[uspUserDetails]    Script Date: 09-03-2023 11:23:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[uspHtmlTemplate]
@CreatedUser varchar(50)
as
BEGIN
	SELECT TOP (1000) [Id]
      ,[DocumentCode]
      ,[Filename]
      ,[ContentType]
      ,[Content]
      ,[ContentBinary]
      ,[IsDeleted]
      ,[CreatedUser]
      ,[CreatedDateTime]
      ,[ModifiedUser]
      ,[ModifiedDateTime]
  FROM [AssignmentDB].[dbo].[tblHtmlTemplate]
  where CreatedUser = @CreatedUser
END
GO


