using AutoMapper;
using Recognition.Application.Mappings;
using Recognition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.DTOs.Invoices
{
    public class InvoiceDto:IMapFrom<Invoice>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceDto>().ReverseMap();

        }
        public int Id { get; set; }
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
    }
}
