using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using GiphyH.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace GiphyH.Services
{
    public class RemoteFileService : IFileService
    {
        private readonly Cloudinary _cloudinary;

        public RemoteFileService(IConfiguration config)
        {
            Account account = new Account(
                cloud: config["CloudinaryCredentials:CloudName"],
                apiKey: config["CloudinaryCredentials:ApiKey"],
                apiSecret: config["CloudinaryCredentials:ApiSecret"]
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            MemoryStream fileStream = new MemoryStream();
            await file.CopyToAsync(fileStream);
            fileStream.Position = 0;

            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("fileName", fileStream),
                UseFilename = false
            };

            ImageUploadResult uploadResult = _cloudinary.Upload(uploadParams);
            string filePath = uploadResult.SecureUri.AbsoluteUri;

            return filePath;
        }
    }
}
