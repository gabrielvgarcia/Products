using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.API.Data.Repository;
using Products.API.DTO;
using Products.API.Models;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _repository.GetAllProducts();

            var response = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _repository.GetProductById(id);

            var response = _mapper.Map<ProductDTO>(product);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegisterProductDTO model)
        {
            var product = _mapper.Map<Product>(model);

            _repository.Add(product);

            _repository.Save();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RegisterProductDTO model)
        {
            var product = _repository.GetProductById(id);

            if (product == null) return BadRequest();

            _mapper.Map(model, product);

            _repository.Update(product);

            _repository.Save();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _repository.GetProductById(id);

            if (product == null) return BadRequest();

            _repository.Delete(product);
            _repository.Save();

            return Ok();
        }
    }
}
