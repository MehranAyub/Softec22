CREATE TABLE [dbo].[Files] (
    [DocumentId] INT             IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (100)   NULL,
    [FileType]   VARCHAR (100)   NULL,
    [DataFiles]  VARBINARY (MAX) NULL,
    [CreatedOn]  DATETIME        NULL,
    [UserId]     INT             NULL,
    CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED ([DocumentId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([ID])
);

