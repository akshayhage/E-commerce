using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "A. P. J. Abdul Kalam\r\n", "‘Failure will never overtake me if my determination to succeed is strong enough.’ Oftentimes, our desire to succeed doesn’t account for the failure, when in fact, failing at something can teach us the most about how to succeed.", "SWD9999001", 99.0, 90.0, 80.0, 85.0, "Failure is a Teacher" },
                    { 2, "Norman Vincent Peale", "It is a practical, direct-action application of spiritual techniques to overcome defeat and win confidence, success, and joy. Norman Vincent Peale, the father of positive thinking and one of the most widely read inspirational writers of all time, shares his famous formula of faith and optimism which millions of people have taken as their own simple and effective philosophy of living.", "CAW777777701", 40.0, 30.0, 20.0, 25.0, "The Power of Positive Thinking" },
                    { 3, "Dale Carnegie", "This book explores the nature of stress and how it infiltrates every level of your life, including the physical, emotional, cognitive, relational, and even spiritual. Through techniques that get to the heart of your unique stress response and an exploration of how stress can affect your relationships, you will discover how to control stress instead of letting it control you.", "RITO5555501", 55.0, 50.0, 35.0, 40.0, "How to Stop Worrying and Start Living" },
                    { 4, "Claude M Bristol ", "This book shows you how you become what you contemplate, why hard work alone will not bring success, how to bring the subconscious into practical action, how to turn your thoughts into achievements, and how belief makes things happen", "WS3333333301", 70.0, 65.0, 55.0, 60.0, "The Magic of Believing" },
                    { 5, "Joseph Murphy", "In this book, the author fuses his spiritual wisdom and scientific research to bring to light how the subconscious mind can be a major influence on our daily lives. Once you understand your subconscious mind, you can also control or get rid of the various phobias that you may have in turn opening a brand new world of positive energy.", "SOTJ1111111101", 30.0, 27.0, 20.0, 25.0, "The Power of Your Subconscious Mind" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
