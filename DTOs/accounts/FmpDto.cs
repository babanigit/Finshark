using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Finshark.DTOs.accounts
{
    public class FmpDto
    {
        public string? Symbol { get; set; }
        public string? Url { get; set; }
    }
}