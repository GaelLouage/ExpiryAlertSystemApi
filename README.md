🧊 Expiry Alert System API

A lightweight ASP.NET Core API that reads perishable product data from a JSON file and returns expiry alerts based on configurable thresholds.
📦 Features

    ✅ Detects expired and soon-to-expire products

    📁 Reads product data from a local JSON file

    ⚙️ Supports configurable expiry threshold (in days) via query param

    🔁 Clean separation of logic using extension methods and service classes

    🧪 Includes a basic test with NUnit

🚀 Getting Started
1. Clone the repository

git clone https://github.com/your-username/expiry-alert-api.git
cd expiry-alert-api

2. Configure settings

Edit appsettings.json:

"PerishableService": {
  "FilePath": "C:\\path\\to\\your\\products.json"
}

3. Sample JSON file

[
  { "id": 1, "name": "Milk", "expiryDate": "2025-05-20" },
  { "id": 2, "name": "Cheese", "expiryDate": "2025-06-01" }
]

4. Run the API

dotnet run

🔍 API Usage

Endpoint:

GET /expiry-alerts?daysThreshold=10

Query Params:
Param	Description	Default
daysThreshold	Number of days to check ahead	7

Response Example:

[
  {
    "productName": "Milk",
    "status": "Soon"
  },
  {
    "productName": "Yogurt",
    "status": "Expired"
  }
]

🧪 Running Tests

Run tests with:

dotnet test

🧱 Project Structure

Infra/
├── Models/               # Entity definitions
├── Dtos/                 # DTOs used in responses
├── Enums/                # Enum for alert types
├── Services/             # Business logic
├── Extensions/           # Alert logic extensions
├── Helpers/              # IO helper functions

📬 Contributing

Feel free to fork the repo, submit issues or create a pull request. Feedback and improvements are always welcome!
