CREATE TABLE [dbo].[User] (
    [id]             INT          IDENTITY (1, 1) NOT NULL,
    [user_login]     VARCHAR (50) NULL,
    [password_login] VARCHAR (50) NULL,
    [isEditor]       BIT          NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([id] ASC)
);

