using Microsoft.AspNetCore.Mvc;
using Products.API.Data.Repository;
using Products.API.Models;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProductController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _repository.GetAllProducts();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _repository.GetProductById(id);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            _repository.Add(model);
            _repository.Save();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product model)
        {
            var product = _repository.GetProductById(id);

            if (product == null)
                return BadRequest();

            product.ProductSellers = model.ProductSellers;
            product.Name = model.Name;

            _repository.Update(product);

            _repository.Save();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _repository.GetProductById(id);

            if (product == null)
                return BadRequest();

            _repository.Delete(product);
            _repository.Save();

            return Ok();
        }
    }
}
