﻿CREATE TABLE [dbo].[TODO_MIRROR] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [NAME]        NVARCHAR (50)  NULL,
    [DESCRIPTION] NVARCHAR (500) NULL,
    CONSTRAINT [PK_dbo.TODO_MIRROR] PRIMARY KEY CLUSTERED ([ID] ASC)
);
