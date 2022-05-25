CREATE TABLE [dbo].[Appointment] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [DoctorId]   INT            NULL,
    [PatientId]  INT            NULL,
    [Time]       VARCHAR (255)  NULL,
    [DoctorName] VARCHAR (30)   NULL,
    [UserName]   VARCHAR (30)   NULL,
    [status]     INT            NULL,
    [Location]   VARCHAR (100)  NULL,
    [phone]      VARCHAR (20)   NULL,
    [date]       VARCHAR (20)   NULL,
    [SalonName]  VARCHAR (50)   NULL,
    [SalonLogo]  NVARCHAR (MAX) NULL,
    [SalonId]    INT            NULL,
    CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED ([ID] ASC)
);

