CREATE TABLE [dbo].[Post] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [state]       VARCHAR (50)  NULL,
    [datePublish] DATETIME      NULL,
    [body]        VARCHAR (500) NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED ([id] ASC)
);

