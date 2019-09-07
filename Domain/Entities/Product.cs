using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Price")]
        public decimal Price { get; set; }
        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}