using System.Text.Json.Serialization;

namespace TrainComponentManagementAPI.TrainManagmentDTO
{
    public class AssignQuantity
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}