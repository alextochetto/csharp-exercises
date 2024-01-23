using System.Threading.Tasks;
using WebConcurrentDictionary.DTO;
using WebConcurrentDictionary.Interfaces;
using WebConcurrentDictionary.Model;

namespace WebConcurrentDictionary.Services
{
    public class AuthenticationContentService : IAuthenticationContentService
    {
        public async Task<UserLogin> Login(UserCacheAddDTQ userCacheAdd)
        {
            return await Task.FromResult(new UserLogin { Login = userCacheAdd.Login });
        }
    }
}
