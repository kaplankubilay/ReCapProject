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
        //public static string Add(IFormFile file)
        //{
        //    string path = Environment.CurrentDirectory + @"\wwwroot";
        //    var sourcePath = Path.GetTempFileName();
        //    if (file.Length > 0)
        //    {
        //        using (var stream = new FileStream(sourcePath, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //    }
        //    var result = NewPath(file);
        //    File.Move(sourcePath, path + result);
        //    return result.Replace("\\", "/");
        //}

        //public static IResult Delete(string path)
        //{
        //    string path2 = Environment.CurrentDirectory + @"\wwwroot";
        //    path = path.Replace("/", "\\");

        //    try
        //    {
        //        File.Delete(path2 + path);
        //    }
        //    catch (Exception ex)
        //    {

        //        return new ErrorResult(ex.Message);
        //    }
        //    return new SuccessResult();
        //}

        //public static string Update(string sourcePath, IFormFile file)
        //{
        //    string path = Environment.CurrentDirectory + @"\wwwroot";
        //    var result = NewPath(file);
        //    if (sourcePath.Length > 0)
        //    {
        //        using (var stream = new FileStream(path + result, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }

        //    }
        //    File.Delete(path + sourcePath);
        //    return result.Replace("\\", "/");
        //}

        //private static string NewPath(IFormFile file)
        //{
        //    FileInfo ff = new FileInfo(file.FileName);
        //    string fileExtension = ff.Extension;

        //    var newPath = Guid.NewGuid().ToString() + fileExtension;

        //    return @"\images\" + newPath;
        //}

        public static string _oldPath = "C:\\Users\\Kubilay\\source\\repos\\CarRental\\CarRentalApi\\WebAPI\\wwwroot\\";

        public static string Add(IFormFile formFile)
        {
            var sourcePath = Path.GetTempFileName();
            using (var stream = new FileStream(sourcePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            var result = NewPath(formFile);
            File.Move(sourcePath, result);
            return result.Replace(_oldPath, "");

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
            return path.Replace(_oldPath, "");

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
