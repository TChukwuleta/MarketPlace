using Market.Domain.Entities;
using Market.Domain.Interfaces.IRepositories;
using Market.Infrastructure.Data;
using Market.Infrastructure.Services.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Infrastructure.Services.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
