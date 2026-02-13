using Microsoft.EntityFrameworkCore;
using RoomManagement.Api.Models;

namespace RoomManagement.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    // Mekanisme Inisialisasi Data (Data Seeding) sesuai arahan dosen
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "Andi Ammar", Email = "ammar@pens.ac.id" },
            new Customer { Id = 2, Name = "Budi Santoso", Email = "budi@gmail.com" }
        );
    }
}