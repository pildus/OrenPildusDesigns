using DataControl.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl.DataAccess
{

    public class OPDdbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<InventoryItem> Inventory { get; set; }
        public DbSet<Pedal> Pedals { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=OrenPildusDesignsDB;Trusted_Connection=True;MultipleActiveResultSets=true");
                // optionsBuilder.UseSqlServer("Server=SQL5102.site4now.net;Initial Catalog=db_a7c69f_pildus;User Id=db_a7c69f_pildus_admin;Password=Leviha2016!");
                // .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.EmailAddress)
                .IsUnique();

            builder.Entity<InventoryItem>()
                .HasIndex(i => i.InventoryItemProductID)
                .IsUnique();

            builder.Entity<User>()
            .Property("IsAdmin")
            .HasDefaultValue(false);

            builder.Entity<Order>()
           .HasOne<User>(s => s.User)
           .WithMany(g => g.ShoppingCart);


            //builder.Entity<User>().HasMany(u => u.ShoppingCart);



        }


    }
}
