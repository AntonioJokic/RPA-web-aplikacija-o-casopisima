using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Casopisi.Migrations
{
    public partial class DodavanjeSlikaUBazu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlikaUrl",
                table: "Casopisi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Casopisi",
                keyColumn: "Id",
                keyValue: 1,
                column: "SlikaUrl",
                value: "https://assets.vogue.com/photos/5877049471b368a625a08fff/master/w_2000,h_2741,c_limit/jennifer-lawrence-december-2015-cover.jpg");

            migrationBuilder.UpdateData(
                table: "Casopisi",
                keyColumn: "Id",
                keyValue: 2,
                column: "SlikaUrl",
                value: "https://pretplata.hanzamedia.hr/wp-content/uploads/2016/03/GLB-23.2.18..jpg");

            migrationBuilder.UpdateData(
                table: "Casopisi",
                keyColumn: "Id",
                keyValue: 3,
                column: "SlikaUrl",
                value: "https://hips.hearstapps.com/hmg-prod/images/cover-esq0423-144-642edab94ab5e.jpg");

            migrationBuilder.UpdateData(
                table: "Casopisi",
                keyColumn: "Id",
                keyValue: 4,
                column: "SlikaUrl",
                value: "https://storyeditor.com.hr/images/portfolio/Lider.jpg");

            migrationBuilder.UpdateData(
                table: "Casopisi",
                keyColumn: "Id",
                keyValue: 5,
                column: "SlikaUrl",
                value: "https://www.adriamedia.hr/wp-content/uploads/2018/07/elle-kolovoz.jpg");

            migrationBuilder.UpdateData(
                table: "Casopisi",
                keyColumn: "Id",
                keyValue: 6,
                column: "SlikaUrl",
                value: "https://rappart.com/wp-content/uploads/2019/04/R1345_COV_BIDEN.jpg");

            migrationBuilder.UpdateData(
                table: "Casopisi",
                keyColumn: "Id",
                keyValue: 7,
                column: "SlikaUrl",
                value: "https://www.dissentmagazine.org/wp-content/files_mf/1578091896Winter2020_frontcover_350x500.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikaUrl",
                table: "Casopisi");
        }
    }
}
