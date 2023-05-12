using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityYoutube.Pages.Admin
{
    [Authorize(Policy ="AdminONLY")]
    public class AdminDashboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
