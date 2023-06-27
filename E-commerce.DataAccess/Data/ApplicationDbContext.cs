
using E_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace E_commerce.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }          

        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );

            modelBuilder.Entity<Company>().HasData(
           new Company { Id = 1, Name = "Tcs", StreetAddress="123 TCS St",City="Pune",PostalCode="444502", State="Maharashtra",PhoneNumber="9876543210"},
           new Company { Id = 2, Name = "Infosys", StreetAddress = "123 Infosys St", City = "Akola", PostalCode = "444501", State = "Maharashtra", PhoneNumber = "976543210" },
           new Company { Id = 3, Name = "Capgemini", StreetAddress = "123 Capgemini St", City = "Pune", PostalCode = "444502", State = "Maharashtra", PhoneNumber = "9654321012" }
           );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Title = "Failure is a Teacher",
                    Author = "A. P. J. Abdul Kalam\r\n",
                    Description = "‘Failure will never overtake me if my determination to succeed is strong enough.’ Oftentimes, our desire to succeed doesn’t account for the failure, when in fact, failing at something can teach us the most about how to succeed.",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId=1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 2,
                    Title = "The Power of Positive Thinking",
                    Author = "Norman Vincent Peale",
                    Description = "It is a practical, direct-action application of spiritual techniques to overcome defeat and win confidence, success, and joy. Norman Vincent Peale, the father of positive thinking and one of the most widely read inspirational writers of all time, shares his famous formula of faith and optimism which millions of people have taken as their own simple and effective philosophy of living.",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl=""
                },
                new Product
                {
                    Id = 3,
                    Title = "How to Stop Worrying and Start Living",
                    Author = "Dale Carnegie",
                    Description = "This book explores the nature of stress and how it infiltrates every level of your life, including the physical, emotional, cognitive, relational, and even spiritual. Through techniques that get to the heart of your unique stress response and an exploration of how stress can affect your relationships, you will discover how to control stress instead of letting it control you.",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 4,
                    Title = "The Magic of Believing",
                    Author = "Claude M Bristol ",
                    Description = "This book shows you how you become what you contemplate, why hard work alone will not bring success, how to bring the subconscious into practical action, how to turn your thoughts into achievements, and how belief makes things happen",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "The Power of Your Subconscious Mind",
                    Author = "Joseph Murphy",
                    Description = "In this book, the author fuses his spiritual wisdom and scientific research to bring to light how the subconscious mind can be a major influence on our daily lives. Once you understand your subconscious mind, you can also control or get rid of the various phobias that you may have in turn opening a brand new world of positive energy.",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2,
                    ImageUrl = ""
                }
              
                );
        }
    }
}
