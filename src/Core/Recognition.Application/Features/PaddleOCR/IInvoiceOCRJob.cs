using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Features.PaddleOCR
{
    public interface IInvoiceOCRJob
    {
        Task Recognition(int id);
    }
}
