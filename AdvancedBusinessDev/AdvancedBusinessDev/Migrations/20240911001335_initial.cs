using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedBusinessDev.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SETOR_ATUANDO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TEMP_ATUACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "PARCEIRO",
                columns: table => new
                {
                    ID_PARCEIRO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_PARCEIRO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AREA_ATUANDO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AVALIACAO_DESEMP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TP_PARCERIA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARCEIRO", x => x.ID_PARCEIRO);
                });

            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    EMPRESA_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CNPJ = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TEMP_ATUACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ESPECIALIZACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PARCEIRO_ID_PARCEIRO = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CLIENTE_ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.EMPRESA_ID);
                    table.ForeignKey(
                        name: "FK_EMPRESA_CLIENTE_CLIENTE_ID_CLIENTE",
                        column: x => x.CLIENTE_ID_CLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "ID_CLIENTE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMPRESA_PARCEIRO_PARCEIRO_ID_PARCEIRO",
                        column: x => x.PARCEIRO_ID_PARCEIRO,
                        principalTable: "PARCEIRO",
                        principalColumn: "ID_PARCEIRO");
                });

            migrationBuilder.CreateTable(
                name: "IA",
                columns: table => new
                {
                    ID_IA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HIST_RECOMENDACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TECNOLOGIAS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BANCO_DADOS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DADOS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PARCEIRO_ID_PARCEIRO = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    EMPRESA_EMPRESA_ID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IA", x => x.ID_IA);
                    table.ForeignKey(
                        name: "FK_IA_EMPRESA_EMPRESA_EMPRESA_ID",
                        column: x => x.EMPRESA_EMPRESA_ID,
                        principalTable: "EMPRESA",
                        principalColumn: "EMPRESA_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IA_PARCEIRO_PARCEIRO_ID_PARCEIRO",
                        column: x => x.PARCEIRO_ID_PARCEIRO,
                        principalTable: "PARCEIRO",
                        principalColumn: "ID_PARCEIRO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INTERFACE",
                columns: table => new
                {
                    ID_INTERFACE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_INTERFACE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FUNCIONALIDADE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ESTILO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LINGUAS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLIENTE_ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    IA_ID_IA = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERFACE", x => x.ID_INTERFACE);
                    table.ForeignKey(
                        name: "FK_INTERFACE_IA_IA_ID_IA",
                        column: x => x.IA_ID_IA,
                        principalTable: "IA",
                        principalColumn: "ID_IA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_CLIENTE_ID_CLIENTE",
                table: "EMPRESA",
                column: "CLIENTE_ID_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_PARCEIRO_ID_PARCEIRO",
                table: "EMPRESA",
                column: "PARCEIRO_ID_PARCEIRO");

            migrationBuilder.CreateIndex(
                name: "IX_IA_EMPRESA_EMPRESA_ID",
                table: "IA",
                column: "EMPRESA_EMPRESA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_IA_PARCEIRO_ID_PARCEIRO",
                table: "IA",
                column: "PARCEIRO_ID_PARCEIRO");

            migrationBuilder.CreateIndex(
                name: "IX_INTERFACE_IA_ID_IA",
                table: "INTERFACE",
                column: "IA_ID_IA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INTERFACE");

            migrationBuilder.DropTable(
                name: "IA");

            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "PARCEIRO");
        }
    }
}
