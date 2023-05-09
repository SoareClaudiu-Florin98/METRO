﻿// <auto-generated />
using System;
using METROAssignment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace METROAssignment.Database.Migrations
{
    [DbContext(typeof(MetroDbContext))]
    [Migration("20230508142225_AddInitialMigration")]
    partial class AddInitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("METROAssignment.Domain.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Article", "dbo");
                });

            modelBuilder.Entity("METROAssignment.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer", "dbo");
                });

            modelBuilder.Entity("METROAssignment.Domain.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Payment", "dbo");
                });

            modelBuilder.Entity("METROAssignment.Domain.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transaction", "dbo");
                });

            modelBuilder.Entity("METROAssignment.Domain.Models.TransactionArticles", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "TransactionId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionArticles", "dbo");
                });

            modelBuilder.Entity("METROAssignment.Domain.Models.TransactionArticles", b =>
                {
                    b.HasOne("METROAssignment.Domain.Models.Article", "Article")
                        .WithMany("TransactionArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("METROAssignment.Domain.Models.Transaction", "Transaction")
                        .WithMany("TransactionArticles")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("METROAssignment.Domain.Models.Article", b =>
                {
                    b.Navigation("TransactionArticles");
                });

            modelBuilder.Entity("METROAssignment.Domain.Models.Transaction", b =>
                {
                    b.Navigation("TransactionArticles");
                });
#pragma warning restore 612, 618
        }
    }
}
