using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;

namespace IdentityYoutube.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {

            //2nd way data binding -- api to ui
            this.Credential = new Credential { UserName = "admin", Password = "sails" };
        }

        public void OnPost()
        {

        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            if (!ModelState.IsValid) return Page();
            //verifying the credentials
            if (Credential.UserName == "admin" && Credential.Password == "admin")
            {
                //Creating security context  
                /* step 1 : Create claims
                 * step 2 : Link to an identity  and choose an authentication type 
                 * (cookie authentication)
                 * step 3 : Add it to claims principle( princple contains security context)
                 * step 4 : Encypt and serialize security context */

               
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , Credential.UserName),
                    new Claim(ClaimTypes.Email , Credential.UserName+"@gmail.com" ),


                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                // adding a primary identity to the claims principle
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                //Iauthenticationservice interface contains this method
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");



            }
            if (Credential.UserName == "hr" && Credential.Password == "hr")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , Credential.UserName),
                    new Claim("Department","HR" ), //to access hr dashboard.
                    new Claim("Admin" ,"true")    // to access admin dashboard only admin 
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                // adding a primary identity to the claims principle
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                //Iauthenticationservice interface contains this method
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/HR/HrDashboard");


            }
            if (Credential.UserName == "admin" && Credential.Password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , Credential.UserName),
                    new Claim("Admin" ,"true")    // to access admin dashboard only admin 
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                // adding a primary identity to the claims principle
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent= true,
                };

                //Iauthenticationservice interface contains this method
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Admin/AdminDashboard");


            }
            if (Credential.UserName == "admin" && Credential.Password == "hrmanager")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , Credential.UserName),
                    new Claim("Department","HR" ), //to access hr dashboard.
                    new Claim("Manager" ,"true")    // to access settings page in hr  
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                // adding a primary identity to the claims principle
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                //Iauthenticationservice interface contains this method
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/HR/HrDashboard");


            }
            if (Credential.UserName == "hrintern" && Credential.Password == "hrintern")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , Credential.UserName),
                    new Claim("Department","HR" ), //to access hr dashboard.
                    new Claim("Manager" ,"true"),    // to access settings page in hr  
                    new Claim("EmploymentDate", "2023-05-01") // to give access only after pr
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                // adding a primary identity to the claims principle
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                //Iauthenticationservice interface contains this method
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/HR/HrDashboard");


            }
            return BadRequest(ModelState);
           


        }
    }

    public class Credential
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberME { get; set; }
    }
}
