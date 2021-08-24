using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string oldPath = "C:\\Users\\Kubilay\\source\\repos\\CarRental\\CarRentalApi\\WebAPI\\wwwroot";

        public static string Add(IFormFile formFile)
        {
            var sourcePath = Path.GetTempFileName();
            using (var stream = new FileStream(sourcePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            var result = NewPath(formFile);
            File.Move(sourcePath, result);
            return result.Replace(oldPath, "");

        }

        public static string Update(string sourcePath, IFormFile formFile)
        {
            var path = NewPath(formFile);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(stream);
                stream.Flush();
            }
            File.Delete(sourcePath);
            return path.Replace(oldPath, "");

        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }


        public static string NewPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + "\\wwwroot" + "\\images";

            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{ path}\{newPath}";
            return result;
        }
    }
}
