CREATE TABLE [dbo].[University] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_University] PRIMARY KEY CLUSTERED ([ID] ASC)
);

