using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP_Project.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentForFood");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "RestaurantComment");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropColumn(
                name: "TotalRate",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "Categories",
                table: "Restaurants",
                newName: "ordersJson");

            migrationBuilder.AddColumn<string>(
                name: "categoriesJson",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "foodJson",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoriesJson",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "foodJson",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "ordersJson",
                table: "Restaurants",
                newName: "Categories");

            migrationBuilder.AddColumn<double>(
                name: "TotalRate",
                table: "Restaurants",
                type: "REAL",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    IsOnlinePaying = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: true),
                    RestaurantUsername = table.Column<string>(type: "TEXT", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserUsername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Order_Restaurants_RestaurantUsername",
                        column: x => x.RestaurantUsername,
                        principalTable: "Restaurants",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserUsername",
                        column: x => x.UserUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantComment",
                columns: table => new
                {
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantComment", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    key = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OrderCode = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: true),
                    RestaurantUsername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.key);
                    table.ForeignKey(
                        name: "FK_Food_Order_OrderCode",
                        column: x => x.OrderCode,
                        principalTable: "Order",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Food_Restaurants_RestaurantUsername",
                        column: x => x.RestaurantUsername,
                        principalTable: "Restaurants",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentForFood",
                columns: table => new
                {
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReplyCode = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FoodName = table.Column<string>(type: "TEXT", nullable: false),
                    Foodkey = table.Column<string>(type: "TEXT", nullable: true),
                    IsEdited = table.Column<bool>(type: "INTEGER", nullable: false),
                    RestaurantUsername = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    UserUsername = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentForFood", x => x.Code);
                    table.ForeignKey(
                        name: "FK_CommentForFood_Food_Foodkey",
                        column: x => x.Foodkey,
                        principalTable: "Food",
                        principalColumn: "key");
                    table.ForeignKey(
                        name: "FK_CommentForFood_RestaurantComment_ReplyCode",
                        column: x => x.ReplyCode,
                        principalTable: "RestaurantComment",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentForFood_Foodkey",
                table: "CommentForFood",
                column: "Foodkey");

            migrationBuilder.CreateIndex(
                name: "IX_CommentForFood_ReplyCode",
                table: "CommentForFood",
                column: "ReplyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Food_OrderCode",
                table: "Food",
                column: "OrderCode");

            migrationBuilder.CreateIndex(
                name: "IX_Food_RestaurantUsername",
                table: "Food",
                column: "RestaurantUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RestaurantUsername",
                table: "Order",
                column: "RestaurantUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserUsername",
                table: "Order",
                column: "UserUsername");
        }
    }
}
