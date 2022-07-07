using LinkteraEgitim.RazorApp.Data;
using LinkteraEgitim.RazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LinkteraEgitim.RazorApp.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Product Product { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(Guid id)
        {
            Product = _context.Products.FirstOrDefault(b => b.Id == id);
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is not null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Ürün silindi";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
