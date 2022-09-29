using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Webapi.Tests.Mocks
{
    internal class MockIRepositoryWrapper
    {
        public static Mock<MockIRepositoryWrapper> GetMock()
        {
            var mock = new Mock<MockIRepositoryWrapper>();
            var orderRepoMock = MockIOrderRepository.GetMock();
            var productRepoMock = MockIProductRepository.GetMock();
            return mock;
        }
    }
}
