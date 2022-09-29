using Market.Domain.Entities;
using Market.Domain.Enums;
using Market.Domain.Interfaces.IRepositories;
using Market.Infrastructure.Data;
using Market.Infrastructure.Services.Repositories;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Webapi.Tests
{
    public class UnitTestBase
    {
        protected readonly OrderRepository _orderRepository;
        public List<Order> Orders { get; set; }
        protected readonly Order _order;
        protected readonly Order _newOrder;
        public UnitTestBase()
        {
            var orderRepository = new Mock<IOrderRepository>();
            var context = new Mock<ApplicationDbContext>();
            _orderRepository = new OrderRepository(context.Object);
            Orders = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(Path.Combine(@"TestData.json")));
            _order = Orders.ToArray()[0];

            _newOrder = new Order { Quantity = 2, OrderStatus = OrderStatus.OrderInTransit, UserId = "3ae406ea-aece-41ba-999a-0f86434a3201" };
            Orders.Add(_newOrder);

            orderRepository.Setup(c => c.GetAllAsync()).Returns(() => Orders.GetQueryableMockDbSet());
            orderRepository.Setup(c => c.GetByIdAsync(It.IsAny<int>())).Returns((int id) => Orders.FirstOrDefault(c => c.Id == id));
            orderRepository.Setup(c => c.AddAsync(It.IsAny<Order>())).Callback((Order order) => Orders.Add(_newOrder));
            orderRepository.Setup(c => c.UpdateAsync(It.IsAny<Order>())).Callback(() => { return; });
            orderRepository.Setup(c => c.DeleteAsync(It.IsAny<Order>())).Callback((Order order) => Orders.Remove(_order));
        }
    }
}
