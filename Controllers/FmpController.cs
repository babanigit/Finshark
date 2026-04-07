using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finshark.DTOs.accounts;
using Finshark.Extensions;
using Finshark.Interfaces;
using Finshark.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finshark.Controllers
{
    [Route("api/fmp")]
    [ApiController]
    public class FmpController : Controller
    {

        private readonly IFMPService _fmpService;

        public FmpController(IFMPService fMPService)
        {
            _fmpService = fMPService;
        }

        [HttpGet("testfmp")]
        public async Task<IActionResult> getTestFmp()
        {
            return Ok("Testing Route");
        }

        [HttpPost("getfmp")]
        public async Task<IActionResult> GetFmp([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetFmpBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(data);
            }

        }


        [HttpPost("getkeymetrics")]
        public async Task<IActionResult> GetKeyMetrics([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetKeyMetricsBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(data);
            }

        }

    }

}