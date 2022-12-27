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

namespace Recognition.Application.Features.Commands.Invoices.Create
{
    public class CraeteInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CraeteInvoiceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Invoice>(request);
            _context.Invoices.Add(item);
            await _context.SaveChangesAsync();
            return Result<int>.Success(item.Id);
        }
    }
}
