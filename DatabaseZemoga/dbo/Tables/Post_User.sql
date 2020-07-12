CREATE TABLE [dbo].[Post_User] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [id_editor]  INT NULL,
    [id_writter] INT NOT NULL,
    [id_post]    INT NOT NULL,
    CONSTRAINT [PK_Post_User] PRIMARY KEY CLUSTERED ([id] ASC)
);

