USE [KTjune23]
GO

/****** Object: SqlProcedure [dbo].[InsertCustomer] Script Date: 6/29/2023 10:09:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].InsertCustomer
	@CustID int,
	@Name varchar(50),
	@Address varchar(50),
	@Email varchar(50),
	@Mobile varchar(15)
AS
	Insert into Customers values(@CustID,@Name,@Address,@Email,@Mobile);

RETURN 0
