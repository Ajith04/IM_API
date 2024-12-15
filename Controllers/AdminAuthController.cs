using ITEC_API.DTO.RequestDTO;
using ITEC_API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly IAdminAuthService _iAdminAuthService;

        public AdminAuthController(IAdminAuthService iAdminAuthService)
        {
            _iAdminAuthService = iAdminAuthService;
        }

        [HttpGet ("get-all-roles")]
        public async Task<IActionResult> getAllRoles()
        {
            var roles = await _iAdminAuthService.getAllRoles();
            return Ok(roles);
        }

        [HttpPost ("add-account")]
        public async Task<IActionResult> addAccount(RegisterAccounRequest registerAccountRequest)
        {
            await _iAdminAuthService.addAccount(registerAccountRequest);
            return Ok();
        }

        [HttpGet ("get-all-accounts")]
        public async Task<IActionResult> getAllAccounts()
        {
            var allAccounts = await _iAdminAuthService.getAllAccounts();
            return Ok(allAccounts);
        }

        [HttpPatch ("add-password")]
        public async Task<IActionResult> addPassword(PasswordRequest passwordRequest)
        {
            await _iAdminAuthService.addPassword(passwordRequest);
            return Ok();
        }

        [HttpPost ("login")]
        public async Task<IActionResult> login(loginRequest loginRequest)
        {
            var token = await _iAdminAuthService.login(loginRequest);
            return Ok(token);
        }

    }
}
