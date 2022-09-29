using AutoMapper;
using Market.Application.Queries.OrderQueries;
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

namespace MarketPlace.Tests.OrderTests.Queries
{
    public class GetOrdersRequestHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepo;
        public GetOrdersRequestHandlerTests()
        {
            _orderRepo = MockOrderRepository.GetOrderRepository();
        }

        [Fact]
        public async void GetAllOrdersTests()
        {
            var handler = new GetAllOrdersQueryHandler(_orderRepo.Object);
            var result = await handler.Handle(new GetAllOrdersQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result>();
            Assert.NotNull(result.Entity);
            Assert.Equal(true, result.Succeeded);
        }
    }
}
