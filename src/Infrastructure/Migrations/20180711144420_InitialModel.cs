﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Promociones.Infrastructure.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntidadesFinancieras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadesFinancieras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediosPago",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediosPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promociones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    MaxCantidadDeCuotas = table.Column<int>(nullable: true),
                    PorcentajeDecuento = table.Column<decimal>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promociones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposMedioPago",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMedioPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromocionesEntidadesFinancieras",
                columns: table => new
                {
                    EntidadFinancieraId = table.Column<int>(nullable: false),
                    PromocionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocionesEntidadesFinancieras", x => new { x.PromocionId, x.EntidadFinancieraId });
                    table.ForeignKey(
                        name: "FK_PromocionesEntidadesFinancieras_EntidadesFinancieras_EntidadFinancieraId",
                        column: x => x.EntidadFinancieraId,
                        principalTable: "EntidadesFinancieras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromocionesEntidadesFinancieras_Promociones_PromocionId",
                        column: x => x.PromocionId,
                        principalTable: "Promociones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromocionesMediosPago",
                columns: table => new
                {
                    MedioPagoId = table.Column<int>(nullable: false),
                    PromocionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocionesMediosPago", x => new { x.PromocionId, x.MedioPagoId });
                    table.ForeignKey(
                        name: "FK_PromocionesMediosPago_MediosPago_MedioPagoId",
                        column: x => x.MedioPagoId,
                        principalTable: "MediosPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromocionesMediosPago_Promociones_PromocionId",
                        column: x => x.PromocionId,
                        principalTable: "Promociones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromocionesProductosCategorias",
                columns: table => new
                {
                    PromocionId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocionesProductosCategorias", x => new { x.PromocionId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_PromocionesProductosCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromocionesProductosCategorias_Promociones_PromocionId",
                        column: x => x.PromocionId,
                        principalTable: "Promociones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromocionesTiposMedioPago",
                columns: table => new
                {
                    PromocionId = table.Column<int>(nullable: false),
                    TipoMedioPagoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocionesTiposMedioPago", x => new { x.PromocionId, x.TipoMedioPagoId });
                    table.ForeignKey(
                        name: "FK_PromocionesTiposMedioPago_Promociones_PromocionId",
                        column: x => x.PromocionId,
                        principalTable: "Promociones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromocionesTiposMedioPago_TiposMedioPago_TipoMedioPagoId",
                        column: x => x.TipoMedioPagoId,
                        principalTable: "TiposMedioPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Categoria 1" },
                    { 2, "Categoria 2" },
                    { 3, "Categoria 3" }
                });

            migrationBuilder.InsertData(
                table: "EntidadesFinancieras",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Banco Galicia" },
                    { 2, "Banco Rio" }
                });

            migrationBuilder.InsertData(
                table: "MediosPago",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Tarjeta Visa Galicia Gold" },
                    { 2, "Tarjeta Amex Frances Platinium" },
                    { 3, "Efectivo Pesos" },
                    { 4, "Efectivo Dollar" }
                });

            migrationBuilder.InsertData(
                table: "TiposMedioPago",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Visa" },
                    { 2, "Amex" },
                    { 3, "Efectivo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromocionesEntidadesFinancieras_EntidadFinancieraId",
                table: "PromocionesEntidadesFinancieras",
                column: "EntidadFinancieraId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionesMediosPago_MedioPagoId",
                table: "PromocionesMediosPago",
                column: "MedioPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionesProductosCategorias_CategoriaId",
                table: "PromocionesProductosCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionesTiposMedioPago_TipoMedioPagoId",
                table: "PromocionesTiposMedioPago",
                column: "TipoMedioPagoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromocionesEntidadesFinancieras");

            migrationBuilder.DropTable(
                name: "PromocionesMediosPago");

            migrationBuilder.DropTable(
                name: "PromocionesProductosCategorias");

            migrationBuilder.DropTable(
                name: "PromocionesTiposMedioPago");

            migrationBuilder.DropTable(
                name: "EntidadesFinancieras");

            migrationBuilder.DropTable(
                name: "MediosPago");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Promociones");

            migrationBuilder.DropTable(
                name: "TiposMedioPago");
        }
    }
}
