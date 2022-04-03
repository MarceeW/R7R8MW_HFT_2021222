using Microsoft.EntityFrameworkCore;
using R7R8MW_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Repository
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<RentEvent> RentEvents { get; set; }

        public CarDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Car.mdf;Integrated Security=True;MultipleActiveResultSet=True";
                dbContextOptionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(x => x.Cars)
                .WithOne(x => x.Brand);

            modelBuilder.Entity<Car>()
                .HasMany(x => x.RentEvents)
                .WithOne(x => x.Car)
                .HasForeignKey(x => x.RentEventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasOne(x => x.Brand)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RentEvent>()
                .HasOne(x => x.Car)
                .WithMany(x => x.RentEvents)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand("1#Aston Martin#47000000"),
                new Brand("2#BMW#2300000"),
                new Brand("3#Mercedes#2400000"),
                new Brand("4#Opel#1700000")
            });

            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new Car("1#1"),
                new Car("2#1"),
                new Car("3#2")
            });

            modelBuilder.Entity<RentEvent>().HasData(new RentEvent[]
            {
                new RentEvent("1#20180916 11:02#13#1"),
                new RentEvent("2#20200613 13:25#34#2"),
                new RentEvent("3#20200723 12:50#41#2"),
                new RentEvent("4#20180917 10:15#25#1"),
                new RentEvent("5#20211007 07:56#302#3"),
                new RentEvent("6#20211010 07:43#244#3"),
            });
        }
    }
}
