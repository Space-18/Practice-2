using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pseudonimo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editorials",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SitioWeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<long>(type: "bigint", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibroAutor",
                columns: table => new
                {
                    LibroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AutorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroAutor", x => new { x.LibroId, x.AutorId });
                    table.ForeignKey(
                        name: "FK_LibroAutor_Autors_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroAutor_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibroCategoria",
                columns: table => new
                {
                    LibroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoriaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroCategoria", x => new { x.LibroId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_LibroCategoria_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroCategoria_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibroEditorial",
                columns: table => new
                {
                    LibroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EditorialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroEditorial", x => new { x.LibroId, x.EditorialId });
                    table.ForeignKey(
                        name: "FK_LibroEditorial_Editorials_EditorialId",
                        column: x => x.EditorialId,
                        principalTable: "Editorials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroEditorial_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autors",
                columns: new[] { "Id", "Apellidos", "CreateBy", "CreateDate", "FechaNacimiento", "Imagen", "LastModifiedBy", "LastModifiedDate", "Nombres", "Pseudonimo" },
                values: new object[,]
                {
                    { "011e0882-1456-4f47-b67a-9981bd1f58c9", "Vallejo", "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "César", "" },
                    { "16f1fdeb-b4ae-48f2-a4bb-c72ef59c9dbf", "Varga Llosa", "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario", "" },
                    { "ed7514f9-f174-466c-84d9-139c6e219a27", "Sábato", "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ernesto", "" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CreateBy", "CreateDate", "LastModifiedBy", "LastModifiedDate", "Nombre" },
                values: new object[,]
                {
                    { "104f1d54-7003-498d-93e6-c9d66ffd57cf", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" },
                    { "803cc157-da8d-45d2-b341-b1c272538b1e", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acción" },
                    { "d00f17b3-2fb9-48bf-943b-d988e0293dbb", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aventuras" }
                });

            migrationBuilder.InsertData(
                table: "Editorials",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Imagen", "LastModifiedBy", "LastModifiedDate", "Nombre", "SitioWeb" },
                values: new object[,]
                {
                    { "9e58bacf-7a01-4ac3-a919-3318522b3733", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Libros Peruanos", "https://www.lperu.com.pe" },
                    { "bb2fe83f-dc5a-4fe2-b26d-9de8d2bb1308", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crisol", "https://www.crisol.com" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "CreateBy", "CreateDate", "FechaPublicacion", "ISBN", "Imagen", "LastModifiedBy", "LastModifiedDate", "Nombre" },
                values: new object[,]
                {
                    { "d14296fa-6f8c-4b79-8743-8ac42cf8519c", "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1948, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9786124507724L, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "El túnel" },
                    { "f24bda29-28c1-40c1-b478-6034a6e40805", "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1951, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9786123022723L, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paco yunque" }
                });

            migrationBuilder.InsertData(
                table: "LibroAutor",
                columns: new[] { "AutorId", "LibroId", "CreateBy", "CreateDate", "Id", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { "ed7514f9-f174-466c-84d9-139c6e219a27", "d14296fa-6f8c-4b79-8743-8ac42cf8519c", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "011e0882-1456-4f47-b67a-9981bd1f58c9", "f24bda29-28c1-40c1-b478-6034a6e40805", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "LibroCategoria",
                columns: new[] { "CategoriaId", "LibroId", "CreateBy", "CreateDate", "Id", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { "104f1d54-7003-498d-93e6-c9d66ffd57cf", "d14296fa-6f8c-4b79-8743-8ac42cf8519c", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d00f17b3-2fb9-48bf-943b-d988e0293dbb", "f24bda29-28c1-40c1-b478-6034a6e40805", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "LibroEditorial",
                columns: new[] { "EditorialId", "LibroId", "CreateBy", "CreateDate", "Id", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { "bb2fe83f-dc5a-4fe2-b26d-9de8d2bb1308", "d14296fa-6f8c-4b79-8743-8ac42cf8519c", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9e58bacf-7a01-4ac3-a919-3318522b3733", "f24bda29-28c1-40c1-b478-6034a6e40805", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "bb2fe83f-dc5a-4fe2-b26d-9de8d2bb1308", "f24bda29-28c1-40c1-b478-6034a6e40805", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibroAutor_AutorId",
                table: "LibroAutor",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroCategoria_CategoriaId",
                table: "LibroCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroEditorial_EditorialId",
                table: "LibroEditorial",
                column: "EditorialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroAutor");

            migrationBuilder.DropTable(
                name: "LibroCategoria");

            migrationBuilder.DropTable(
                name: "LibroEditorial");

            migrationBuilder.DropTable(
                name: "Autors");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Editorials");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
