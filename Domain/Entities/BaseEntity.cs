using Newtonsoft.Json;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}