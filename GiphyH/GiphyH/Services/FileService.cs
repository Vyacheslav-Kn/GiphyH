using GiphyH.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace GiphyH.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileService(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            string fileName = Path.GetRandomFileName();
            string filePath = $"{_hostingEnvironment.WebRootPath}\\gifs\\{fileName}.jpg";

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return filePath;
        }
    }
}
