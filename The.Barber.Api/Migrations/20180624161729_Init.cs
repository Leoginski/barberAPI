using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace The.Barber.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    BarbeiroId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "corte",
                columns: table => new
                {
                    id_corte = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cortecol = table.Column<string>(maxLength: 45, nullable: true),
                    foto = table.Column<string>(maxLength: 45, nullable: true),
                    nome = table.Column<string>(maxLength: 45, nullable: false),
                    valor = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corte", x => x.id_corte);
                });

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 45, nullable: false),
                    uf = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.id_estado);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "barbeiro",
                columns: table => new
                {
                    id_barbeiro = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(maxLength: 45, nullable: false),
                    barbeirocol = table.Column<string>(maxLength: 45, nullable: true),
                    Complemento = table.Column<string>(maxLength: 45, nullable: true),
                    cpf = table.Column<string>(maxLength: 11, nullable: false),
                    logradouro = table.Column<string>(maxLength: 45, nullable: false),
                    nome = table.Column<string>(maxLength: 45, nullable: false),
                    numero = table.Column<int>(type: "int(11)", nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barbeiro", x => x.id_barbeiro);
                    table.ForeignKey(
                        name: "FK_barbeiro_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cidade",
                columns: table => new
                {
                    id_cidade = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estados_id_estado = table.Column<int>(type: "int(11)", nullable: false),
                    nome = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidade", x => x.id_cidade);
                    table.ForeignKey(
                        name: "fk_cidades_estados1",
                        column: x => x.estados_id_estado,
                        principalTable: "estado",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "corte_por_barbeiro",
                columns: table => new
                {
                    corte_id_corte = table.Column<int>(type: "int(11)", nullable: false),
                    barbeiro_id_barbeiro = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corte_por_barbeiro", x => new { x.corte_id_corte, x.barbeiro_id_barbeiro });
                    table.ForeignKey(
                        name: "fk_corte_has_barbeiro_barbeiro1",
                        column: x => x.barbeiro_id_barbeiro,
                        principalTable: "barbeiro",
                        principalColumn: "id_barbeiro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_corte_has_barbeiro_corte1",
                        column: x => x.corte_id_corte,
                        principalTable: "corte",
                        principalColumn: "id_corte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "barbearia",
                columns: table => new
                {
                    id_barbearia = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(maxLength: 45, nullable: false),
                    cidades_id_cidade = table.Column<int>(type: "int(11)", nullable: false),
                    cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    Complemento = table.Column<string>(maxLength: 45, nullable: true),
                    logradouro = table.Column<string>(maxLength: 45, nullable: false),
                    nome = table.Column<string>(maxLength: 45, nullable: false),
                    numero = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barbearia", x => x.id_barbearia);
                    table.ForeignKey(
                        name: "fk_barbearias_cidades1",
                        column: x => x.cidades_id_cidade,
                        principalTable: "cidade",
                        principalColumn: "id_cidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bairro = table.Column<string>(maxLength: 45, nullable: false),
                    cep = table.Column<string>(maxLength: 45, nullable: false),
                    cidades_id_cidade = table.Column<int>(type: "int(11)", nullable: false),
                    cpf = table.Column<string>(maxLength: 11, nullable: false),
                    email = table.Column<string>(maxLength: 45, nullable: false),
                    logradouro = table.Column<string>(maxLength: 45, nullable: false),
                    nome = table.Column<string>(maxLength: 45, nullable: false),
                    numero = table.Column<string>(maxLength: 45, nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id_cliente);
                    table.ForeignKey(
                        name: "fk_cliente_cidades",
                        column: x => x.cidades_id_cidade,
                        principalTable: "cidade",
                        principalColumn: "id_cidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cliente_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    barbearia_id_barbearia = table.Column<int>(type: "int(11)", nullable: false),
                    barbeiro_id_barbeiro = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => new { x.barbearia_id_barbearia, x.barbeiro_id_barbeiro });
                    table.ForeignKey(
                        name: "fk_barbearia_has_barbeiro_barbearia1",
                        column: x => x.barbearia_id_barbearia,
                        principalTable: "barbearia",
                        principalColumn: "id_barbearia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_barbearia_has_barbeiro_barbeiro1",
                        column: x => x.barbeiro_id_barbeiro,
                        principalTable: "barbeiro",
                        principalColumn: "id_barbeiro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "agendamento",
                columns: table => new
                {
                    cliente_id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    barbeiro_id_barbeiro = table.Column<int>(type: "int(11)", nullable: false),
                    horario = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamento", x => new { x.cliente_id_cliente, x.barbeiro_id_barbeiro });
                    table.ForeignKey(
                        name: "fk_cliente_has_barbeiro_barbeiro1",
                        column: x => x.barbeiro_id_barbeiro,
                        principalTable: "barbeiro",
                        principalColumn: "id_barbeiro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cliente_has_barbeiro_cliente1",
                        column: x => x.cliente_id_cliente,
                        principalTable: "cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "avaliacao",
                columns: table => new
                {
                    id_avaliacao = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    agendamento_cliente_id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    agendamento_barbeiro_id_barbeiro = table.Column<int>(type: "int(11)", nullable: false),
                    nota_barbeiro = table.Column<int>(type: "int(11)", nullable: false),
                    nota_cliente = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacao", x => new { x.id_avaliacao, x.agendamento_cliente_id_cliente, x.agendamento_barbeiro_id_barbeiro });
                    table.ForeignKey(
                        name: "fk_avaliacao_agendamento1",
                        columns: x => new { x.agendamento_cliente_id_cliente, x.agendamento_barbeiro_id_barbeiro },
                        principalTable: "agendamento",
                        principalColumns: new[] { "cliente_id_cliente", "barbeiro_id_barbeiro" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_cliente_has_barbeiro_barbeiro1_idx",
                table: "agendamento",
                column: "barbeiro_id_barbeiro");

            migrationBuilder.CreateIndex(
                name: "fk_cliente_has_barbeiro_cliente1_idx",
                table: "agendamento",
                column: "cliente_id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_avaliacao_agendamento1_idx",
                table: "avaliacao",
                columns: new[] { "agendamento_cliente_id_cliente", "agendamento_barbeiro_id_barbeiro" });

            migrationBuilder.CreateIndex(
                name: "fk_barbearias_cidades1_idx",
                table: "barbearia",
                column: "cidades_id_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_barbeiro_UsuarioId",
                table: "barbeiro",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_cidades_estados1_idx",
                table: "cidade",
                column: "estados_id_estado");

            migrationBuilder.CreateIndex(
                name: "fk_cliente_cidades_idx",
                table: "cliente",
                column: "cidades_id_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_UsuarioId",
                table: "cliente",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_corte_has_barbeiro_barbeiro1_idx",
                table: "corte_por_barbeiro",
                column: "barbeiro_id_barbeiro");

            migrationBuilder.CreateIndex(
                name: "fk_corte_has_barbeiro_corte1_idx",
                table: "corte_por_barbeiro",
                column: "corte_id_corte");

            migrationBuilder.CreateIndex(
                name: "fk_barbearia_has_barbeiro_barbearia1_idx",
                table: "funcionarios",
                column: "barbearia_id_barbearia");

            migrationBuilder.CreateIndex(
                name: "fk_barbearia_has_barbeiro_barbeiro1_idx",
                table: "funcionarios",
                column: "barbeiro_id_barbeiro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "avaliacao");

            migrationBuilder.DropTable(
                name: "corte_por_barbeiro");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "agendamento");

            migrationBuilder.DropTable(
                name: "corte");

            migrationBuilder.DropTable(
                name: "barbearia");

            migrationBuilder.DropTable(
                name: "barbeiro");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "cidade");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "estado");
        }
    }
}
