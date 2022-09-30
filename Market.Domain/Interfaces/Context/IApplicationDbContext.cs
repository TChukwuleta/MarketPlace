using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Product> Products { get; set; }
    }
}
