using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// this is the format to user write in the body , to create a request to the api

namespace api.DTOs.stocks
{
    public class CreateStockRequestDto
    {
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}