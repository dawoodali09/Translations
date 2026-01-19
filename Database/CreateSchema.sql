-- Translations Database Schema
-- Generated from Entity Framework EDMX model
-- Target: SQL Server 2008+

-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Translations')
BEGIN
    CREATE DATABASE [Translations];
END
GO

USE [Translations];
GO

-- Create Tables

-- Translators table (must be created first as it's referenced by TranslationKeys)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Translators]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Translators] (
        [Id] BIGINT IDENTITY(1,1) NOT NULL,
        [EmailAddress] NVARCHAR(100) NOT NULL,
        [Password] NVARCHAR(50) NOT NULL,
        [FirstName] NVARCHAR(50) NOT NULL,
        [LastName] NVARCHAR(50) NOT NULL,
        [ContactNo] NVARCHAR(50) NULL,
        [Address] NVARCHAR(200) NULL,
        [Active] BIT NOT NULL DEFAULT 1,
        [MobileNumber] NVARCHAR(50) NULL,
        [PhotoURL] NVARCHAR(MAX) NULL,
        [Role] NVARCHAR(50) NULL,
        [Created] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
        [Deleted] DATETIME2(7) NULL,
        CONSTRAINT [PK_Translators] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- Countries table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Countries]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Countries] (
        [Id] BIGINT IDENTITY(1,1) NOT NULL,
        [Name] NVARCHAR(100) NOT NULL,
        [ISONumber] NVARCHAR(50) NULL,
        [ISOCode] NVARCHAR(10) NULL,
        [ShortCode] NVARCHAR(10) NULL,
        [Active] BIT NOT NULL DEFAULT 1,
        [Created] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
        [Deleted] DATETIME2(7) NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- Languages table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Languages]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Languages] (
        [Id] BIGINT IDENTITY(1,1) NOT NULL,
        [Name] NVARCHAR(400) NOT NULL,
        [NativeName] NVARCHAR(999) NULL,
        [Note] NVARCHAR(MAX) NULL,
        [Code] NVARCHAR(10) NULL,
        [Active] BIT NOT NULL DEFAULT 1,
        [Created] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
        [Deleted] DATETIME2(7) NULL,
        CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- CountryLanguages table (junction table for Country-Language relationship)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountryLanguages]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[CountryLanguages] (
        [Id] BIGINT IDENTITY(1,1) NOT NULL,
        [Title] NVARCHAR(500) NULL,
        [CountryId] BIGINT NOT NULL,
        [LanguageId] BIGINT NOT NULL,
        [Note] NVARCHAR(MAX) NULL,
        [Active] BIT NOT NULL DEFAULT 1,
        [Created] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
        [Deleted] DATETIME2(7) NULL,
        CONSTRAINT [PK_CountryLanguages] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- TranslationKeys table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TranslationKeys]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[TranslationKeys] (
        [Id] BIGINT IDENTITY(1,1) NOT NULL,
        [Key] NVARCHAR(300) NOT NULL,
        [EnglishValue] NVARCHAR(MAX) NOT NULL,
        [Comments] NVARCHAR(MAX) NULL,
        [Active] BIT NOT NULL DEFAULT 1,
        [TranslatorId] BIGINT NOT NULL,
        [Created] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
        [Deleted] DATETIME2(7) NULL,
        CONSTRAINT [PK_TranslationKeys] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- Translations table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Translations]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Translations] (
        [Id] BIGINT IDENTITY(1,1) NOT NULL,
        [TranslationKeyId] BIGINT NOT NULL,
        [TranslatorId] BIGINT NULL,
        [CountryLanguageId] BIGINT NULL,
        [Value] NVARCHAR(MAX) NULL,
        [Translated] DATETIME2(7) NULL,
        [Comments] NVARCHAR(MAX) NULL,
        [Active] BIT NOT NULL DEFAULT 1,
        [Created] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
        [Deleted] DATETIME2(7) NULL,
        CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- TranslatorCountryLanguages table (junction table for Translator-CountryLanguage relationship)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TranslatorCountryLanguages]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[TranslatorCountryLanguages] (
        [Id] BIGINT IDENTITY(1,1) NOT NULL,
        [TranslatorId] BIGINT NOT NULL,
        [CountryLanguageId] BIGINT NOT NULL,
        [Note] NVARCHAR(MAX) NULL,
        [Active] BIT NOT NULL DEFAULT 1,
        [Created] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
        [Deleted] DATETIME2(7) NULL,
        CONSTRAINT [PK_TranslatorCountryLanguages] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- Add Foreign Key Constraints

-- CountryLanguages -> Countries
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CountryLanguages_Countries')
BEGIN
    ALTER TABLE [dbo].[CountryLanguages]
    ADD CONSTRAINT [FK_CountryLanguages_Countries]
    FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id]);
