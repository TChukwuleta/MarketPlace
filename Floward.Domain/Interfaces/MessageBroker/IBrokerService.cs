﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Interfaces.MessageBroker
{
    public interface IBrokerService
    {
        void PublishToMessageQueue(string integrationEvent, string eventData);
        void Received();
    }
}
