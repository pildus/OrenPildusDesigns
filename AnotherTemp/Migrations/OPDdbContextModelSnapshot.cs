﻿// <auto-generated />
using DataControl.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataControl.Migrations
{
    [DbContext(typeof(OPDdbContext))]
    partial class OPDdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataControl.Model.InventoryItem", b =>
                {
                    b.Property<int>("InventoryItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("InventoryItemPrice")
                        .HasColumnType("real");

                    b.Property<int>("InventoryItemProductID")
                        .HasColumnType("int");

                    b.HasKey("InventoryItemID");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("DataControl.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ProductPrice")
                        .HasColumnType("real");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("DataControl.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataControl.Model.UserPermission", b =>
                {
                    b.Property<int>("UserPermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("UserPermissionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserPermissionID");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("DataControl.Model.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("DataControl.Model.Board", b =>
                {
                    b.HasBaseType("DataControl.Model.Product");

                    b.Property<int>("BoardEffectType")
                        .HasColumnType("int");

                    b.Property<int>("BoardHeight")
                        .HasColumnType("int");

                    b.Property<int>("BoardWidth")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Board");
                });

            modelBuilder.Entity("DataControl.Model.Pedal", b =>
                {
                    b.HasBaseType("DataControl.Model.Product");

                    b.Property<int>("PedalEffectType")
                        .HasColumnType("int");

                    b.Property<string>("Pedal_Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Pedal");
                });
#pragma warning restore 612, 618
        }
    }
}
