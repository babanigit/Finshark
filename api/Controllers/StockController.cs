using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.stocks;
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

        // create stock
        [HttpPost]
        public IActionResult Create([FromBody] StockRequestDto stockDTO)
        {
            var stockModel = stockDTO.ToStockFromCreateDTO();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDTO());

        }

        // update the stock
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
            if (stockModel == null)
            {
                return NotFound();
            }
            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            _context.SaveChanges();
            return Ok(stockModel.ToStockDTO());

        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
            if (stockModel == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stockModel);
            _context.SaveChanges();
            return Ok(stockModel.ToStockDTO());

        }

    }
}