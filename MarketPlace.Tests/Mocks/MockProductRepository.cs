using Market.Domain.Entities;
using Market.Domain.Enums;
using Market.Domain.Interfaces.IRepositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Tests.Mocks
{
    public class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var productRepository = new Mock<IProductRepository>();
            List<Product> products = new List<Product>()
            {

                new Product()
                {
                    Id = 1,
                    ProductImage = "imageone.png",
                    ProductType = ProductType.Groceries,
                    Discount = 100,
                    Price = 1999,
                    Cost = 1890,
                    Name = "Milk",
                    CreatedDate = DateTime.Now,
                    Status = Status.Active,
                    StatusDesc = Status.Active.ToString()
                },
                new Product()
                {
                    Id = 2,
                    ProductImage = "imagetwo.png",
                    ProductType = ProductType.Toileteries,
                    Discount = 200,
                    Price = 4999,
                    Cost = 4790,
                    Name = "Jik",
                    CreatedDate = DateTime.Now,
                    Status = Status.Active,
                    StatusDesc = Status.Active.ToString()
                }
            };

            var newProduct = new Product
            {
                Id = 3,
                ProductImage = "imageone.png",
                ProductType = ProductType.Groceries,
                Discount = 100,
                Price = 1999,
                Cost = 1890,
                Name = "Milk",
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                StatusDesc = Status.Active.ToString()
            };
            //orders.Add(newOrder);

            productRepository.Setup(c => c.GetAllAsync().Result).Returns(products);
            productRepository.Setup(c => c.GetByIdAsync(It.IsAny<int>()).Result).Returns((int id) => products.FirstOrDefault(c => c.Id == id));
            productRepository.Setup(c => c.AddAsync(It.IsAny<Product>())).ReturnsAsync((Order order) =>
            {
                products.Add(newProduct);
                return newProduct;
            });
            return productRepository;
        }
    }
}
