using MediatR;
using Recognition.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Models
{
    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
    {
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }

        public TDomainEvent DomainEvent { get; }
    }
}
