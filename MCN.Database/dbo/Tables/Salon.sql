CREATE TABLE [dbo].[Salon] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [Address]      NVARCHAR (100) NULL,
    [SalonLogo]    NVARCHAR (MAX) NULL,
    [RegisterBy]   INT            NOT NULL,
    [Introduction] NVARCHAR (MAX) NULL,
    [About]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Salon] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Salon_Users_RegisterBy] FOREIGN KEY ([RegisterBy]) REFERENCES [dbo].[Users] ([ID]) ON DELETE CASCADE
);

