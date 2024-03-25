using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticProject.Data.Entity;
using ElasticProject.Data.Interface;
using Microsoft.Extensions.Configuration;
using Nest;

namespace ElasticProject.Data.Service
{
    public class ElasticsearchService : IElasticsearchService
    {
        private readonly IConfiguration _configuration;
        private readonly ElasticClient _elasticClient;

        public ElasticsearchService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            string host = _configuration["ElasticsearchServer:Host"];
            string port = _configuration["ElasticsearchServer:Port"];

            if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(port))
            {
                throw new ArgumentException("Elasticsearch server configuration is missing or invalid.");
            }

            string connectionString = $"{host}:{port}";
            var settings = new ConnectionSettings(new Uri(connectionString));
            _elasticClient = new ElasticClient(settings);
        }

        public async Task<bool> CheckIndexExistsAsync(string indexName)
        {
            var indexExistsResponse = await _elasticClient.Indices.ExistsAsync(indexName);
            return indexExistsResponse.Exists;
        }

        public async Task CreateIndexAsync(string indexName)
        {
            await _elasticClient.Indices.CreateAsync(indexName, c => c
               .Map<Cities>(m => m.Properties(p => p
                   .Keyword(k => k.Name(n => n.Id))
                   .Date(d => d.Name(n => n.CreateDate))
                   .Text(t => t.Name(n => n.City))
                   .Text(t => t.Name(n => n.Region))
                   .Text(t => t.Name(n => n.Population))
               ))
            );
        }

        public async Task<bool> DeleteIndexAsync()
        {
            var deleteIndexResponse = await _elasticClient.Indices.DeleteAsync("cities");
            return deleteIndexResponse.Acknowledged;
        }

        public async Task<List<Cities>> GetAllDocumentsAsync(string indexName)
        {
            var searchResponse = await _elasticClient.SearchAsync<Cities>(s => s.Index(indexName).Size(1000));
            return searchResponse.Documents.ToList();
        }

        public async Task<bool> IndexCitiesAsync(List<Cities> cities)
        {
            var indexResponse = await _elasticClient.IndexManyAsync(cities, "cities");
            return indexResponse.IsValid;
        }

        public async Task<List<Cities>> SearchCitiesAsync(string query)
        {
            var searchResponse = await _elasticClient.SearchAsync<Cities>(s => s
               .Index("cities")
               .Query(q => q
                   .Match(m => m
                       .Field(f => f.City)
                       .Query(query)
                   )
               )
            );
            return searchResponse.Documents.ToList();
        }
    }
}
