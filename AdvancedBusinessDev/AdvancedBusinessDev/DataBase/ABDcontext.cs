using Microsoft.EntityFrameworkCore;
using AdvancedBusinessDev.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AdvancedBusinessDev.DataBase
{
    public class ABDcontext : DbContext
    {
        public ABDcontext(DbContextOptions<ABDcontext> options) : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<IA> IAs { get; set; }
        public DbSet<Interface> Interfaces { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }

        // Configurações específicas do Oracle
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("Your Oracle Connection String");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de relacionamento e mapeamento de colunas

            // Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");
                entity.HasKey(e => e.IdCliente);
                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE").IsRequired();
                entity.Property(e => e.SetorAtuando).HasColumnName("SETOR_ATUANDO");
                entity.Property(e => e.Cep).HasColumnName("CEP");
                entity.Property(e => e.TempAtuacao).HasColumnName("TEMP_ATUACAO");
                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");
            });

            // Empresa
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("EMPRESA");
                entity.HasKey(e => e.EmpresaId);
                entity.Property(e => e.EmpresaId).HasColumnName("EMPRESA_ID").IsRequired();
                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");
                entity.Property(e => e.Cep).HasColumnName("CEP");
                entity.Property(e => e.TempAtuacao).HasColumnName("TEMP_ATUACAO");
                entity.Property(e => e.Especializacao).HasColumnName("ESPECIALIZACAO");
                entity.Property(e => e.ParceiroIdParceiro).HasColumnName("PARCEIRO_ID_PARCEIRO");
                entity.Property(e => e.ClienteIdCliente).HasColumnName("CLIENTE_ID_CLIENTE");

                // Relacionamentos
                entity.HasOne(e => e.Cliente)
                    .WithMany(c => c.Empresas)
                    .HasForeignKey(e => e.ClienteIdCliente)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // IA
            modelBuilder.Entity<IA>(entity =>
            {
                entity.ToTable("IA");
                entity.HasKey(e => e.IdIa);
                entity.Property(e => e.IdIa).HasColumnName("ID_IA").IsRequired();
                entity.Property(e => e.HistRecomendacao).HasColumnName("HIST_RECOMENDACAO");
                entity.Property(e => e.Tecnologias).HasColumnName("TECNOLOGIAS");
                entity.Property(e => e.BancoDados).HasColumnName("BANCO_DADOS");
                entity.Property(e => e.Dados).HasColumnName("DADOS");
                entity.Property(e => e.ParceiroIdParceiro).HasColumnName("PARCEIRO_ID_PARCEIRO");
                entity.Property(e => e.EmpresaEmpresaId).HasColumnName("EMPRESA_EMPRESA_ID");

                // Relacionamentos
                entity.HasOne(e => e.Empresa)
                    .WithMany(emp => emp.IAs)
                    .HasForeignKey(e => e.EmpresaEmpresaId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Parceiro)
                    .WithMany(p => p.IAs)
                    .HasForeignKey(e => e.ParceiroIdParceiro)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Interface
            modelBuilder.Entity<Interface>(entity =>
            {
                entity.ToTable("INTERFACE");
                entity.HasKey(e => e.IdInterface);
                entity.Property(e => e.IdInterface).HasColumnName("ID_INTERFACE").IsRequired();
                entity.Property(e => e.NomeInterface).HasColumnName("NM_INTERFACE");
                entity.Property(e => e.Funcionalidade).HasColumnName("FUNCIONALIDADE");
                entity.Property(e => e.Estilo).HasColumnName("ESTILO");
                entity.Property(e => e.Linguas).HasColumnName("LINGUAS");
                entity.Property(e => e.ClienteIdCliente).HasColumnName("CLIENTE_ID_CLIENTE");
                entity.Property(e => e.IaIdIa).HasColumnName("IA_ID_IA");

                // Relacionamentos
                entity.HasOne(i => i.IA)
                    .WithMany(ia => ia.Interfaces)
                    .HasForeignKey(i => i.IaIdIa)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Parceiro
            modelBuilder.Entity<Parceiro>(entity =>
            {
                entity.ToTable("PARCEIRO");
                entity.HasKey(e => e.IdParceiro);
                entity.Property(e => e.IdParceiro).HasColumnName("ID_PARCEIRO").IsRequired();
                entity.Property(e => e.NomeParceiro).HasColumnName("NM_PARCEIRO");
                entity.Property(e => e.AreaAtuando).HasColumnName("AREA_ATUANDO");
                entity.Property(e => e.AvaliacaoDesempenho).HasColumnName("AVALIACAO_DESEMP");
                entity.Property(e => e.TipoParceria).HasColumnName("TP_PARCERIA");
            });
        }
        public DbSet<AdvancedBusinessDev.Models.Cliente> Cliente { get; set; } = default!;
    }
}
