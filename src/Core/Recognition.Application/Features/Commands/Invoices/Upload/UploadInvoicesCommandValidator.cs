using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.Commands.Invoices.Upload
{
    public class UploadInvoicesCommandValidator : AbstractValidator<UploadInvoicesCommand>
    {
        public UploadInvoicesCommandValidator()
        {

            RuleFor(v => v.Data)
                  .NotNull()
                  .NotEmpty();


        }
    }
}
