City Management Application using Elasticsearch and C#
This application allows users to add and list cities using Elasticsearch in a C# environment.

Setup
Elasticsearch Installation:

First, make sure you have Elasticsearch installed and running. You can download it from Elastic's official website.
C# Environment Setup:

Make sure you have a C# development environment set up. You can use Visual Studio or any other IDE of your choice.
Elasticsearch .NET Client Installation:

Install the Elasticsearch .NET client library via NuGet Package Manager:
bash
Copy code
Install-Package Elasticsearch.Net
Install-Package NEST
Clone Repository:

Clone this repository to your local machine:
bash
Copy code
git clone https://github.com/your-username/your-repository.git
Configuration:

Update the Elasticsearch connection settings in the application code (Program.cs) to match your Elasticsearch instance:
csharp
Copy code
var node = new Uri("http://localhost:9200"); // Change this to your Elasticsearch URL
var settings = new ConnectionSettings(node);
var client = new ElasticClient(settings);
Usage
Adding a City:

To add a city, simply run the application and choose the option to add a city. Follow the prompts to enter the city details such as name, population, etc.
Listing Cities:

To list all cities, run the application and select the option to list cities. This will display all the cities stored in Elasticsearch.
