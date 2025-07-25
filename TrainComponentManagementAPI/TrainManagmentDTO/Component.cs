namespace TrainComponentManagementAPI.TrainManagmentDTO
{
    public class Component
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UniqueNumber { get; set; }
        public string CanAssignQuantity { get; set; } = null!;
        public int? Quantity { get; set; }
    }
}