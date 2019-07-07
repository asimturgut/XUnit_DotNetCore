using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFileStorage
    {
        Task StoreFile(IFormFile file, string key);
    }
}
