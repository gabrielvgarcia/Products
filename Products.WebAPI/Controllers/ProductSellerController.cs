using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.API.Data.Repository;
using Products.API.DTO;
using Products.API.Models;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSellerController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProductSellerController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productsSellers = _repository.GetAllProductsSellers();

            var response = _mapper.Map<IEnumerable<ProductSellerDTO>>(productsSellers);

            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var productsSeller = _repository.GetProductSellerById(id);

            var response = _mapper.Map<ProductSellerDTO>(productsSeller);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegisterProductSellerDTO model)
        {
            var productSeller = _mapper.Map<ProductSeller>(model);
            _repository.Add(productSeller);
            _repository.Save();
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RegisterProductSellerDTO model)
        {
            var productSeller = _repository.GetProductSellerById(id);
            if (productSeller == null) return BadRequest();
            _mapper.Map(model, productSeller);
            _repository.Update(productSeller);
            _repository.Save();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productSeller = _repository.GetProductSellerById(id);
            if (productSeller == null) return BadRequest();
            _repository.Delete(productSeller);
            _repository.Save();

            return Ok();
        }
    }
}
