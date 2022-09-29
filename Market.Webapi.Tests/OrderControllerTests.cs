using Market.Api.Controllers;
using Market.Domain.Entities;
using Market.Domain.Enums;
using Market.Webapi.Tests.Mocks;
using log4net.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Market.Domain.Interfaces.IRepositories;
using Moq;
using Market.Infrastructure.Services.Repositories;
using Market.Infrastructure.Data;

namespace Market.Webapi.Tests
{
    public class OrderControllerTests : MockIOrderRepository
    {

        [Fact]
        public void AddOrder_Test()
        {
            var context = new Mock<ApplicationDbContext>();
            var orderRepository = new OrderRepository(context.Object);
            var addedResult = orderRepository.AddAsync(_newOrder);
            Assert.NotNull(addedResult);
        }

        [Fact]
        public void WhenGettingAllOrders_ThenAllOrdersReturn()
        {

            var context = new Mock<ApplicationDbContext>();
            var orderRepository = new OrderRepository(context.Object);
            var allOrderResult = orderRepository.GetAllAsync();
            Assert.NotNull(allOrderResult);
        }

        [Fact]
        public void GivenAnIdOfAnExistingOrder_WhenGettingOrderById_ThenOrderReturns()
        {
            var context = new Mock<ApplicationDbContext>();
            var orderRepository = new OrderRepository(context.Object);
            var oneOrder = orderRepository.GetByIdAsync(_order.Id);
            Assert.NotNull(oneOrder);
        }
    }
}