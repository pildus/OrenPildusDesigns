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
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Order> Orders { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                // * * Local SQLServer DB
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=OrenPildusDesignsDB;Trusted_Connection=True;MultipleActiveResultSets=true");
                
                
                // * * Online hosted SQLServer DB * * //
                // * * In case the local DB fails to work uncomment this connection string:
                //optionsBuilder.UseSqlServer("Server=SQL5080.site4now.net; Initial Catalog = db_a7c69f_pildus; User Id = db_a7c69f_pildus_admin; Password =Leviha2016!");
                

            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Verify a unique usage of an email address in sign up
            builder.Entity<User>()
                .HasIndex(u => u.EmailAddress)
                .IsUnique();

            // Verify new sign up does not gran administator permissions
            builder.Entity<User>()
            .Property("IsAdmin")
            .HasDefaultValue(false);

            // Define relations of User's shopping cart object
            builder.Entity<Order>()
           .HasOne<User>(s => s.User)
           .WithMany(g => g.ShoppingCart);

        }


    }
}
