using Recognition.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Domain.Entities
{
    public class InvoiceRawData:AuditableEntity
    {
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public string Text { get; set; }
        public decimal Confidence { get; set; }
        public string Text_Region { get; set; }
        public string Label { get; set; }
    }
}
