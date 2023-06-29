USE [KTjune23]
GO

/****** Object: SqlProcedure [dbo].[DeleteCustomer] Script Date: 6/29/2023 10:10:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].DeleteCustomer
	@CustID int
AS
	if exists (select * from Customers where  CustID = @CustID)
	begin 
		delete from Customers 
		where CustID = @CustID;
	end
RETURN 0
