using Market.Application.Commands.OrderCommands;
using Market.Domain.Interfaces.IRepositories;
using Market.Domain.Interfaces.MessageBroker;
using Market.Infrastructure.Data;
using MarketPlace.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Tests.OrderTests.Commands
{
    public class AddOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepo;
        public AddOrderCommandHandlerTests()
        {
            _orderRepo = MockOrderRepository.GetOrderRepository();
        }

        [Fact]
        public async void AddOrdersToCartTests()
        {
            var context = new Mock<ApplicationDbContext>();
            var broker = new Mock<IBrokerService>();
            var userRepo = new Mock<IUserRepository>();
            var handler = new AddToCartCommandHandler(_orderRepo.Object, context.Object, userRepo.Object, broker.Object);
            var result = await handler.Handle(new AddToCartCommand(), CancellationToken.None);

            Assert.NotNull(result.Entity);
            Assert.Equal(true, result.Succeeded);
        }
    }
}
