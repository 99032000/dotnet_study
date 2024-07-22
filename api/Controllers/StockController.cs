using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.DTO.Stock;
using api.Mappers;
using Microsoft.EntityFrameworkCore;
using api.interfaces;
namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;

        public StockController(ApplicationDBContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepo = stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepo.GetAllAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stockDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);
            if (stock == null) return NotFound();
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            await _stockRepo.CreatAysnc(stockModel);
            return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
        {
            var stockModel = await _stockRepo.UpdateAsync(id, stockDto);
            if (stockModel == null) return NotFound();

            return Ok(stockModel.ToStockDto());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepo.DeleteAsync(id);
            if (stockModel == null) return NotFound();
            return NoContent();
        }
    }
}