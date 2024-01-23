using System.Threading.Tasks;
using WebConcurrentDictionary.DTO;
using WebConcurrentDictionary.Model;

namespace WebConcurrentDictionary.Interfaces
{
    public interface IAuthenticationContentService
    {
        Task<UserLogin> Login(UserCacheAddDTQ userCacheAddQuery);
    }
}