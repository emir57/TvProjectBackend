using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    {
        Task<IResult> UploadImageAsync(IFormFile file);
        //Task<IResult> UpdateImageAsync(IFormFile file);
    }
}
