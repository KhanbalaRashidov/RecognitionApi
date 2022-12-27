using AutoMapper;
using MediatR;
using Recognition.Application.Abstracts;
using Recognition.Application.Models;
using Recognition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.Commands.Invoices.Upsert
{
    public class UpsertInvoiceCommandHandler : IRequestHandler<UpsertInvoiceCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpsertInvoiceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(UpsertInvoiceCommand request, CancellationToken cancellationToken)
        {
            if (request.Id>0)
            {
                var item = await _context.Invoices.FindAsync(new object[] { request.Id }, cancellationToken);
                item = _mapper.Map(request, item);
                await _context.SaveChangesAsync();
                return Result<int>.Success(item.Id);
            }
            else
            {
                var item = _mapper.Map<Invoice>(request);
                _context.Invoices.Add(item);
                await _context.SaveChangesAsync();
                return Result<int>.Success(item.Id);
            }
        }
    }
}
