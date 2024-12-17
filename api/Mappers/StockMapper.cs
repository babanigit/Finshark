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
        public static StockDTOs ToStockDTO(this Stock StockModel)
        {
            return new StockDTOs
            {
                Id = StockModel.Id,
                Symbol = StockModel.Symbol,
                CompanyName = StockModel.CompanyName,
                Purchase = StockModel.Purchase,
                LastDiv = StockModel.LastDiv,
                Industry = StockModel.Industry,
                MarketCap = StockModel.MarketCap,
                // Comments= StockModel.Comments.Select( c => c.ToCommentDto()).ToList()
            };

        }

    }
}