using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebConcurrentDictionary.DTO;
using WebConcurrentDictionary.Interfaces;
using WebConcurrentDictionary.Model;

namespace WebConcurrentDictionary.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class ConcurrentController : ControllerBase
    {
        private readonly ICacheContextService _cacheContextService;
        private readonly IAuthenticationContentService _authenticationContentService;

        public ConcurrentController(ICacheContextService cacheContextService, IAuthenticationContentService authenticationContentService)
        {
            _cacheContextService = cacheContextService;
            _authenticationContentService = authenticationContentService;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserCacheAddDTQ userCacheAddQuery)
        {
            UserLogin userLogin = await this._cacheContextService.GetOrAdd<UserLogin>("login", () => { return this._authenticationContentService.Login(userCacheAddQuery); });
            return Ok(userLogin);
        }
    }
}