using System.ComponentModel.DataAnnotations;

namespace LinkteraEgitim.RazorApp.Model
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Stock { get; set; }

    }
}
