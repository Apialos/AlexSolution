using System;
using System.ComponentModel.DataAnnotations;

namespace MyGallery.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; }
    }
}
