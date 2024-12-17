using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {

        // here we securing the _context variable 
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        // gets the all stocks
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList().Select(s => s.ToStockDTO());
            return Ok(stocks);
        }

        // get the stock by an id
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDTO());

        }

    }
}