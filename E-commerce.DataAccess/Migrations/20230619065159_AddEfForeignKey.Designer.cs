﻿// <auto-generated />
using E_commerce.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_commerce.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230619065159_AddEfForeignKey")]
    partial class AddEfForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_commerce.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "SciFi"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "History"
                        });
                });

            modelBuilder.Entity("E_commerce.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "A. P. J. Abdul Kalam\r\n",
                            CategoryId = 1,
                            Description = "‘Failure will never overtake me if my determination to succeed is strong enough.’ Oftentimes, our desire to succeed doesn’t account for the failure, when in fact, failing at something can teach us the most about how to succeed.",
                            ISBN = "SWD9999001",
                            ListPrice = 99.0,
                            Price = 90.0,
                            Price100 = 80.0,
                            Price50 = 85.0,
                            Title = "Failure is a Teacher"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Norman Vincent Peale",
                            CategoryId = 1,
                            Description = "It is a practical, direct-action application of spiritual techniques to overcome defeat and win confidence, success, and joy. Norman Vincent Peale, the father of positive thinking and one of the most widely read inspirational writers of all time, shares his famous formula of faith and optimism which millions of people have taken as their own simple and effective philosophy of living.",
                            ISBN = "CAW777777701",
                            ListPrice = 40.0,
                            Price = 30.0,
                            Price100 = 20.0,
                            Price50 = 25.0,
                            Title = "The Power of Positive Thinking"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Dale Carnegie",
                            CategoryId = 1,
                            Description = "This book explores the nature of stress and how it infiltrates every level of your life, including the physical, emotional, cognitive, relational, and even spiritual. Through techniques that get to the heart of your unique stress response and an exploration of how stress can affect your relationships, you will discover how to control stress instead of letting it control you.",
                            ISBN = "RITO5555501",
                            ListPrice = 55.0,
                            Price = 50.0,
                            Price100 = 35.0,
                            Price50 = 40.0,
                            Title = "How to Stop Worrying and Start Living"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Claude M Bristol ",
                            CategoryId = 2,
                            Description = "This book shows you how you become what you contemplate, why hard work alone will not bring success, how to bring the subconscious into practical action, how to turn your thoughts into achievements, and how belief makes things happen",
                            ISBN = "WS3333333301",
                            ListPrice = 70.0,
                            Price = 65.0,
                            Price100 = 55.0,
                            Price50 = 60.0,
                            Title = "The Magic of Believing"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Joseph Murphy",
                            CategoryId = 2,
                            Description = "In this book, the author fuses his spiritual wisdom and scientific research to bring to light how the subconscious mind can be a major influence on our daily lives. Once you understand your subconscious mind, you can also control or get rid of the various phobias that you may have in turn opening a brand new world of positive energy.",
                            ISBN = "SOTJ1111111101",
                            ListPrice = 30.0,
                            Price = 27.0,
                            Price100 = 20.0,
                            Price50 = 25.0,
                            Title = "The Power of Your Subconscious Mind"
                        });
                });

            modelBuilder.Entity("E_commerce.Models.Product", b =>
                {
                    b.HasOne("E_commerce.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}