using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElasticProject.Data.Entity;

namespace ElasticProject.Data.Interface
{
    public interface IElasticsearchService
    {
        Task<bool> IndexCitiesAsync(List<Cities> cities);
        Task CreateIndexAsync(string indexName);
        Task<bool> DeleteIndexAsync();
        Task<bool> CheckIndexExistsAsync(string indexName);
        Task<List<Cities>> GetAllDocumentsAsync(string indexName);
        Task<List<Cities>> SearchCitiesAsync(string query);
    }
}
