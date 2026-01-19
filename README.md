# CIB Translation Management System

A web-based translation management system built with ASP.NET Web Forms that enables organizations to manage multilingual content across different countries and languages. The system allows administrators to create translation keys with English source text, assign translators to specific country-language pairs, and track translation progress.

## Features

### User Management
- **Translator Accounts**: Create and manage translator accounts with roles (Administrator/Translator)
- **Role-Based Access**: Administrators have full access; Translators see only their assigned translations
- **Profile Management**: Each translator can have contact information and profile photo

### Translation Workflow
- **Translation Keys**: Define unique keys with English source text that need translation
- **Pending Translations**: Translators see a dashboard of their pending translation tasks
- **Completed Translations**: Track and review completed translations
- **Search Functionality**: Search translations by key or by translation text

### Multi-Country/Language Support
- **Countries**: Manage list of countries with ISO codes
- **Languages**: Manage languages with native names and language codes
- **Country-Language Mapping**: Associate languages with specific countries (e.g., French for Canada, French for France)
- **Translator Assignment**: Assign translators to specific country-language combinations

### Export & Notifications
- **RESX Export**: Generate .NET resource files (.resx) from translations for use in applications
- **Email Notifications**: Automated emails to translators about pending translation tasks

## Technology Stack

- **Framework**: .NET Framework 4.8
- **Web Framework**: ASP.NET Web Forms
- **ORM**: Entity Framework 6.5.1 (Database-First)
- **Database**: SQL Server
- **Authentication**: Cookie-based authentication

## Project Structure

```
Translations/
├── Translations/          # Main web application
│   ├── *.aspx            # Web forms pages
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

### Run

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

| Page | Description |
|------|-------------|
| Login.aspx | User authentication |
| Translators.aspx | Manage translator accounts (Admin only) |
| Countries.aspx | Manage countries |
| Languages.aspx | Manage languages |
| CountryLanguages.aspx | Map languages to countries |
| TranslationKeys.aspx | Manage translation keys and English source text |
| Translations.aspx | Translator dashboard for pending/completed translations |
| TranslatorCountryLanguage.aspx | Assign translators to country-language pairs |

## Console Applications

### NewKeyEmails
Sends email notifications to translators about their pending translations.

```bash
NewKeyEmails.exe
```

### ResxFileGenerator
Exports translations from the database to .resx resource files for use in .NET applications.

```bash
ResxFileGenerator.exe
```

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
   - Mark translations as complete

4. **Export**:
   - Run ResxFileGenerator to export all translations to .resx files
   - Use generated files in .NET applications for localization

## License

All Rights Reserved - CIB Finance
