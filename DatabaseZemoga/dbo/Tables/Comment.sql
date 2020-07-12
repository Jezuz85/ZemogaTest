CREATE TABLE [dbo].[Comment] (
    [id]      INT          IDENTITY (1, 1) NOT NULL,
    [id_post] INT          NULL,
    [body]    VARCHAR (50) NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([id] ASC)
);

