using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Abstracts
{
    public interface IResult
    {
        string[] Errors { get; set; }
        string[] Warnings { get; set; }
        bool Succeeded { get; set; }

    }
    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
