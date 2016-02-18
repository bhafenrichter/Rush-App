CREATE TABLE [dbo].[House] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [UniversityID] INT            NOT NULL,
    [Name]         NVARCHAR (50)  NULL,
    [YearFounded]  INT            NULL,
    [Description]  NVARCHAR (500) NULL,
    CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED ([ID] ASC)
);

