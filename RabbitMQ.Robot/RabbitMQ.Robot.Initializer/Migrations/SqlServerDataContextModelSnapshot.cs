﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RabbitMQ.Robot.Initializer.DataContexts;

namespace RabbitMQ.Robot.Initializer.Migrations
{
    [DbContext(typeof(SqlServerDataContext))]
    partial class SqlServerDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RabbitMQ.Robot.Domain.BrowserInformation", b =>
                {
                    b.Property<string>("PageName");

                    b.Property<string>("Ip");

                    b.Property<string>("BrowserName");

                    b.HasKey("PageName", "Ip");

                    b.ToTable("BrowserInformation");
                });

            modelBuilder.Entity("RabbitMQ.Robot.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desc");

                    b.Property<decimal>("Price");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("RabbitMQ.Robot.Domain.Purchase", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("ProductId");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Purhcase");
                });

            modelBuilder.Entity("RabbitMQ.Robot.Domain.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<long>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RabbitMQ.Robot.Domain.Purchase", b =>
                {
                    b.HasOne("RabbitMQ.Robot.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RabbitMQ.Robot.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
