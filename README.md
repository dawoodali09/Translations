# Translation Management System

A web-based translation management system built with ASP.NET Web Forms that enables organizations to manage multilingual content across different countries and languages. The system allows administrators to create translation keys with English source text, assign translators to specific country-language pairs, and track translation progress.

## Live Demo

The application is currently deployed and available at: **https://translate.dawoodali.co.nz/**

## Features

### User Management
- **Translator Accounts**: Create and manage translator accounts with roles (Administrator/Translator)
- **Role-Based Access Control**:
  - Administrators have full access to all features
  - Translators only see Translation Keys and Translations pages
  - Admin-only pages are protected from direct URL access
- **Profile Management**: Each translator can have contact information and profile photo

### Translation Workflow
- **Translation Keys**: Define unique keys with English source text that need translation
- **Pending Translations**: Translators see a dashboard of their pending translation tasks
- **Completed Translations**: Track and review completed translations
- **Search Functionality**: Search translations by key or by translation text
- **Comments**: Add comments to translations for context or notes

### Multi-Country/Language Support
- **Countries Management**: Full CRUD operations for countries with ISO codes and short codes
- **Languages Management**: Full CRUD operations for languages with native names, language codes, and notes
- **Country-Language Mapping**: Associate languages with specific countries (e.g., French for Canada, French for France)
- **Translator Assignment**: Assign translators to specific country-language combinations

### Resource File Generation (Admin Only)
- **Single Language Export**: Download .resx resource files for a specific country-language
- **Global Resource Export**: Download the base .resx file with all English source values
- **Bulk Export**: Download all resource files as a ZIP archive containing:
  - Global resource file (e.g., `Resources.resx`)
  - Language-specific files (e.g., `Resources.fr-FR.resx`, `Resources.es-ES.resx`)
- **Translation Statistics**: View completion percentages for each country-language
- **Empty Translation Handling**: Option to include keys with empty translations using English fallback

### Email Notifications
- **Automated Emails**: Console application to send emails to translators about pending translation tasks

## Technology Stack

- **Framework**: .NET Framework 4.8
- **Web Framework**: ASP.NET Web Forms
- **ORM**: Entity Framework 6.5.1 (Database-First)
- **Database**: SQL Server
- **Authentication**: Cookie-based authentication
- **UI**: Modern responsive CSS with flexbox layout

## Project Structure

```
Translations/
├── Translations/          # Main web application
│   ├── *.aspx            # Web forms pages
│   ├── Admin.Master      # Master page with navigation and styling
│   ├── BaseClass.cs      # Base class with common functionality
│   ├── css/              # Stylesheets
│   ├── js/               # JavaScript files
│   └── images/           # Images and user photos
├── Bll/                  # Business Logic Layer
│   └── Repositories/     # Data access repositories
├── DAL/                  # Data Access Layer
│   └── TranslationEntities.edmx  # Entity Framework model
├── Utility/              # Shared utilities (email, etc.)
├── NewKeyEmails/         # Console app for email notifications
├── ResxFileGenerator/    # Console app for RESX file generation
└── Database/             # SQL schema scripts
```

## Database Schema

| Table | Description |
|-------|-------------|
| Translators | User accounts for translators and administrators |
| Countries | List of countries with ISO codes |
| Languages | List of languages with native names |
| CountryLanguages | Maps languages to countries |
| TranslationKeys | Source text keys with English values |
| Translations | Translated text for each key per country-language |
| TranslatorCountryLanguages | Assigns translators to country-language pairs |

## Installation

### Prerequisites
- Visual Studio 2022 or later
- SQL Server 2008 or later
- .NET Framework 4.8

### Database Setup

1. Run the schema script to create the database:
```bash
sqlcmd -S <server> -U <user> -P <password> -i Database/CreateSchema.sql
```

2. Update connection strings in:
   - `Translations/Web.config`
   - `*/App.config` files in other projects

### Build

```bash
# Restore NuGet packages
nuget restore Translations/Translations.sln

# Build solution
msbuild Translations/Translations.sln /p:Configuration=Release
```

### Publish

To publish the web application:
```bash
msbuild Translations/Translations.sln /p:Configuration=Release /p:DeployOnBuild=true /p:PublishProfile=<profile-name>
```

### Run Locally

Using IIS Express:
```bash
"C:\Program Files\IIS Express\iisexpress.exe" /path:<project-path>\Translations\Translations /port:13927
```

Then open http://localhost:13927/Login.aspx

## Default Credentials

After running the database schema script:
- **Email**: `admin@translations.local`
- **Password**: `admin123`
- **Role**: Administrator

## Application Pages

### Administrator Pages
| Page | Description |
|------|-------------|
| Translators.aspx | Manage translator accounts (add, edit, delete, activate/deactivate) |
| Countries.aspx | Manage countries with ISO codes (add, edit, delete) |
| Languages.aspx | Manage languages with native names (add, edit, delete) |
| CountryLanguages.aspx | Create and manage language-country mappings |
| TranslatorCountryLanguage.aspx | Assign translators to country-language pairs |
| TranslatorTranslations.aspx | View all translations by translator |
| ResourceGenerator.aspx | Generate and download .resx resource files |

### All Users Pages
| Page | Description |
|------|-------------|
| Login.aspx | User authentication |
| TranslationKeys.aspx | Manage translation keys and English source text |
| Translations.aspx | Translator dashboard for pending/completed translations |

## Console Applications

### NewKeyEmails
Sends email notifications to translators about their pending translations.

```bash
NewKeyEmails.exe
```

### ResxFileGenerator
Command-line tool to export translations from the database to .resx resource files.

```bash
ResxFileGenerator.exe
```

Note: The Resource Generator page in the admin panel provides a web-based alternative to this console application.

## How It Works

1. **Administrator Setup**:
   - Add countries and languages to the system
   - Create country-language mappings (e.g., "English - United Kingdom", "English - United States")
   - Create translator accounts
   - Assign translators to their respective country-language pairs

2. **Adding Translation Keys**:
   - Administrator creates a translation key with a unique identifier
   - Provides the English source text
   - System automatically creates pending translation entries for all country-language pairs

3. **Translation Process**:
   - Translators log in and see their pending translations
   - Select a translation to provide the translated text
   - Add optional comments for context
   - Mark translations as complete

4. **Export Resources**:
   - Use the Resource Generator page to download .resx files
   - Select specific country-language or download all at once
   - View translation statistics to track progress
   - Generated files can be used directly in .NET applications for localization

## Role-Based Access Control

The system implements role-based access control:

| Feature | Administrator | Translator |
|---------|--------------|------------|
| View Translation Keys | Yes | Yes |
| Edit Translation Keys | Yes | Yes |
| View/Edit Translations | Yes | Yes (own assignments only) |
| Manage Translators | Yes | No |
| Manage Countries | Yes | No |
| Manage Languages | Yes | No |
| Manage Country-Languages | Yes | No |
| Assign Translator Languages | Yes | No |
| View Translator Translations | Yes | No |
| Generate Resource Files | Yes | No |

## License

All Rights Reserved
