IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE TABLE [Categories] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(30) NOT NULL,
        [Description] nvarchar(500) NULL,
        [UrlHandle] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE TABLE [Roles] (
        [Id] uniqueidentifier NOT NULL,
        [RoleName] nvarchar(20) NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
        [Email] nvarchar(200) NOT NULL,
        [Password] nvarchar(200) NOT NULL,
        [FirstName] nvarchar(30) NOT NULL,
        [LastName] nvarchar(30) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE TABLE [BlogPosts] (
        [Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(200) NOT NULL,
        [ShortDescription] nvarchar(500) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [FeaturedImageUrl] nvarchar(max) NOT NULL,
        [UrlHandle] nvarchar(200) NOT NULL,
        [PublishedDate] datetime2 NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        [IsVisbile] bit NOT NULL,
        CONSTRAINT [PK_BlogPosts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BlogPosts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE TABLE [BlogPostCategory] (
        [BlogPostsId] uniqueidentifier NOT NULL,
        [CategoriesId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_BlogPostCategory] PRIMARY KEY ([BlogPostsId], [CategoriesId]),
        CONSTRAINT [FK_BlogPostCategory_BlogPosts_BlogPostsId] FOREIGN KEY ([BlogPostsId]) REFERENCES [BlogPosts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BlogPostCategory_Categories_CategoriesId] FOREIGN KEY ([CategoriesId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE TABLE [PostImages] (
        [ImageId] uniqueidentifier NOT NULL,
        [PostId] uniqueidentifier NOT NULL,
        [ImageUrl] nvarchar(500) NOT NULL,
        [UploadedOn] datetimeoffset NOT NULL,
        CONSTRAINT [PK_PostImages] PRIMARY KEY ([ImageId]),
        CONSTRAINT [FK_PostImages_BlogPosts_PostId] FOREIGN KEY ([PostId]) REFERENCES [BlogPosts] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE INDEX [IX_BlogPostCategory_CategoriesId] ON [BlogPostCategory] ([CategoriesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE INDEX [IX_BlogPosts_UserId] ON [BlogPosts] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE INDEX [IX_PostImages_PostId] ON [PostImages] ([PostId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    CREATE INDEX [IX_Users_RoleId] ON [Users] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250817122835_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250817122835_InitialMigration', N'7.0.20');
END;
GO

COMMIT;
GO

