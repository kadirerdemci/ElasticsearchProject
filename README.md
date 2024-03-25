City Management Application using Elasticsearch and C# This application allows users to add and list cities using Elasticsearch in a C# environment.

Setup

Elasticsearch Installation:
Ensure Elasticsearch is installed and running. Download it from Elastic's official website. 2. C# Environment Setup: Set up a C# development environment such as Visual Studio or any preferred IDE. 3. Elasticsearch .NET Client Installation: Install the Elasticsearch .NET client library via NuGet Package Manager: bash Copy code Install-Package Elasticsearch.Net Install-Package NEST 4. Clone Repository: Clone the repository: bash Copy code git clone https://github.com/your-username/your-repository.git 5. Configuration: Update Elasticsearch connection settings in the application code (Program.cs) to match your Elasticsearch instance: csharp Copy code var node = new Uri("http://localhost:9200"); // Change to your Elasticsearch URL var settings = new ConnectionSettings(node); var client = new ElasticClient(settings); Usage Adding a City:

Run the application and choose the option to add a city. Follow the prompts to enter city details like name, population, etc. Listing Cities:

Run the application and select the option to list cities. This will display all cities stored in Elasticsearch. Contributing Contributions are welcome! If you find bugs or wish to add features, open an issue or submit a pull request.

License This project is licensed under the MIT License. See the LICENSE file for details.

API Kullanımı
Tüm öğeleri getir
  GET /api/items
Parametre	Tip	Açıklama
api_key	string	Gerekli. API anahtarınız.
Öğeyi getir
  GET /api/items/${id}
Parametre	Tip	Açıklama
id	string	Gerekli. Çağrılacak öğenin anahtar değeri
