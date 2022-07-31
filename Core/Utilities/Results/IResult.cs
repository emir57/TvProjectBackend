using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        string Message { get; set; }
        bool IsSuccess { get; set; }

    }
}
