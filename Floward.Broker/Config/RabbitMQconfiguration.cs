﻿using Market.Domain.Interfaces.MessageBroker;
using Market.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Broker.Config
{
    public class RabbitMQconfiguration : IRabbitMQConfiguration
    {
        private readonly IConfiguration _config;
        public RabbitMQconfiguration(IConfiguration config)
        {
            _config = config;
        }

        public RabbitMQModel GetRabbitMQConfigData()
        {
            try
            {
                var result = _config.GetSection($"RabbitMQ").Get<RabbitMQModel>();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
