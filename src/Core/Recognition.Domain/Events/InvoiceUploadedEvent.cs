using Recognition.Domain.Common;
using Recognition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Domain.Events
{
    public class InvoiceUploadedEvent : DomainEvent
    {
        public InvoiceUploadedEvent(Invoice item)
        {
            Item = item;
        }

        public Invoice Item { get; }
    }
}
