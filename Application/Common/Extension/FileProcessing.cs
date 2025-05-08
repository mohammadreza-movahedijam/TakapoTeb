using Application.Common.CustomException;
using Application.Common.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using System.Security.Cryptography.Xml;

namespace Application.Common.Extension;

public static class FileProcessing
{


    
    #region Format
    static string[] _allowedExtensions = { ".pdf", ".txt", ".doc", ".docx", ".xlsx" };
    #endregion

    #region Message
    static string ImagePathNotFound { set; get; } = "تصویر یافت نشد";
    static string ExceptionUpload { set; get; } = "خطای بارگذاری رخ داده است";
    static string NotValidFile { set; get; } = "فایل نامعتبر است";
    static string PathError { set; get; } = "مسیر حذف تصویر یافت نشد";
    #endregion

    #region Image
    public static string UploadImage
        (this IFormFile file,
        string folder,
        string? defualt = "default.jpg")
    {
        if (file is not null)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "gallery", folder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string filePath = Path.Combine(folderPath, fileName);
            var image = Image.Load(file.OpenReadStream());
            var save = image.SaveAsWebpAsync(filePath);
            if (save.IsCompleted)
            {
                return fileName;
            }
        }
           return defualt! ;
    }
    public static void RemoveImage(this string fileName, string folder, string? defualt = null)
    {
        if (fileName == "default.jpg" || fileName == "notFound.jpg")
        {
            return ;
        }
        if (!string.IsNullOrEmpty(defualt) && fileName == defualt)
        {
            return;
        }

        string folderPath = Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot", "gallery", folder);

        string path = Path.Combine(folderPath, fileName);

        if (File.Exists(path))
        {
            File.Delete(path);
            return;
        }
        else
        {
            throw new InternalException(PathError);
        }
    }
    #endregion

    public async static Task<string> UploadFileAsync(this IFormFile file, string folder)
    {
        try
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] fileBytes = memoryStream.ToArray();
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folder);
            byte[] fileSignature = fileBytes.Take(4).ToArray();
            string extension = Path.GetExtension(fileName).ToLower();

            bool IsValid = false;
            switch (extension)
            {
                case ".pdf":
                    IsValid = fileSignature.SequenceEqual(new byte[] { 0x25, 0x50, 0x44, 0x46 });
                    break;
                case ".txt":
                    IsValid = true;
                    break;
                case ".doc":
                    IsValid = fileSignature.SequenceEqual(new byte[] { 0xD0, 0xCF, 0x11, 0xE0 });
                    break;
                case ".docx":
                    IsValid = fileSignature.SequenceEqual(new byte[] { 0xD0, 0xCF, 0x11, 0xE0 });
                    break;
                case ".xlsx":
                    IsValid = fileSignature.SequenceEqual(new byte[] { 0x50, 0x4B, 0x03, 0x04 });
                    break;
            }
            if (IsValid == false)
            {
                throw new InternalException(NotValidFile);
            }


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
            if (!_allowedExtensions.Contains(extension))
            {
                throw new InternalException(NotValidFile);

            }
            await File.WriteAllBytesAsync(filePath, fileBytes);
            return fileName;
        }
        catch (Exception ex)
        {
            throw new InternalException(ExceptionUpload);

          
        }
    }
}













