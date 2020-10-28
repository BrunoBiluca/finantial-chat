using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChatAPI.Authentication {
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly SignInManager<ChatUser> _signInManager;
        private readonly ILogger _logger;

        public AuthController(
                    SignInManager<ChatUser> signInManager,
                    ILogger<RegisterController> logger) {
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(ChatUserLoginModel model) {
            if(ModelState.IsValid) {
                var result = await _signInManager.PasswordSignInAsync(model.Name, model.Password, true, lockoutOnFailure: false);
                if(result.Succeeded) {
                    _logger.LogInformation("User logged in.");
                    return Ok(result);
                }
                if(result.IsLockedOut) {
                    _logger.LogWarning("User account locked out.");
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Unauthorized(ModelState.Values);
                } else {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Unauthorized(ModelState.Values);
                }
            }
            return BadRequest(ModelState.Values);
        }
    }
}