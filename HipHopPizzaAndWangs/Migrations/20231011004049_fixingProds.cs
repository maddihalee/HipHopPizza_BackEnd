using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HipHopPizzaAndWangs.Migrations
{
    /// <inheritdoc />
    public partial class fixingProds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://sipbitego.com/wp-content/uploads/2021/08/Pepperoni-Pizza-Recipe-Sip-Bite-Go.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://www.jessicagavin.com/wp-content/uploads/2020/07/hawaiian-pizza-16-1200.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://californiaranchmarket.com/cdn/shop/products/000355_568234ca-45de-49f0-9e9c-65127b46be21.jpg?v=1680240542");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://mccormick.widen.net/content/n0phdkxdlp/jpeg/Franks_RedHot_Buffalo_Chicken_Wings.jpg?crop=true&anchor=0,0&q=80&color=ffffffff&u=qtpeo3&w=800&h=800");
        }
    }
}
