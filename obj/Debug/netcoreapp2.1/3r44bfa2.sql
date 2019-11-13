IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Contacts] (
    [ID] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [IsFamilyMember] bit NOT NULL,
    [Company] nvarchar(max) NULL,
    [JobTitle] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [MobilePhone] nvarchar(max) NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [AnniversaryDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([ID])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191108085516_init', N'2.1.11-servicing-32099');

GO

ALTER TABLE [Contacts] ADD [Password] nvarchar(max) NULL;

GO

ALTER TABLE [Contacts] ADD [Username] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191112044102_testmigration', N'2.1.11-servicing-32099');

GO

