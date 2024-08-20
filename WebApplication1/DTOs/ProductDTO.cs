using System.ComponentModel.DataAnnotations.Schema;

namespace project.DTOs
{
    public class ProductDTO
    {
  
        public string Title { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public int CategorieId { get; set; }

    }
}
