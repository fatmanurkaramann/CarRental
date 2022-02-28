using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";

        public static IResult Upload(IFormFile file)
        {
            var type = Path.GetExtension(file.FileName);
            IResult result = BusinessRules.Run(CheckFileExists(file), CheckFileTypeValid(type));
            if (result!=null)
            {
                return new ErrorResult(result.Message);
            }
            var randomName = Guid.NewGuid().ToString();
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }
        private static IResult CheckFileTypeValid(string type)
        {
            if (type!=".jpeg"&&type!=".png"&&type!=".jpg")
            {
                return new ErrorResult("Geçersiz dosya");
            }
            return new SuccessResult();
        }
        private static IResult CheckFileExists(IFormFile file)
        {
            if (file!=null&&file.Length>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Dosya Bulunamadı");
        }
        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static void CreateImageFile(string directory,IFormFile file)
        {
            using (FileStream fs=File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
    }
}
