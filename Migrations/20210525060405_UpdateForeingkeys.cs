using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class UpdateForeingkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boletas_Calificacions_CalificacionId",
                table: "Boletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificacions_Materias_MateriaId",
                table: "Calificacions");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificacions_Usuarios_UsuarioId",
                table: "Calificacions");

            migrationBuilder.DropForeignKey(
                name: "FK_GradoUsuarios_Grados_GradoId",
                table: "GradoUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_GradoUsuarios_Usuarios_UsuarioId",
                table: "GradoUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Grados_GradoId",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_GradoUsuarios_GradoId",
                table: "GradoUsuarios");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdGrado",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "GradoId",
                table: "GradoUsuarios");

            migrationBuilder.DropColumn(
                name: "IdGrado",
                table: "GradoUsuarios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "GradoUsuarios");

            migrationBuilder.DropColumn(
                name: "IdMateria",
                table: "Calificacions");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Calificacions");

            migrationBuilder.DropColumn(
                name: "IdCalificacion",
                table: "Boletas");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GradoId",
                table: "Materias",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "GradoUsuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Calificacions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "Calificacions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CalificacionId",
                table: "Boletas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletas_Calificacions_CalificacionId",
                table: "Boletas",
                column: "CalificacionId",
                principalTable: "Calificacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificacions_Materias_MateriaId",
                table: "Calificacions",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificacions_Usuarios_UsuarioId",
                table: "Calificacions",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradoUsuarios_Usuarios_UsuarioId",
                table: "GradoUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Grados_GradoId",
                table: "Materias",
                column: "GradoId",
                principalTable: "Grados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boletas_Calificacions_CalificacionId",
                table: "Boletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificacions_Materias_MateriaId",
                table: "Calificacions");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificacions_Usuarios_UsuarioId",
                table: "Calificacions");

            migrationBuilder.DropForeignKey(
                name: "FK_GradoUsuarios_Usuarios_UsuarioId",
                table: "GradoUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Grados_GradoId",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GradoId",
                table: "Materias",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IdGrado",
                table: "Materias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "GradoUsuarios",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "GradoId",
                table: "GradoUsuarios",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdGrado",
                table: "GradoUsuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "GradoUsuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Calificacions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "Calificacions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IdMateria",
                table: "Calificacions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Calificacions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CalificacionId",
                table: "Boletas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IdCalificacion",
                table: "Boletas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GradoUsuarios_GradoId",
                table: "GradoUsuarios",
                column: "GradoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boletas_Calificacions_CalificacionId",
                table: "Boletas",
                column: "CalificacionId",
                principalTable: "Calificacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificacions_Materias_MateriaId",
                table: "Calificacions",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificacions_Usuarios_UsuarioId",
                table: "Calificacions",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GradoUsuarios_Grados_GradoId",
                table: "GradoUsuarios",
                column: "GradoId",
                principalTable: "Grados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GradoUsuarios_Usuarios_UsuarioId",
                table: "GradoUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Grados_GradoId",
                table: "Materias",
                column: "GradoId",
                principalTable: "Grados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
