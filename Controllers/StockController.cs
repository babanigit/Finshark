using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finshark.Data;
using Finshark.DTOs.stocks;
using Finshark.Helpers;
using Finshark.Interfaces;
using Finshark.Mappers;
using Finshark.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finshark.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // here we securing the _context variable 
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDbContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }

        // gets the all stocks
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Console.WriteLine(" ✅ getting the stock .... ");

            var stocks = await _stockRepo.GetAllAsync(query); // getting correct data cause of interface  interface\repo

            var stockDto = stocks.Select(s => s.ToStockDTO()).ToList(); // filtering the data cause of DTO  mapper\dto

            return Ok(stockDto);
        }

        // get the stock by an id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockRepo.GetByIdAsync(id);  //interface\repo
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDTO()); //mapper\dto
        }

        // create stock
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = stockDTO.ToStockFromCreateDTO(); //mapper\dto
            await _stockRepo.CreateAsync(stockModel); //interface\rep
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDTO());
        }

        // update the stock
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
            if (stockModel == null)
            {
                return NotFound();
            }
            return Ok(stockModel.ToStockDTO());
        }

        // delete the stock
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = await _stockRepo.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }
            return Ok(stockModel.ToStockDTO());
        }
    }
}