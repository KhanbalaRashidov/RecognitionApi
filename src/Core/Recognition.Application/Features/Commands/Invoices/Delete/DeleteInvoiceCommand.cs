using MediatR;
using Recognition.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.Commands.Invoices.Delete
{
    public class DeleteInvoiceCommand:IRequest<Result>
    {
        public int Id { get; set; }
    }
    public class DeleteCheckedInvoicesCommand : IRequest<Result>
    {
        public int[] Id { get; set; }
    }
}
