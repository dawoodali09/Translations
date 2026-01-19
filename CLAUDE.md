# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build Commands

```bash
# Build entire solution
msbuild Translations\Translations.sln /p:Configuration=Release

# Build specific project
msbuild Translations\Translations\Translations.csproj /p:Configuration=Debug

# Restore NuGet packages (if needed)
nuget restore Translations\Translations.sln
```

## Architecture

This is an ASP.NET Web Forms application (.NET Framework 4.5) for managing translations across multiple countries and languages. It uses Entity Framework 6 with Database-First approach.

### Project Structure

- **Translations** (Web Application) - ASP.NET Web Forms frontend with ASPX pages
- **Bll** (Business Logic Layer) - Repository classes for data access patterns
- **DAL** (Data Access Layer) - Entity Framework model generated from `TranslationEntities.edmx`
- **Utility** - Shared utilities including email functionality
- **NewKeyEmails** (Console App) - Sends email notifications for pending translations to translators
- **ResxFileGenerator** (Console App) - Exports translations from database to .resx resource files

### Data Model Entities

The database schema includes: `Country`, `CountryLanguage`, `Language`, `TranslationKey`, `Translation`, `Translator`, `TranslatorCountryLanguage`

### Key Patterns

- **BaseRepository** (`Bll/Repositories/BaseRepository.cs`): All repositories inherit from this, sharing a common `Entities` DbContext
- **BaseClass** (`Translations/BaseClass.cs`): All ASPX code-behind pages inherit from this, which handles authentication via `TranslatorID` cookie and initializes repositories
- Soft deletes: Records use `Deleted` datetime field (null = not deleted) rather than hard deletes
- Entity Framework context is named `Entities` (generated in `DAL/TranslationEntities.Context.cs`)

### Database Connection

Connection string is defined in `Web.config` under the name "Entities" using Entity Framework connection string format pointing to SQL Server.
