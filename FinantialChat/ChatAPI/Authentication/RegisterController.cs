using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ChatAPI.Authentication {
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase {

        private readonly UserManager<ChatUser> _userManager;
        private readonly SignInManager<ChatUser> _signInManager;
        private readonly ILogger _logger;

        public RegisterController(
                    UserManager<ChatUser> userManager,
                    SignInManager<ChatUser> signInManager,
                    ILogger<RegisterController> logger) {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        private void AddErrors(IdentityResult result) {
            foreach(var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] ChatUserLoginModel model) {
            if(ModelState.IsValid) {
                var user = new ChatUser { UserName = model.Name };
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded) {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return Ok(user);
                }
                AddErrors(result);
            }

            return BadRequest(ModelState.Values);
        }

    }
}