using System.Text.Json.Serialization;

namespace TrainComponentManagementAPI.TrainManagmentDTO
{
    public class TrainComponent
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Name { get; set; }
        [JsonPropertyName("uniqueNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string UniqueNumber { get; set; }
        [JsonPropertyName("canAssignQuantity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string CanAssignQuantity { get; set; }
        [JsonPropertyName("quantity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int? Quantity { get; set; } // Nullable, only for assignable items
    }
}