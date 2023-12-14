using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace iBrokerage.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }
    }
}
