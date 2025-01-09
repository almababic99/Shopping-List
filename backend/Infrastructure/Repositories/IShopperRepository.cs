using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public interface IShopperRepository
    {
        IEnumerable<Shopper> GetShoppers();
    }
}
