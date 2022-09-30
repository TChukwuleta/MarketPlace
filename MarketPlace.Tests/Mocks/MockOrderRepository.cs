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
    public static class MockOrderRepository
    {
        public static Mock<IOrderRepository> GetOrderRepository()
        {
            var orderRepository = new Mock<IOrderRepository>();
            List<Order> orders = new List<Order>()
            {

                new Order()
                {
                    Id = 1,
                    Quantity = 1,
                    OrderStatus = OrderStatus.OrderProcessing,
                    CreatedDate = DateTime.Now,
                    Status = Status.Active,
                    StatusDesc = Status.Active.ToString(),
                    UserId = "4ce406ea-aece-41ba-999a-0f86434a3201"
                },
                new Order()
                {
                    Id = 2,
                    Quantity = 3,
                    OrderStatus = OrderStatus.OrderInTransit,
                    CreatedDate = DateTime.Now.AddHours(1),
                    Status = Status.Active,
                    StatusDesc = Status.Active.ToString(),
                    UserId = "9sf521ea-aece-41ba-999a-0f86434a3201"
                }
            };

            var newOrder = new Order { 
                Id = 10, 
                CreatedDate = DateTime.Now, 
                Status = Status.Active, 
                StatusDesc = Status.Active.ToString(), 
                Quantity = 2, 
                OrderStatus = OrderStatus.OrderPickupAvailable, 
                UserId = "3ae406ea-aece-41ba-999a-0f86434a3201" 
            };
            //orders.Add(newOrder);

            orderRepository.Setup(c => c.GetAllAsync().Result).Returns(orders);
            orderRepository.Setup(c => c.GetByIdAsync(It.IsAny<int>()).Result).Returns((int id) => orders.FirstOrDefault(c => c.Id == id));
            orderRepository.Setup(c => c.AddAsync(It.IsAny<Order>())).ReturnsAsync((Order order) =>
            {
                orders.Add(newOrder);
                return newOrder;
            });
            /*orderRepository.Setup(c => c.UpdateAsync(It.IsAny<Order>())).Callback(() => { return; });
            orderRepository.Setup(c => c.DeleteAsync(It.IsAny<Order>())).Callback(() => { return; });*/
            return orderRepository;
        }
    }
}