END
GO

-- CountryLanguages -> Languages
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CountryLanguages_Languages')
BEGIN
    ALTER TABLE [dbo].[CountryLanguages]
    ADD CONSTRAINT [FK_CountryLanguages_Languages]
    FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Languages] ([Id]);
END
GO

-- TranslationKeys -> Translators
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_TranslationKeys_Translators')
BEGIN
    ALTER TABLE [dbo].[TranslationKeys]
    ADD CONSTRAINT [FK_TranslationKeys_Translators]
    FOREIGN KEY ([TranslatorId]) REFERENCES [dbo].[Translators] ([Id]);
END
GO

-- Translations -> TranslationKeys
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Translations_TranslationKeys')
BEGIN
    ALTER TABLE [dbo].[Translations]
    ADD CONSTRAINT [FK_Translations_TranslationKeys]
    FOREIGN KEY ([TranslationKeyId]) REFERENCES [dbo].[TranslationKeys] ([Id]);
END
GO

-- Translations -> CountryLanguages
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Translations_CountryLanguages')
BEGIN
    ALTER TABLE [dbo].[Translations]
    ADD CONSTRAINT [FK_Translations_CountryLanguages]
    FOREIGN KEY ([CountryLanguageId]) REFERENCES [dbo].[CountryLanguages] ([Id]);
END
GO

-- TranslatorCountryLanguages -> Translators
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_TranslatorCountryLanguages_Translators')
BEGIN
    ALTER TABLE [dbo].[TranslatorCountryLanguages]
    ADD CONSTRAINT [FK_TranslatorCountryLanguages_Translators]
    FOREIGN KEY ([TranslatorId]) REFERENCES [dbo].[Translators] ([Id]);
END
GO

-- TranslatorCountryLanguages -> CountryLanguages
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_TranslatorCountryLanguages_CountryLanguages')
BEGIN
    ALTER TABLE [dbo].[TranslatorCountryLanguages]
    ADD CONSTRAINT [FK_TranslatorCountryLanguages_CountryLanguages]
    FOREIGN KEY ([CountryLanguageId]) REFERENCES [dbo].[CountryLanguages] ([Id]);
END
GO

-- Create Indexes for better query performance
CREATE NONCLUSTERED INDEX [IX_CountryLanguages_CountryId] ON [dbo].[CountryLanguages] ([CountryId]);
GO
CREATE NONCLUSTERED INDEX [IX_CountryLanguages_LanguageId] ON [dbo].[CountryLanguages] ([LanguageId]);
GO
CREATE NONCLUSTERED INDEX [IX_TranslationKeys_TranslatorId] ON [dbo].[TranslationKeys] ([TranslatorId]);
GO
CREATE NONCLUSTERED INDEX [IX_Translations_TranslationKeyId] ON [dbo].[Translations] ([TranslationKeyId]);
GO
CREATE NONCLUSTERED INDEX [IX_Translations_CountryLanguageId] ON [dbo].[Translations] ([CountryLanguageId]);
GO
CREATE NONCLUSTERED INDEX [IX_TranslatorCountryLanguages_TranslatorId] ON [dbo].[TranslatorCountryLanguages] ([TranslatorId]);
GO
CREATE NONCLUSTERED INDEX [IX_TranslatorCountryLanguages_CountryLanguageId] ON [dbo].[TranslatorCountryLanguages] ([CountryLanguageId]);
GO

-- Insert default admin user
IF NOT EXISTS (SELECT * FROM [dbo].[Translators] WHERE [EmailAddress] = 'admin@translations.local')
BEGIN
    INSERT INTO [dbo].[Translators]
        ([EmailAddress], [Password], [FirstName], [LastName], [Active], [Role], [Created])
    VALUES
        ('admin@translations.local', 'admin123', 'Admin', 'User', 1, 'Admin', GETDATE());
END
GO

PRINT 'Translations database schema created successfully!';
GO
