using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.API.Data.Repository;
using Products.API.DTO;
using Products.API.Models;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public SellerController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sellers = await _repository.GetAllSellers();

            var response = _mapper.Map<IEnumerable<SellerDTO>>(sellers);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seller = await _repository.GetSellerById(id);

            var response = _mapper.Map<SellerDTO>(seller);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegisterSellerDTO model)
        {
            var product = _mapper.Map<Seller>(model);

            _repository.Add(product);
            _repository.Save();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RegisterSellerDTO model)
        {
            var seller = _repository.GetSellerById(id);

            if (seller == null)
                return BadRequest();

            _mapper.Map(model, seller);

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
