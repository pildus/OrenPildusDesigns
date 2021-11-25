﻿// <auto-generated />
using System;
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

                    b.Property<int>("InentoryItemQuantity")
                        .HasColumnType("int");

                    b.Property<int>("InventoryItemProductID")
                        .HasColumnType("int");

                    b.Property<double>("InventoryItemSpecialPrice")
                        .HasColumnType("float");

                    b.HasKey("InventoryItemID");

                    b.HasIndex("InventoryItemProductID")
                        .IsUnique();

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("DataControl.Model.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InventoryItemID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderInventoryItemID")
                        .HasColumnType("int");

                    b.Property<bool>("OrderIsConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("int");

                    b.Property<double>("OrderTotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("OrderUserID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("InventoryItemID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataControl.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EffectType")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataControl.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataControl.Model.Board", b =>
                {
                    b.HasBaseType("DataControl.Model.Product");

                    b.Property<double>("BoardHeight")
                        .HasColumnType("float");

                    b.Property<double>("BoardWidth")
                        .HasColumnType("float");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("DataControl.Model.Component", b =>
                {
                    b.HasBaseType("DataControl.Model.Product");

                    b.Property<int>("ComponentType")
                        .HasColumnType("int");

                    b.Property<int>("QuantityPerLot")
                        .HasColumnType("int");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("DataControl.Model.Pedal", b =>
                {
                    b.HasBaseType("DataControl.Model.Product");

                    b.Property<string>("PedalDescription")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Pedals");
                });

            modelBuilder.Entity("DataControl.Model.Order", b =>
                {
                    b.HasOne("DataControl.Model.InventoryItem", "InventoryItem")
                        .WithMany()
                        .HasForeignKey("InventoryItemID");

                    b.HasOne("DataControl.Model.User", "User")
                        .WithMany("ShoppingCart")
                        .HasForeignKey("UserID");

                    b.Navigation("InventoryItem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataControl.Model.Board", b =>
                {
                    b.HasOne("DataControl.Model.Product", null)
                        .WithOne()
                        .HasForeignKey("DataControl.Model.Board", "ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataControl.Model.Component", b =>
                {
                    b.HasOne("DataControl.Model.Product", null)
                        .WithOne()
                        .HasForeignKey("DataControl.Model.Component", "ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataControl.Model.Pedal", b =>
                {
                    b.HasOne("DataControl.Model.Product", null)
                        .WithOne()
                        .HasForeignKey("DataControl.Model.Pedal", "ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataControl.Model.User", b =>
                {
                    b.Navigation("ShoppingCart");
                });
#pragma warning restore 612, 618
        }
    }
}
