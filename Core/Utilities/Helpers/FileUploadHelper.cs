using Core.Utilities.Business;
using Core.Utilities.Results;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileUploadHelper
    {
        public static IResult Upload(Microsoft.AspNetCore.Http.IFormFile file, out string databasePath)
        {
            databasePath = "";
            var result = BusinessRules.Run(
                CheckFile(file)
                );
            if (result != null)
                return new ErrorResult();

            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid() + extension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images/" + fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
                stream.FlushAsync();
            }
            databasePath = $"/images/{fileName}";
            return new SuccessResult();
        }
        //public static void Update(IFormFile file,out string databasePath)
        //{
        //    CheckFile(file);
        //    var extension = Path.GetExtension(file.FileName);
        //    var fileName = Guid.NewGuid() + extension;
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images/" + fileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        file.CopyToAsync(stream);
        //        stream.FlushAsync();
        //    }
        //    databasePath = filePath;
        //}
        protected static IResult CheckFile(Microsoft.AspNetCore.Http.IFormFile file)
        {
            if (file == null || !(file.Length > 0))
                return new ErrorResult("Dosya seçiniz");

            return new SuccessResult();
        }
    }
}
