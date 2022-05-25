CREATE TABLE [dbo].[DoctorSpecialist] (
    [ID]           INT IDENTITY (1, 1) NOT NULL,
    [SpecialistId] INT NULL,
    [BarberId]     INT NULL,
    CONSTRAINT [PK_DoctorSpecialist] PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([BarberId]) REFERENCES [dbo].[Users] ([ID]),
    CONSTRAINT [FK_DoctorSpecialist_Specialist_SpecialistId] FOREIGN KEY ([SpecialistId]) REFERENCES [dbo].[Specialist] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_DoctorSpecialist_SpecialistId]
    ON [dbo].[DoctorSpecialist]([SpecialistId] ASC);

