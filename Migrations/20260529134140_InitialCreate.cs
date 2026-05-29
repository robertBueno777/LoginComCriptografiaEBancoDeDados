using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginCriptografado.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SenhaUsuarioLogin = table.Column<string>(type: "TEXT", nullable: false),
                    EmailUsuarioLogin = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    EmailUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    SenhaUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    NomeCompletoUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    LoginId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_LoginUsuarios_LoginId",
                        column: x => x.LoginId,
                        principalTable: "LoginUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_LoginId",
                table: "Usuarios",
                column: "LoginId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "LoginUsuarios");
        }
    }
}
