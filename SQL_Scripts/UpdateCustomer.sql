USE [KTjune23]
GO

/****** Object: SqlProcedure [dbo].[UpdateCustomer] Script Date: 6/29/2023 10:10:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].UpdateCustomer
	@custid int,
	@name varchar(50),
	@Address varchar(50),
	@Email varchar(50),
	@Mobile varchar(15)
AS
	if exists (select * from Customers where  CustID = @custid)
	begin 
		update Customers 
		set CustID=@custid,
		Name=@name,
		Address=@Address,
		Email=@Email,
		Mobile=@Mobile
		where CustID = @custid;
	end
RETURN 0
