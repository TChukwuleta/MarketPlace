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

namespace Market.Webapi.Tests
{
    public class OrderControllerTests
    {
        private readonly IMediator mediator;

        [Fact]
        public void WhenGettingAllOrders_ThenAllOrdersReturn()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var orderController = new OrderController(mediator);
            var result = orderController.GetAllOrders();
            Assert.NotNull(result);
            Assert.Equal(true, result.IsCompleted);
        }

        [Fact]
        public void GivenAnIdOfAnExistingOrder_WhenGettingOrderById_ThenOrderReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var orderController = new OrderController(mediator);
            var id = 3;
            var result = orderController.GetOrderById(id);
            Assert.NotNull(result);
            Assert.Equal(true, result.IsCompleted);
        }

        [Fact]
        public void GivenAnIdOfANonExistingOrder_WhenGettingOrderById_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var orderController = new OrderController(mediator);
            var id = 120;
            var result = orderController.GetOrderById(id);
            Assert.NotNull(result);
            Assert.Equal(false, result.IsCompleted);
        }
    }
}
