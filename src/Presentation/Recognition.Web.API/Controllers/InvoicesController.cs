using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recognition.Application.Features.Commands.Invoices.Upload;

namespace Recognition.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly ISender _mediator;
        public InvoicesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadInvoice( IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            var command = new UploadInvoicesCommand
            {
                FileName = file.FileName,
                Data = stream.ToArray()
            };
            var result= await _mediator.Send(command);
            return new JsonResult(result);
        }

    }
}
