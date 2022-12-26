using Recognition.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Domain.Entities
{
    public class Invoice:AuditableEntity,IHasDomainEvent
    {
        public string Status { get; set; }
        public string InvoiceNo { get; set; }
        public string Title { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TaxRate { get; set; }
        public decimal? Tax { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public string AttachmentUrl { get; set; }
        public string ImgString { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new();
        public virtual ICollection<InvoiceRawData> InvoiceRawData { get; set; } = new HashSet<InvoiceRawData>();
    }
}
