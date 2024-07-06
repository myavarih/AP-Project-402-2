using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP_Project.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Restaurants",
                newName: "DineIn");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialService",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DineIn",
                table: "Restaurants",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Delivery",
                table: "Restaurants",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TotalRate",
                table: "Restaurants",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Username");

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    UserUsername = table.Column<string>(type: "TEXT", nullable: false),
                    RestaurantUsername = table.Column<string>(type: "TEXT", nullable: false),
                    IsSolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserUsername = table.Column<string>(type: "TEXT", nullable: false),
                    RestaurantUsername = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: true),
                    IsOnlinePaying = table.Column<bool>(type: "INTEGER", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false)
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
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: true),
                    RestaurantUsername = table.Column<string>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderCode = table.Column<int>(type: "INTEGER", nullable: true)
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
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    ReplyCode = table.Column<int>(type: "INTEGER", nullable: true),
                    IsEdited = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserUsername = table.Column<string>(type: "TEXT", nullable: false),
                    RestaurantUsername = table.Column<string>(type: "TEXT", nullable: false),
                    FoodName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Foodkey = table.Column<string>(type: "TEXT", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentForFood");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "RestaurantComment");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "SpecialService",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "TotalRate",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "DineIn",
                table: "Restaurants",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Restaurants",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Admins",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Admins",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");
        }
    }
}
