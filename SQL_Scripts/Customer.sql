
-- create table script
USE [KTjune23]
GO

/****** Object: Table [dbo].[Customers] Script Date: 6/29/2023 10:07:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers] (
    [CustID]  INT          NOT NULL,
    [Name]    VARCHAR (50) NOT NULL,
    [Address] VARCHAR (50) NOT NULL,
    [Email]   VARCHAR (50) NOT NULL,
    [Mobile]  VARCHAR (15) NOT NULL
);

