using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppObuca.Migrations
{
    public partial class DodavanjeUBazu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Obuca",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Model", "SlikaUrl" },
                values: new object[] { "Adidas ADI2000", "https://static.footshop.com/834961/256309.jpg" });

            migrationBuilder.UpdateData(
                table: "Obuca",
                keyColumn: "Id",
                keyValue: 7,
                column: "SlikaUrl",
                value: "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_1350,h_1350/global/392730/14/sv01/fnd/EEA/fmt/png/Cali-Dream-Leather-Sneakers-Women");

            migrationBuilder.UpdateData(
                table: "Obuca",
                keyColumn: "Id",
                keyValue: 9,
                column: "Model",
                value: "New Balance FUELCELL SUPERCOMP ELITE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Obuca",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Model", "SlikaUrl" },
                values: new object[] { "AdidasADI dvije tisuce", "https://www.snipes.hr/dw/image/v2/BDCB_PRD/on/demandware.static/-/Sites-snse-master-eu/default/dwb542f545/2083249_P.jpg" });

            migrationBuilder.UpdateData(
                table: "Obuca",
                keyColumn: "Id",
                keyValue: 7,
                column: "SlikaUrl",
                value: "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/b7d9211c-26e7-431a-ac24-b0540fb3c00f/air-force-1-07-mens-shoes-jBrhbr.png");

            migrationBuilder.UpdateData(
                table: "Obuca",
                keyColumn: "Id",
                keyValue: 9,
                column: "Model",
                value: "New Balance ");
        }
    }
}
