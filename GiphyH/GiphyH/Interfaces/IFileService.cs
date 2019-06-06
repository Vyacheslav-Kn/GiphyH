using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GiphyH.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile file);
    }
}
