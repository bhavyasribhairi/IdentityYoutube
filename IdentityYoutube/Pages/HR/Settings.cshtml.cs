using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityYoutube.Pages.HR
{
    [Authorize(Policy ="HRManagerONLY")]
    public class SettingsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
