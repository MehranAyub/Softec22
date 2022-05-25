CREATE TABLE [dbo].[TimeSlot] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [DoctorId]      INT           NULL,
    [Date]          DATETIME2 (7) NULL,
    [AppointmentId] INT           NULL,
    [TimeSlots]     INT           DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TimeSlot] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TimeSlot_Appointment_AppointmentId] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointment] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSlot_AppointmentId]
    ON [dbo].[TimeSlot]([AppointmentId] ASC);

