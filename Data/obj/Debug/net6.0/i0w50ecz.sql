BEGIN TRANSACTION;
GO

CREATE TABLE [T_ArticleS] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [Author] nvarchar(max) NOT NULL,
    [CreateTime] datetime2 NOT NULL,
    [CreateUser] nvarchar(max) NOT NULL,
    [UpdateTime] datetime2 NOT NULL,
    [UpdateUser] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_T_ArticleS] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230523070500_init2', N'7.0.5');
GO

COMMIT;
GO

