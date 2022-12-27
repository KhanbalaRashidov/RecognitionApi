using MediatR;
using Recognition.Application.DTOs.Invoices;
using Recognition.Application.Mappings;
using Recognition.Application.Models;
using Recognition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.Commands.Invoices.Create
{
    public class CreateInvoiceCommand:InvoiceDto,IRequest<Result<int>>,IMapFrom<Invoice>
    {
    }
}
