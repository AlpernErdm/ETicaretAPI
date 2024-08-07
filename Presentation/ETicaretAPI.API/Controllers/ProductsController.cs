using ETicaret.Domain;
using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeASync(new()
            //{
            //    new() { Id = Guid.NewGuid(), Name = "Product1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10
            //    },
            //    new() { Id = Guid.NewGuid(), Name = "Product2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20
            //    },
            //    new() { Id = Guid.NewGuid(), Name = "Product3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30
            //    },
            //});
            // await _productWriteRepository.SaveAsync();
            Product p = await _productReadRepository.GetByIdAsync("e0691c79-1dbe-4c33-a023-0d094fd877c4");
            //Product p = await _productReadRepository.GetByIdAsync("e0691c79-1dbe-4c33-a023-0d094fd877c4", false);false olursa eğer değişiklik yapamam
            p.Name = "Alperen";
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product= await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}