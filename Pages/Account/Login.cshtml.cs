using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Csharp3_A1.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Csharp3_A1.Models;

namespace Csharp3_A1.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginInput Input {  get; set; }

        private readonly AccountService _accountService;

        public LoginModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            var user = await _accountService.AuthenticateAsync(Input.Username, Input.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid");
                return Page();
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Username),
                new(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("CookieAuth", principal);

            if (user.Role == "Patient")
            {
                return RedirectToPage("/PatientPages/PatientPortal");
            }
            else
            {
                return RedirectToPage("/StaffPages/StaffDashboard");
            }
        }
    }
}
