CREATE TABLE [dbo].[Specialist] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Specialist] PRIMARY KEY CLUSTERED ([ID] ASC)
);

