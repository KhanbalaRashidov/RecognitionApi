using Microsoft.EntityFrameworkCore;
using Recognition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Recognition.Application.Abstracts
{
    public interface IApplicationDbContext
    {
        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceRawData> InvoiceRawDatas { get; set; }
        
    }
}
