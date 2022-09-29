using Market.Domain.Entities;
using Market.Domain.Interfaces.IRepositories;
using Market.Infrastructure.Data;
using Market.Infrastructure.Services.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Infrastructure.Services.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Product> GetProductByName(string name)
        {
            try
            {
                var existingProduct = await _context.Products.FirstOrDefaultAsync(c => c.Name == name);
                return existingProduct;
            }
            catch (Exception ex)
            { 

                throw ex;
            }
        }
    }
}
