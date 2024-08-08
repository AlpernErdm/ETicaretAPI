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
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        //[HttpGet]
        //public async Task GetTracking()
        //{
        //    //Product p = await _productReadRepository.GetByIdAsync("e0691c79-1dbe-4c33-a023-0d094fd877c4", false);false olursa eğer değişiklik yapamam
        //    Product p = await _productReadRepository.GetByIdAsync("e0691c79-1dbe-4c33-a023-0d094fd877c4");
        //    p.Name = "Alperen";
        //    await _productWriteRepository.SaveAsync();
        //}

        [HttpGet]
        public async Task Get()
        {
           Order order=await _orderReadRepository.GetByIdAsync("ff0aef05-2262-4db2-8cb5-f5a1d2cdfb4f ");
           order.Address = "Kırşehir";
           await _orderWriteRepository.SaveAsync();

           
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product= await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}