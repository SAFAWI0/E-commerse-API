namespace project.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Collection of Products
        public ICollection<Product> Products { get; set; }

    }
}
