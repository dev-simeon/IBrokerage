using Gibs.Portal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gibs.Portal.Pages.Market
{
    public class CheckoutModel(PaystackService paystackService) : PageModel
    {
        private readonly PaystackService _paystackService = paystackService;

        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPostInitializePaymentAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var callbackUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/PaymentComplete";
                    var result = await _paystackService.InitializeTransaction("omomowosymeon45@gmail.com", , callbackUrl);

                    return Redirect(result.AuthorizationUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return Page();
        }
    }
}