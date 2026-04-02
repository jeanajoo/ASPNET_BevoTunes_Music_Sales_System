using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public enum ProductType { Hat, Pants, Sweatshirt, Tank, TShirt, Others }
    public class Product
    {
        public Int32 ProductID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public String Name { get; set; }
        [Display(Name = "Product Description")]
        public String? Description { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Price { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public ProductType Type { get; set; }

    }
}