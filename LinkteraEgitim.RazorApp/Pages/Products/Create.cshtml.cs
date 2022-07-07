using LinkteraEgitim.RazorApp.Data;
using LinkteraEgitim.RazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkteraEgitim.RazorApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Product Product { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Product product)
        {
            if (product.Name.Length > 10)
            {
                ModelState.AddModelError(String.Empty, "Ürün ismi 10 karaktarden fazla olamaz.");
            }

            if (ModelState.IsValid)
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
