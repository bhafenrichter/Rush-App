CREATE TABLE [dbo].[User] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [UniversityID] INT           NOT NULL,
    [FirstName]    NVARCHAR (50) NULL,
    [lastName]     NVARCHAR (50) NULL,
    [Major]        NVARCHAR (50) NULL,
    [GPA]          FLOAT (53)    NULL,
    [Hometown]     NVARCHAR (50) NULL,
    [HomeState]    NVARCHAR (2)  NULL,
    [GreekID]      INT           NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_User_House] FOREIGN KEY ([GreekID]) REFERENCES [dbo].[House] ([ID]),
    CONSTRAINT [FK_User_University] FOREIGN KEY ([UniversityID]) REFERENCES [dbo].[University] ([ID])
);

