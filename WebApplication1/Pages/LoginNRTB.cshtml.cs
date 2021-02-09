using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace WebApplication1.Pages
{
    public class LoginModelNRTB : PageModel
    {
        [BindProperty]
        // there will never be an InputModel on get
        // but if we set to nullable InputModel then the cshtml will produce dereference warnings
        // https://stackoverflow.com/a/54973095/26086
        // so this will get rid of the warnings as we are happy we will never get dereferences on the front
        // ie we are happy the underlying framework will not produce null reference exceptions
        public InputModel Input { get; set; } = null!;


        // 1. Original Class which works
        //public class InputModel
        //{
        //    // don't need required as Email property is non nullable
        //    //[Required]
        //    // makes sure a regex fires to be in the correct email address form
        //    [EmailAddress]
        //    // there should always be an email posted, but maybe null if js validator doesn't fire
        //    // we are happy the underlying framework handles it, 
        //    public string Email { get; set; } = null!;

        //    // When the property is called Password we don't need a [DataType(DataType.Password)]
        //    //[DataType(DataType.Password)]
        //    public string Password { get; set; } = null!;

        //    [Display(Name = "Remember me?")]
        //    public bool RememberMe { get; set; }
        //}

        // 2. Record which works
        //public record InputModel
        //{
        //    [EmailAddress]
        //    public string Email { get; init; } = null!;

        //    [DataType(DataType.Password)]
        //    public string PasswordB { get; init; } = null!;

        //    [Display(Name = "Remember me?")]
        //    public bool RememberMe { get; init; }
        //}

        // 3. Positional record attributes not being picked up
        public record InputModel(
            string Email,
            [DataType(DataType.Password)] string PasswordB,
            [Display(Name = "Remember me?")] bool RememberMe);


        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Input property of type InputModel is bound because of the [BindProperty] attribute
                Log.Information($"Success! {Input}");
                return LocalRedirect("/");
            }

            Log.Information($"Failure on ModelState validation {Input}");
            return Page();
        }
    }
}
