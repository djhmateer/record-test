using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        // there may not be a return url
        //public string? ReturnUrl { get; set; }

        //[TempData]
        //// there may b
        //public string? ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            Log.Information(returnUrl);
            // not sure when ErrorMessage is used
            //if (!string.IsNullOrEmpty(ErrorMessage))
            //{
            //    ModelState.AddModelError(string.Empty, ErrorMessage);
            //}

            //ReturnUrl = returnUrl;
        }

        //public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        // Input property of type InputModel is bound because of the [BindProperty] attribute
        public IActionResult OnPost(string returnUrl = null)
        {
            //ReturnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                //var user = await AuthenticateUser(conn, Input.Email, Input.Password);
                Log.Information($"{Input}");

                //Log.Information($"User {user.Email} CDRole: {user.CDRole} logged in at {DateTime.UtcNow}");

                // creates a 302 Found which then redirects to the resource
                return LocalRedirect(returnUrl ?? "/");
            }

            // Something failed. Redisplay the form.
            return Page();
        }
    }
}
