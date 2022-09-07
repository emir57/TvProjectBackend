using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhotoUploadService
    {
        Task<IResult> UploadImageAsync(IFormFile file,Photo photo);
    }
}
