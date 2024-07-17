using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPhotoUploadService
    {
        Task<Core.Utilities.Results.IResult> UploadImageAsync(IFormFile file,Photo photo);
    }
}
