## Bevo’s Tunes (ASP.NET Core MVC Music Sales Platform)
> Bevo’s Tunes is an enterprise ASP.NET Core 8.0 MVC platform for digital music sales and catalog management. Built with C# and EF Core on Azure SQL, it features role-based access control (RBAC), multi-criteria search algorithms, dynamic 8.25% tax and order workflows, transactional integrity, and automated Gmail SMTP integration for gift routing.

## Project Overview
Bevo’s Tunes (BT) is a Texas-based music sales and management web application built for the **MIS 333K (Spring 2026) Final Project** at UT Austin. The system manages relational music catalog data, customer accounts, transactional shopping carts, order history, and back-office administrative reporting.

## Tech Stack & Architecture
* **Backend:** C#, ASP.NET Core 8.0 MVC
* **ORM & Database:** Entity Framework Core (Code-First), Azure SQL Database / Microsoft SQL Server
* **Frontend:** Razor Views, HTML5, CSS3, Bootstrap 5
* **Authentication & Services:** ASP.NET Core Identity, Gmail SMTP Service Integration
* **Cloud Infrastructure:** Azure App Service & Azure SQL Server

## Key Features & System Architecture
### Multi-Tiered Role-Based Access Control (RBAC)
* **Customers:** 
  * Account creation with automatic city/state lookup via zip code.
  * Payment method management with dynamic credit card type detection (Visa, MasterCard, Discover, Amex).
  * Personal collection management ("My Music") and order history tracking.
  * Gift-purchasing workflow with automated recommendation generation.
  * Purchase-verified review and rating system (1.0 – 5.0 stars).
* **Employees:** 
  * Backend customer support and account management (enable/disable accounts).
  * Manual order creation ("Purchase on behalf of customer").
  * Review moderation and approval workflows.
* **Managers:** 
  * Full catalog management (adding/editing songs, albums, artists, genres).
  * Employee management (hiring, firing, re-hiring, and manager promotions).
  * Promotional management (featured items and individual item discounts).
  * Business reporting engine (sales per song/album, revenue analysis, top-selling artists by genre).

### Relational Music Search Engine
* Keyword search across Title, Artist, and Album names with built-in SQL injection safeguards.
* Dynamic multi-genre filtering pulled directly from database records.
* Rating threshold filters (less than / greater than decimal boundaries between 1.0 and 5.0).
* Search result pagination metrics ("Displaying X of Y records").

### E-Commerce & Transactional Integrity
* Persistent shopping cart preserved across user login sessions.
* Real-time price calculation factoring dynamic discounts and automated 8.25% state sales tax.
* Duplicate item prevention algorithms.
* Unique sequential order confirmation numbering starting at **#212000**.
* Automated order confirmation and gift recipient emails with one-click refund options.
