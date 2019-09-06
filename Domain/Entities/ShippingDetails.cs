using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "What is your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insert first delivery address")]
        [Display(Name = "First delivery address")]
        public string Line1 { get; set; }
        [Display(Name = "Second delivery address")]
        public string Line2 { get; set; }
        [Display(Name = "Third delivery address")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Choose the city")]
        [Display(Name = "The city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Choose the county")]
        [Display(Name = "The counry")]
        public string Country { get; set; }
    }
}
