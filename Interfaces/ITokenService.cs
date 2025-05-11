using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finshark.Models;

namespace Finshark.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);

    }
}