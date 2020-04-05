using Microsoft.EntityFrameworkCore.Migrations;

namespace AA.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bil_Kategori_KategoriID",
                table: "Bil");

            migrationBuilder.DropForeignKey(
                name: "FK_Bil_Marke_MarkeID",
                table: "Bil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marke",
                table: "Marke");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori");

            migrationBuilder.DropColumn(
                name: "MarkeID",
                table: "Marke");

            migrationBuilder.DropColumn(
                name: "KategoriID",
                table: "Kategori");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Marke",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Kategori",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marke",
                table: "Marke",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bil_Kategori_KategoriID",
                table: "Bil",
                column: "KategoriID",
                principalTable: "Kategori",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bil_Marke_MarkeID",
                table: "Bil",
                column: "MarkeID",
                principalTable: "Marke",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bil_Kategori_KategoriID",
                table: "Bil");

            migrationBuilder.DropForeignKey(
                name: "FK_Bil_Marke_MarkeID",
                table: "Bil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marke",
                table: "Marke");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Marke");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Kategori");

            migrationBuilder.AddColumn<int>(
                name: "MarkeID",
                table: "Marke",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KategoriID",
                table: "Kategori",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marke",
                table: "Marke",
                column: "MarkeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori",
                column: "KategoriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bil_Kategori_KategoriID",
                table: "Bil",
                column: "KategoriID",
                principalTable: "Kategori",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bil_Marke_MarkeID",
                table: "Bil",
                column: "MarkeID",
                principalTable: "Marke",
                principalColumn: "MarkeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
