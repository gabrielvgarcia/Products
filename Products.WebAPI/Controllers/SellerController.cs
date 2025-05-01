using Microsoft.AspNetCore.Mvc;
using Products.API.Data.Repository;
using Products.API.Models;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IRepository _repository;

        public SellerController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _repository.GetAllSellers();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _repository.GetSellerById(id);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Seller model)
        {
            _repository.Add(model);
            _repository.Save();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Seller model)
        {
            var seller = _repository.GetSellerById(id);

            if (seller == null)
                return BadRequest();

            seller.ProductSellers = model.ProductSellers;
            seller.Name = model.Name;

            _repository.Update(seller);

            _repository.Save();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var seller = _repository.GetSellerById(id);

            if (seller == null)
                return BadRequest();

            _repository.Delete(seller);
            _repository.Save();

            return Ok();
        }
    }
}
