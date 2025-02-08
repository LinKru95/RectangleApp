# Rectangle API Service

This is a simple backend web service for managing a rectangle's dimensions. It provides endpoints for retrieving and updating rectangle data via a RESTful API.

## Table of Contents
- [Technologies Used](#technologies-used)
- [Setup and Installation](#setup-and-installation)
- [API Endpoints](#api-endpoints)

## Technologies Used
- **C#** (.NET Core Web API)
- **ASP.NET Core**
- **Entity Framework Core (EF Core)** (if database is used)
- **FluentValidation** (for input validation)
- **System.Text.Json** (for JSON serialization)
- **IIS/Express** (for local development)

## Setup and Installation

### Prerequisites
- Install [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- (Optional) Install **Postman** or **cURL** for API testing

### Steps to Run Locally using Visual Studio
1. Open the Project:
   Launch Visual Studio.
   Click on "Open a project or solution" and select the .sln file of the project.
2. Build the project:
   Click on "Build" → "Build Solution" (Ctrl + Shift + B)
3. Run the API:
   Press F5 to run the project in Debug mode (or Ctrl + F5 for running without debugging).
   Alternatively, select the appropriate launch profile (IIS Express or Kestrel) from the top bar and click Run.
5. Access the API
   Once the application starts, Visual Studio will open a browser window with the API running.
   The API will be available at: http://localhost:5000

## API Endpoints
1. Get Rectangle Data
   - Endpoint: GET /api/rectangle
   - Description: Retrieves the current rectangle's dimensions.
   - Response Example:
       {
         "width": 100,
         "height": 150
       }
2. Update Rectangle Dimensions
   - Endpoint: PUT /api/rectangle
   - Description: Updates the rectangle's dimensions.
   - Request Body (JSON):
       {
         "width": 150,
         "height": 180
       }
