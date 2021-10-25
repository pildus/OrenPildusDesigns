using AnotherTemp.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherTemp.DataAccess
{
    class OPDdbContext
    {
    }
}

namespace CodeFirstDemo.DataAccess
{
    public class BlogDbContext : DbContext
    {
        //public DbSet<Post> Posts { get; set; }
        //public DbSet<Fluent_Post> Fluent_Posts { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Fluent_Comment> Fluent_Comments { get; set; }
        //public DbSet<PostDetail> PostDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Pedal> Pedals { get; set; }
        public DbSet<Board> Boards { get; set; }


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
