using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Recognition.Application.Abstracts;
using Recognition.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.Commands.Invoices.Delete
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, Result>,
                 IRequestHandler<DeleteCheckedInvoicesCommand, Result>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeleteInvoiceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Result> Handle(DeleteCheckedInvoicesCommand request, CancellationToken cancellationToken)
        {
            var items = await _context.Invoices.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken);
            foreach (var item in items)
            {
                _context.Invoices.Remove(item);
            }
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Invoices.FindAsync(new object[] { request.Id }, cancellationToken);
            _context.Invoices.Remove(item);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
