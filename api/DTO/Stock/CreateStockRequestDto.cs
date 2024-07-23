using System.ComponentModel.DataAnnotations;

namespace api.DTO.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol can not be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "CompanyName can not be over 10 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, double.PositiveInfinity)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.01, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Industry can not be over 10 characters")]
        public string Industry { get; set; } = string.Empty;
        [Range(1, 500000)]
        public long MarketCap { get; set; }
    }
}