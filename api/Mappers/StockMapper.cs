using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.stocks;
using api.Models;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockDTOs ToStockDTO(this Stock stockModel)
        {
            return new StockDTOs
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                // Comments= stockModel.Comments.Select( c => c.ToCommentDto()).ToList()
            };

        }

        public static Stock ToStockFromCreateDTO(this StockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }

    }
}