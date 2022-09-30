using Market.Application.Queries.ProductQueries;
using Market.Domain.Interfaces.IRepositories;
using Market.Domain.Model;
using MarketPlace.Tests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Tests.ProductTests.Queries
{
    public class GetProductsRequestHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepo;
        public GetProductsRequestHandlerTests()
        {
            _productRepo = MockProductRepository.GetProductRepository();
        }

        [Fact]
        public async void GetAllProductsTests()
        {
            var handler = new GetAllProductsQueryHandler(_productRepo.Object);
            var result = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result>();
            Assert.NotNull(result.Entity);
            Assert.Equal(true, result.Succeeded);
        }

        [Fact]
        public async void GetSingleProductTest()
        {
            var handler = new GetProductByIdQueryHandler(_productRepo.Object);
            var result = await handler.Handle(new GetProductByIdQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result>();
            Assert.Equal(true, result.Succeeded);
        }
    }
}
