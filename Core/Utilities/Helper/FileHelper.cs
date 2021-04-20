using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";


        public static IResult Add(IFormFile file)
        {
            var Checkfile = CheckIfFile(file);
            if (!Checkfile.Success)
            {
                return new ErrorResult(Checkfile.Message);
            }
            
            var type = Path.GetExtension(file.FileName);
            var typeControl = CheckIfFileType(type);
            if (!typeControl.Success)
            {
                return new ErrorResult(typeControl.Message);
            }
            
            var randomName = Guid.NewGuid().ToString();
            CheckDirectory(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName+ randomName + type, file);
            return new SuccessResult(_folderName + randomName + type);
        }

        public static IResult Update(IFormFile file, string imagePath)
        {
            var Checkfile = CheckIfFile(file);
            if (!Checkfile.Success)
            {
                return new ErrorResult(Checkfile.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeControl = CheckIfFileType(type);
            if (!typeControl.Success)
            {
                return new ErrorResult(typeControl.Message);
            }

            var randomName = Guid.NewGuid().ToString();

            DeleteFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CheckDirectory(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IResult Delete(string imagePath)
        {
            DeleteFile((_currentDirectory + imagePath).Replace("/", "\\"));
            return new SuccessResult();
        }
        private static IResult CheckIfFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Dosya bulunamadı.");
        }
        private static IResult CheckIfFileType(string type)
        {
            if (type != ".jpg" && type != ".jpeg" && type != ".png")
            {
                return new ErrorResult("Yanlış dosya tipi.");
            }
            return new SuccessResult();
        }

        private static void CheckDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
        private static void DeleteFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }
    }
}
