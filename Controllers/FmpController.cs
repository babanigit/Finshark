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

        [HttpPost("searchcompany")]
        public async Task<IActionResult> SearchCompany([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetSearchDataBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(data);
            }

        }


        [HttpPost("profile")]
        public async Task<IActionResult> Profile([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetProfileBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(data);
            }

        }

        [HttpPost("incomestatement")]
        public async Task<IActionResult> IncomeStatement([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetIncomeStatementBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(data);
            }

        }

        [HttpPost("balancesheetstatement")]
        public async Task<IActionResult> BalanceSheetStatement([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetBalanceSheetStatementBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(data);
            }

        }

        [HttpPost("cashflowstatement")]
        public async Task<IActionResult> CashFlowStatement([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetCashFlowStatementBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(data);
            }

        }

        [HttpPost("stockpeers")]
        public async Task<IActionResult> StockPeers([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetStockPeersBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(data);
            }

        }

        [HttpPost("secfilings")]
        public async Task<IActionResult> SecFilings([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetSecFilingsBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(data);
            }

        }

        [HttpPost("historicalpricefull")]
        public async Task<IActionResult> HistoricalPriceFull([FromBody] FmpDto fmpDto)
        {
            Console.WriteLine($"  {fmpDto.Symbol} ");
            var data = await _fmpService.GetHistoricalPriceFullBySymbolAsync(fmpDto.Symbol!, fmpDto.Url!);
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