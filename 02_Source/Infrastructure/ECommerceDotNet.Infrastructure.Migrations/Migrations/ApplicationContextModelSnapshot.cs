﻿// <auto-generated />
using System;
using ECommerceDotNet.Infrastructure.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceDotNet.Infrastructure.Migrations.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Cart", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SizeOption")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParentComment")
                        .HasColumnType("int");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Discount", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("Percent")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<short>("Rating")
                        .HasColumnType("smallint");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductCart", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("CartId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SizeOption")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ProductId", "CartId");

                    b.HasIndex("CartId");

                    b.ToTable("ProductCart");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductCategory", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("CategoryId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductCollection", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("CollectionId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<int>("CollectionId1")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CollectionId");

                    b.HasIndex("CollectionId1");

                    b.ToTable("ProductCollection");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductComment", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("CommentId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<int>("CommentId1")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CommentId");

                    b.HasIndex("CommentId1");

                    b.ToTable("ProductComments");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductDiscount", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("DiscountId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("ProductId", "DiscountId");

                    b.HasIndex("DiscountId");

                    b.ToTable("ProductDiscount");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductSizeOption", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("Size")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(1);

                    b.HasKey("ProductId", "Size");

                    b.HasIndex("Size");

                    b.ToTable("ProductSizeOption");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductSupplier", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("SupplierId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("ProductId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ProductSupplier");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.SizeOption", b =>
                {
                    b.Property<string>("Size")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantitySold")
                        .HasColumnType("int");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.HasKey("Size");

                    b.ToTable("SizeOption");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Supplier", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("SecurityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserCart", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("CartId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "CartId");

                    b.HasIndex("CartId");

                    b.ToTable("UserCart");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserCollection", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("CollectionId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<int>("CollectionId1")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CollectionId");

                    b.HasIndex("CollectionId1");

                    b.ToTable("UserCollection");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserComment", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("CommentId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "CommentId");

                    b.HasIndex("CommentId");

                    b.ToTable("UserComment");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserOrder", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("UserOrder");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserPayment", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("PaymentId")
                        .HasMaxLength(450)
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "PaymentId");

                    b.HasIndex("PaymentId");

                    b.ToTable("UserPayment");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("RoleId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Payment", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Order", null)
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductCart", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Cart", "Cart")
                        .WithMany("ProductCarts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductCategory", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Product", "Product")
                        .WithMany("ProductCategorys")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductCollection", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Collection", "Collection")
                        .WithMany("ProductCollections")
                        .HasForeignKey("CollectionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductComment", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Comment", "Comment")
                        .WithMany("ProductComments")
                        .HasForeignKey("CommentId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Product", "Product")
                        .WithMany("ProductComments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductDiscount", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Discount", "Discount")
                        .WithMany("ProductDiscounts")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Product", "Product")
                        .WithMany("ProductDiscounts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductSizeOption", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.SizeOption", "SizeOption")
                        .WithMany("ProductSizeOptions")
                        .HasForeignKey("Size")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SizeOption");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.ProductSupplier", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Product", "Product")
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Supplier", "Supplier")
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserCart", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Cart", "Cart")
                        .WithMany("UserCarts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.User", "User")
                        .WithMany("UserCarts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserCollection", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Collection", "Collection")
                        .WithMany("UserCollections")
                        .HasForeignKey("CollectionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.User", "User")
                        .WithMany("UserCollections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserComment", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Comment", "Comment")
                        .WithMany("UserComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.User", "User")
                        .WithMany("UserComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserOrder", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Order", "Order")
                        .WithMany("UserOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.User", "User")
                        .WithMany("UserOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserPayment", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Payment", "Payment")
                        .WithMany("UserPayments")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.User", "User")
                        .WithMany("UserPayments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.UserRole", b =>
                {
                    b.HasOne("ECommerceDotNet.Core.Domain.Models.Role", "Role")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceDotNet.Core.Domain.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Cart", b =>
                {
                    b.Navigation("ProductCarts");

                    b.Navigation("UserCarts");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Collection", b =>
                {
                    b.Navigation("ProductCollections");

                    b.Navigation("UserCollections");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Comment", b =>
                {
                    b.Navigation("ProductComments");

                    b.Navigation("UserComments");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Discount", b =>
                {
                    b.Navigation("ProductDiscounts");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Order", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("UserOrders");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Payment", b =>
                {
                    b.Navigation("UserPayments");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Product", b =>
                {
                    b.Navigation("ProductCategorys");

                    b.Navigation("ProductComments");

                    b.Navigation("ProductDiscounts");

                    b.Navigation("ProductSuppliers");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Role", b =>
                {
                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.SizeOption", b =>
                {
                    b.Navigation("ProductSizeOptions");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.Supplier", b =>
                {
                    b.Navigation("ProductSuppliers");
                });

            modelBuilder.Entity("ECommerceDotNet.Core.Domain.Models.User", b =>
                {
                    b.Navigation("UserCarts");

                    b.Navigation("UserCollections");

                    b.Navigation("UserComments");

                    b.Navigation("UserOrders");

                    b.Navigation("UserPayments");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
