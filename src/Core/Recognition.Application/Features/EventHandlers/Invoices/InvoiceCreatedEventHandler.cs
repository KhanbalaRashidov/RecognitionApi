using MediatR;
using Microsoft.Extensions.Logging;
using Recognition.Application.Models;
using Recognition.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.EventHandlers.Invoices
{
    public class InvoiceCreatedEventHandler : INotificationHandler<DomainEventNotification<InvoiceCreatedEvent>>
    {
        private readonly ILogger<InvoiceCreatedEventHandler> _logger;

        public InvoiceCreatedEventHandler(
            ILogger<InvoiceCreatedEventHandler> logger
            )
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<InvoiceCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
