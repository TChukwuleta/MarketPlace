using Market.Domain.Entities;
using Market.Domain.Interfaces.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Interfaces.IRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
