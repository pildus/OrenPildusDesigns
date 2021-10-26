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
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserType> UserTypes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=OrenPildusDesignsDB;Trusted_Connection=True;MultipleActiveResultSets=true");
                // .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

            }
        }


    }
}
