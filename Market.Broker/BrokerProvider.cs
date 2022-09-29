using Market.Domain.Interfaces.MessageBroker;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Broker
{
    public class BrokerProvider : IBrokerProvider
    {
        public BrokerProvider(IModel rabbitMQChannel)
        {
            RabbitMQChannel = rabbitMQChannel;
        }
        public IModel RabbitMQChannel { get; set; }
    }
}
