﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personapi_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    cc = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    apellido = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    genero = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    edad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__persona__3213666D9A73C56E", x => x.cc);
                });

            migrationBuilder.CreateTable(
                name: "profesion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nom = table.Column<string>(type: "varchar(90)", unicode: false, maxLength: 90, nullable: true),
                    des = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__profesio__3213E83F1CCC1A8C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "telefono",
                columns: table => new
                {
                    num = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    oper = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    duenio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__telefono__DF908D65985BAC9A", x => x.num);
                    table.ForeignKey(
                        name: "telefono_persona_fk",
                        column: x => x.duenio,
                        principalTable: "persona",
                        principalColumn: "cc");
                });

            migrationBuilder.CreateTable(
                name: "estudios",
                columns: table => new
                {
                    id_prof = table.Column<int>(type: "int", nullable: false),
                    cc_per = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    univer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__estudios__FB3F71A625BE3227", x => new { x.id_prof, x.cc_per });
                    table.ForeignKey(
                        name: "estudio_persona_fk",
                        column: x => x.cc_per,
                        principalTable: "persona",
                        principalColumn: "cc");
                    table.ForeignKey(
                        name: "estudio_profesion_fk",
                        column: x => x.id_prof,
                        principalTable: "profesion",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_estudios_cc_per",
                table: "estudios",
                column: "cc_per");

            migrationBuilder.CreateIndex(
                name: "IX_telefono_duenio",
                table: "telefono",
                column: "duenio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estudios");

            migrationBuilder.DropTable(
                name: "telefono");

            migrationBuilder.DropTable(
                name: "profesion");

            migrationBuilder.DropTable(
                name: "persona");
        }
    }
}
