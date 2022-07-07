using LinkteraEgitim.RazorApp.Data;
using LinkteraEgitim.RazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LinkteraEgitim.RazorApp.Pages.Products
{
    public class UpdateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Product Product { get; set; }

        public UpdateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(Guid id)
        {
            Product = _context.Products.FirstOrDefault(b => b.Id == id);
        }

        public async Task<IActionResult> OnPost(Product product)
        {
            if (product is not null)
            {
                if (product.Name.Length > 10)
                {
                    ModelState.AddModelError("UpdateError", "Ürün ismi 10 karaktarden fazla olamaz.");
                }

                if (ModelState.IsValid)
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }
    }
}
