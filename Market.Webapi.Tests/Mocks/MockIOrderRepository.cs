using Market.Domain.Entities;
using Market.Domain.Enums;
using Market.Domain.Interfaces.IRepositories;
using Market.Infrastructure.Services.Repositories;
using Moq;
using Newtonsoft.Json;
using System;

namespace Market.Webapi.Tests.Mocks
{
    public class MockIOrderRepository
    {
        protected readonly Order _order;

        protected readonly OrderRepository _orderService;
        public List<Order> Orders { get; set; }
        protected readonly Order _newOrder;

        public MockIOrderRepository()
        {
            var orderRepository = new Mock<IOrderRepository>();

            Orders = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(Path.Combine(@"TestData.json")));
            _order = Orders.ToArray()[0];

            _newOrder = new Order { Id = 10, Quantity = 2, OrderStatus = OrderStatus.OrderInTransit, UserId = "3ae406ea-aece-41ba-999a-0f86434a3201" }; Orders.Add(_newOrder);

            orderRepository.Setup(c => c.GetAllAsync()).Returns(() => Orders);
            orderRepository.Setup(c => c.GetByIdAsync(It.IsAny<int>())).Returns((int id) => Orders.FirstOrDefault(c => c.Id == id));
            orderRepository.Setup(c => c.AddAsync(It.IsAny<Order>())).Callback(() => { return; });
            orderRepository.Setup(c => c.UpdateAsync(It.IsAny<Order>())).Callback(() => { return; });
            orderRepository.Setup(c => c.DeleteAsync(It.IsAny<Order>())).Callback(() => { return; });
        }
    }
}
