CREATE TABLE [dbo].[Users] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [Email]             NVARCHAR (MAX) NULL,
    [Password]          NVARCHAR (MAX) NULL,
    [FirstName]         NVARCHAR (MAX) NULL,
    [LastName]          NVARCHAR (MAX) NULL,
    [Gender]            NVARCHAR (MAX) NULL,
    [IsEmailVerified]   BIT            NOT NULL,
    [IsActive]          BIT            NULL,
    [LoginFailureCount] INT            NOT NULL,
    [CreatedOn]         DATETIME2 (7)  NULL,
    [CreatedBy]         INT            NULL,
    [UpdatedOn]         DATETIME2 (7)  NULL,
    [UpdatedBy]         INT            NULL,
    [UserLoginTypeId]   INT            NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);



