namespace TrainComponentManagementAPI.TrainManagmentDTO
{
    public class TrainComponent
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UniqueNumber { get; set; } = null!;
        public string CanAssignQuantity { get; set; } = null!;
        public int? Quantity { get; set; } // Nullable, only for assignable items
    }
}