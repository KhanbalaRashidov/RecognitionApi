using AutoMapper;
using MediatR;
using Recognition.Application.Abstracts;
using Recognition.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.Commands.Invoices.Update
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdateInvoiceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Result> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Invoices.FindAsync(new object[] { request.Id }, cancellationToken);
            if (item != null)
            {
                item = _mapper.Map(request, item);
                await _context.SaveChangesAsync();
            }
            return Result.Success();
        }
    }
}
