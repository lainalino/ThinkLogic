# Think Logic

## Overview
This project is an event management system that allows users to create, edit, view  events. It also features a calendar view for managing events and an admin panel for event management.

---

## Technology Stack
The following technologies, frameworks, and libraries are used in this project:

### Backend:
- **C#**
- **ASP.NET Core**
- **Entity Framework Core**

### Frontend:
- **HTML**
- **CSS**
- **JavaScript**
- **Bootstrap 5** for responsive design

### Database:
- **Microsoft SQL Server** (through Entity Framework Core)

### Other:
- **Dependency Injection**
- **Model-View-Controller (MVC) architecture**

## Setup & Installation
Follow these steps to set up and run the project on your local machine or server.

### Prerequisites
Make sure you have the following installed:

- **.NET SDK** (version 6.0 or higher)
- **SQL Server** or another supported database

### Installation Steps

1. **Clone the repository**:
    ```bash
    git clone https://github.com/lainalino/thinklogic.git
    cd thinklogic
    ```

2. **Install dependencies**:
    ```bash
    dotnet restore
    ```

3. **Apply migrations and update the database**:
    ```bash
    dotnet ef database update
    ```

4. **Run the project**:
    ```bash
    dotnet run
    ```


