CREATE TABLE [dbo].[AvailSlots] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [BarberID] INT            NOT NULL,
    [Date]     NVARCHAR (MAX) NULL,
    [S1]       INT            NULL,
    [S2]       INT            NULL,
    [S3]       INT            NULL,
    [S4]       INT            NULL,
    [S5]       INT            NULL,
    [S6]       INT            NULL,
    [S7]       INT            NULL,
    [S8]       INT            NULL,
    CONSTRAINT [PK_AvailSlots] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AvailSlots_Users_BarberID] FOREIGN KEY ([BarberID]) REFERENCES [dbo].[Users] ([ID]) ON DELETE CASCADE
);

