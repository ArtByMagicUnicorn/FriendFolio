using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friendfolio.Pages.Account;

public class LoginModel : PageModel
{
    public IActionResult OnPost(string? returnUrl = null)
    {
        var redirectUrl = Url.Page("/Index");

        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            redirectUrl = returnUrl;
        }

        var properties = new AuthenticationProperties
        {
            RedirectUri = redirectUrl
        };

        return Challenge(properties, "Google");
    }
}