using MediatR;
using Recognition.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.Commands.Invoices
{
    public class UploadInvoicesCommand : IRequest<Result>
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
