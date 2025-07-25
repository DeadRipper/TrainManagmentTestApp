using Microsoft.EntityFrameworkCore;
using TrainComponentManagementAPI.TrainManagmentDTO;

namespace TrainComponentManagementAPI.TrainManagmentDB
{
    public class TrainDbContext : DbContext
    {
        public TrainDbContext(DbContextOptions<TrainDbContext> options)
            : base(options) { }

        public DbSet<TrainComponent> Components { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TrainComponent>()
            //    .Property(c => c.Quantity)
            //    .HasDefaultValue(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainComponent>().HasData(
                new TrainComponent { Id = 1, Name = "Engine", UniqueNumber = "ENG123", CanAssignQuantity = "No" },
                new TrainComponent { Id = 2, Name = "Passenger Car", UniqueNumber = "PAS456", CanAssignQuantity = "No" },
                new TrainComponent { Id = 3, Name = "Freight Car", UniqueNumber = "FRT789", CanAssignQuantity = "No" },
                new TrainComponent { Id = 4, Name = "Wheel", UniqueNumber = "WHL101", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 5, Name = "Seat", UniqueNumber = "STS234", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 6, Name = "Window", UniqueNumber = "WIN567", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 7, Name = "Door", UniqueNumber = "DR123", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 8, Name = "Control Panel", UniqueNumber = "CTL987", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 9, Name = "Light", UniqueNumber = "LGT456", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 10, Name = "Brake", UniqueNumber = "BRK789", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 11, Name = "Bolt", UniqueNumber = "BLT321", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 12, Name = "Nut", UniqueNumber = "NUT654", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 13, Name = "Engine Hood", UniqueNumber = "EH789", CanAssignQuantity = "No" },
                new TrainComponent { Id = 14, Name = "Axle", UniqueNumber = "AX456", CanAssignQuantity = "No" },
                new TrainComponent { Id = 15, Name = "Piston", UniqueNumber = "PST789", CanAssignQuantity = "No" },
                new TrainComponent { Id = 16, Name = "Handrail", UniqueNumber = "HND234", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 17, Name = "Step", UniqueNumber = "STP567", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 18, Name = "Roof", UniqueNumber = "RF123", CanAssignQuantity = "No" },
                new TrainComponent { Id = 19, Name = "Air Conditioner", UniqueNumber = "AC789", CanAssignQuantity = "No" },
                new TrainComponent { Id = 20, Name = "Flooring", UniqueNumber = "FLR456", CanAssignQuantity = "No" },
                new TrainComponent { Id = 21, Name = "Mirror", UniqueNumber = "MRR789", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 22, Name = "Horn", UniqueNumber = "HRN321", CanAssignQuantity = "No" },
                new TrainComponent { Id = 23, Name = "Coupler", UniqueNumber = "CPL654", CanAssignQuantity = "No" },
                new TrainComponent { Id = 24, Name = "Hinge", UniqueNumber = "HNG987", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 25, Name = "Ladder", UniqueNumber = "LDR456", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 26, Name = "Paint", UniqueNumber = "PNT789", CanAssignQuantity = "No" },
                new TrainComponent { Id = 27, Name = "Decal", UniqueNumber = "DCL321", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 28, Name = "Gauge", UniqueNumber = "GGS654", CanAssignQuantity = "Yes" },
                new TrainComponent { Id = 29, Name = "Battery", UniqueNumber = "BTR987", CanAssignQuantity = "No" },
                new TrainComponent { Id = 30, Name = "Radiator", UniqueNumber = "RDR456", CanAssignQuantity = "No" }
            );
        }
    }
}