using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Recognition.Application.Abstracts;
using Recognition.Application.Abstracts.Services;
using Recognition.Application.Enums;
using Recognition.Application.Models;
using Recognition.Domain.Entities;
using Recognition.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.Commands.Invoices.Upload
{
    public class UploadInvoicesCommandHandler :
                 IRequestHandler<UploadInvoicesCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<UploadInvoicesCommandHandler> _localizer;


        public UploadInvoicesCommandHandler(
            IApplicationDbContext context,
            IUploadService uploadService,
            IStringLocalizer<UploadInvoicesCommandHandler> localizer,
            IMapper mapper
            )
        {
            _context = context;
            _uploadService = uploadService;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UploadInvoicesCommand request, CancellationToken cancellationToken)
        {
            var imgbase64string = Convert.ToBase64String(request.Data);
            var result = await _uploadService.UploadAsync(new UploadRequest() { Data = request.Data, FileName = request.FileName, UploadType = UploadType.Invoice });
            var invoice = new Invoice()
            {
                AttachmentUrl = result,
                Status = "Waiting",
                ImgString = imgbase64string
            };
            invoice.DomainEvents.Add(new InvoiceUploadedEvent(invoice));
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

    }
}
