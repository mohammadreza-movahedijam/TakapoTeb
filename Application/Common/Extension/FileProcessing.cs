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
    #endregion

    #region Image
    public static BaseResult<string> UploadImage
        (this IFormFile file,
        string folder,
        string? defualt = null)
    {
        if (file is not null)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Gallery", folder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string filePath = Path.Combine(folderPath, fileName);
            var image = Image.Load(file.OpenReadStream());
            var save = image.SaveAsWebpAsync(filePath);
            if (save.IsCompleted)
            {
                return BaseResult<string>.Success(fileName);
            }
        }
        if (!string.IsNullOrEmpty(defualt))
        {
            return BaseResult<string>.Success(defualt);
        }
        return BaseResult<string>.Fail(ExceptionUpload);
    }
    public static void RemoveImage(this string fileName, string folder, ILogger logger, string? defualt = null)
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
            "wwwroot", "Gallery", folder);

        string path = Path.Combine(folderPath, fileName);

        if (File.Exists(path))
        {
            File.Delete(path);
            return;
        }
        else
        {
            ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogWarning(Message.ErrorRemoveOldImage+$" => {fileName}");
            return;
        }
    }
    #endregion

    public async static Task<BaseResult> UploadFileAsync(this IFormFile file, string folder)
    {
        try
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] fileBytes = memoryStream.ToArray();
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folder);
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
                return BaseResult.Fail(NotValidFile);
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
                return BaseResult.Fail(NotValidFile);
            }
            await File.WriteAllBytesAsync(filePath, fileBytes);
            return BaseResult.Success(fileName);
        }
        catch (Exception ex)
        {
            return BaseResult.Fail(ExceptionUpload);
        }
    }
}













