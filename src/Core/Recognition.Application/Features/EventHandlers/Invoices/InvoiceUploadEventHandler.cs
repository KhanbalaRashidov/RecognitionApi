using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;
using Recognition.Application.Abstracts;
using Recognition.Application.Features.PaddleOCR;
using Recognition.Application.Models;
using Recognition.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.EventHandlers.Invoices
{
    public class InvoiceUploadedEventHandler : INotificationHandler<DomainEventNotification<InvoiceUploadedEvent>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IInvoiceOCRJob _ocr;
        private readonly ILogger<InvoiceUploadedEventHandler> _logger;

        public InvoiceUploadedEventHandler(
            IApplicationDbContext context,
            IInvoiceOCRJob ocr,
            ILogger<InvoiceUploadedEventHandler> logger
            )
        {
            _context = context;
            _ocr = ocr;
            _logger = logger;
        }
        public async Task Handle(DomainEventNotification<InvoiceUploadedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            var id = domainEvent.Item.Id;
            var item = await _context.Invoices.FindAsync(new object[] { id }, cancellationToken);
            item.Status = "Queuing";
            await _context.SaveChangesAsync();
            BackgroundJob.Enqueue(() => _ocr.Recognition(domainEvent.Item.Id));
            
        }
    }
}
