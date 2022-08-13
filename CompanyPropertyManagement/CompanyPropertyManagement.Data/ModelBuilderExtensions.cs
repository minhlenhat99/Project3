using CompanyPropertyManagement.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompanyPropertyManagement.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var users = new AppUser[]
            {
                new AppUser { Id = Guid.NewGuid(), UserName = "Employee1" }
            };
            modelBuilder.Entity<AppUser>().HasData(users);

            var roles = new AppRole[]
            {
                new AppRole { Id = Guid.NewGuid(), Name = "Employee", NormalizedName = "EMPLOYEE"},
                new AppRole { Id = Guid.NewGuid(), Name = "Manager", NormalizedName = "MANAGER"}
            };
            modelBuilder.Entity<AppRole>().HasData(roles);

            var bus = new BU[]
            {
                new BU { Id = Guid.NewGuid(), Name = "Unit 1" }
                , new BU { Id = Guid.NewGuid(), Name = "Unit 2" }
                , new BU { Id = Guid.NewGuid(), Name = "Unit 3" }
                , new BU { Id = Guid.NewGuid(), Name = "Unit 4" }
                , new BU { Id = Guid.NewGuid(), Name = "Unit 5" }
            };
            modelBuilder.Entity<BU>().HasData(bus);

            var categories = new Category[]
            {
                new Category { Id = Guid.NewGuid(), Name = "Screen"}
                , new Category { Id = Guid.NewGuid(), Name = "Keyboard" }
                , new Category { Id = Guid.NewGuid(), Name = "Mouse" }
                , new Category { Id = Guid.NewGuid(), Name = "Chair" }
                , new Category { Id = Guid.NewGuid(), Name = "Table" }
            };
            modelBuilder.Entity<Category>().HasData(categories);
            var seatCodes = new SeatCode[]
            {
                new SeatCode {Id = "11.05.058", BuId = bus[0].Id },
                new SeatCode {Id = "11.05.059", BuId = bus[0].Id },
                new SeatCode {Id = "11.05.060", BuId = bus[0].Id },
                new SeatCode {Id = "11.05.061", BuId = bus[0].Id },
                new SeatCode {Id = "11.05.062", BuId = bus[0].Id }
            };
            modelBuilder.Entity<SeatCode>().HasData(seatCodes);

            var properties = new Property[]
            {
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[0].Id, CategoryId = categories[0].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[1].Id, CategoryId = categories[0].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[2].Id, CategoryId = categories[0].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[3].Id, CategoryId = categories[0].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[4].Id, CategoryId = categories[0].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[0].Id, CategoryId = categories[1].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[1].Id, CategoryId = categories[1].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[2].Id, CategoryId = categories[1].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[3].Id, CategoryId = categories[1].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[4].Id, CategoryId = categories[1].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[0].Id, CategoryId = categories[2].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[1].Id, CategoryId = categories[2].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[2].Id, CategoryId = categories[2].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[3].Id, CategoryId = categories[2].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[4].Id, CategoryId = categories[2].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[0].Id, CategoryId = categories[3].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[1].Id, CategoryId = categories[3].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[2].Id, CategoryId = categories[3].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[3].Id, CategoryId = categories[3].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[4].Id, CategoryId = categories[3].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[0].Id, CategoryId = categories[4].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[1].Id, CategoryId = categories[4].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[2].Id, CategoryId = categories[4].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[3].Id, CategoryId = categories[4].Id},
                new Property { Id = Guid.NewGuid(), SeatCodeId = seatCodes[4].Id, CategoryId = categories[4].Id},
            };
            modelBuilder.Entity<Property>().HasData(properties);
        }
    }
}
