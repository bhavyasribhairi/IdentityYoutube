using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityYoutube.Pages.HR
{
    [Authorize(Policy = "MustBelongToHRDepartment")]
    public class HrDashboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
