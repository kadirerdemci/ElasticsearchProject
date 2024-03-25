using ElasticProject.Data.Entity;
using ElasticProject.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IElasticsearchService _elasticsearchService;

        public ValuesController(IElasticsearchService elasticsearchService)
        {
            _elasticsearchService = elasticsearchService ?? throw new ArgumentNullException(nameof(elasticsearchService));
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity([FromBody] List<Cities> cities)
        {
            var result = await _elasticsearchService.IndexCitiesAsync(cities);
            return Ok(result);
        }

        [HttpGet("CreateIndex")]
        public async Task<IActionResult> CreateIndex()
        {
            await _elasticsearchService.CreateIndexAsync("cities");
            return Ok();
        }

        [HttpGet("DeleteIndex")]
        public async Task<IActionResult> DeleteIndex()
        {
            var result = await _elasticsearchService.DeleteIndexAsync();
            return Ok(result);
        }

        [HttpGet("CheckIndexExists")]
        public async Task<IActionResult> CheckIndexExists()
        {
            var result = await _elasticsearchService.CheckIndexExistsAsync("cities");
            return Ok(result);
        }

        [HttpGet("GetAllDocuments")]
        public async Task<IActionResult> GetAllDocuments()
        {
            var result = await _elasticsearchService.GetAllDocumentsAsync("cities");
            return Ok(result);
        }

        [HttpGet("SearchCities")]
        public async Task<IActionResult> SearchCities(string query)
        {
            var result = await _elasticsearchService.SearchCitiesAsync(query);
            return Ok(result);
        }
    }
}
