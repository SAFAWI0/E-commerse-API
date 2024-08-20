using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        // Foreign Key for Categorie
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }




    }
}
