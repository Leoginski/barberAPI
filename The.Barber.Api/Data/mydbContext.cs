using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using The.Barber.Api.Models;

namespace The.Barber.Api.Data
{
    public partial class mydbContext : DbContext
    {


        public mydbContext(DbContextOptions<mydbContext> options)
        {
            //super(options);
        }
        public virtual DbSet<Agendamento> Agendamento { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Barbearia> Barbearia { get; set; }
        public virtual DbSet<Barbeiro> Barbeiro { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Corte> Corte { get; set; }
        public virtual DbSet<CortePorBarbeiro> CortePorBarbeiro { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=;Database=mydb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasKey(e => new { e.ClienteIdCliente, e.BarbeiroIdBarbeiro });

                entity.ToTable("agendamento");

                entity.HasIndex(e => e.BarbeiroIdBarbeiro)
                    .HasName("fk_cliente_has_barbeiro_barbeiro1_idx");

                entity.HasIndex(e => e.ClienteIdCliente)
                    .HasName("fk_cliente_has_barbeiro_cliente1_idx");

                entity.Property(e => e.ClienteIdCliente)
                    .HasColumnName("cliente_id_cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BarbeiroIdBarbeiro)
                    .HasColumnName("barbeiro_id_barbeiro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Horario)
                    .HasColumnName("horario")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.BarbeiroIdBarbeiroNavigation)
                    .WithMany(p => p.Agendamento)
                    .HasForeignKey(d => d.BarbeiroIdBarbeiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente_has_barbeiro_barbeiro1");

                entity.HasOne(d => d.ClienteIdClienteNavigation)
                    .WithMany(p => p.Agendamento)
                    .HasForeignKey(d => d.ClienteIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente_has_barbeiro_cliente1");
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => new { e.IdAvaliacao, e.AgendamentoClienteIdCliente, e.AgendamentoBarbeiroIdBarbeiro });

                entity.ToTable("avaliacao");

                entity.HasIndex(e => new { e.AgendamentoClienteIdCliente, e.AgendamentoBarbeiroIdBarbeiro })
                    .HasName("fk_avaliacao_agendamento1_idx");

                entity.Property(e => e.IdAvaliacao)
                    .HasColumnName("id_avaliacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AgendamentoClienteIdCliente)
                    .HasColumnName("agendamento_cliente_id_cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AgendamentoBarbeiroIdBarbeiro)
                    .HasColumnName("agendamento_barbeiro_id_barbeiro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NotaBarbeiro)
                    .HasColumnName("nota_barbeiro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NotaCliente)
                    .HasColumnName("nota_cliente")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Agendamento)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => new { d.AgendamentoClienteIdCliente, d.AgendamentoBarbeiroIdBarbeiro })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avaliacao_agendamento1");
            });

            modelBuilder.Entity<Barbearia>(entity =>
            {
                entity.HasKey(e => e.IdBarbearia);

                entity.ToTable("barbearia");

                entity.HasIndex(e => e.CidadesIdCidade)
                    .HasName("fk_barbearias_cidades1_idx");

                entity.Property(e => e.IdBarbearia)
                    .HasColumnName("id_barbearia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CidadesIdCidade)
                    .HasColumnName("cidades_id_cidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .HasMaxLength(45);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CidadesIdCidadeNavigation)
                    .WithMany(p => p.Barbearia)
                    .HasForeignKey(d => d.CidadesIdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_barbearias_cidades1");
            });

            modelBuilder.Entity<Barbeiro>(entity =>
            {
                entity.HasKey(e => e.IdBarbeiro);

                entity.ToTable("barbeiro");

                entity.Property(e => e.IdBarbeiro)
                    .HasColumnName("id_barbeiro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .HasMaxLength(45);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.IdCidade);

                entity.ToTable("cidade");

                entity.HasIndex(e => e.EstadosIdEstado)
                    .HasName("fk_cidades_estados1_idx");

                entity.Property(e => e.IdCidade)
                    .HasColumnName("id_cidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EstadosIdEstado)
                    .HasColumnName("estados_id_estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.HasOne(d => d.EstadosIdEstadoNavigation)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.EstadosIdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cidades_estados1");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("cliente");

                entity.HasIndex(e => e.CidadesIdCidade)
                    .HasName("fk_cliente_cidades_idx");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(45);

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(45);

                entity.Property(e => e.CidadesIdCidade)
                    .HasColumnName("cidades_id_cidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(45);

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .HasMaxLength(45);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(45);

                entity.HasOne(d => d.CidadesIdCidadeNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.CidadesIdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente_cidades");
            });

            modelBuilder.Entity<Corte>(entity =>
            {
                entity.HasKey(e => e.IdCorte);

                entity.ToTable("corte");

                entity.Property(e => e.IdCorte)
                    .HasColumnName("id_corte")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cortecol)
                    .HasColumnName("cortecol")
                    .HasMaxLength(45);

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasMaxLength(45);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<CortePorBarbeiro>(entity =>
            {
                entity.HasKey(e => new { e.CorteIdCorte, e.BarbeiroIdBarbeiro });

                entity.ToTable("corte_por_barbeiro");

                entity.HasIndex(e => e.BarbeiroIdBarbeiro)
                    .HasName("fk_corte_has_barbeiro_barbeiro1_idx");

                entity.HasIndex(e => e.CorteIdCorte)
                    .HasName("fk_corte_has_barbeiro_corte1_idx");

                entity.Property(e => e.CorteIdCorte)
                    .HasColumnName("corte_id_corte")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BarbeiroIdBarbeiro)
                    .HasColumnName("barbeiro_id_barbeiro")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.BarbeiroIdBarbeiroNavigation)
                    .WithMany(p => p.CortePorBarbeiro)
                    .HasForeignKey(d => d.BarbeiroIdBarbeiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_corte_has_barbeiro_barbeiro1");

                entity.HasOne(d => d.CorteIdCorteNavigation)
                    .WithMany(p => p.CortePorBarbeiro)
                    .HasForeignKey(d => d.CorteIdCorte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_corte_has_barbeiro_corte1");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.ToTable("estado");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("id_estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45);

                entity.Property(e => e.Uf)
                    .HasColumnName("uf")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.HasKey(e => new { e.BarbeariaIdBarbearia, e.BarbeiroIdBarbeiro });

                entity.ToTable("funcionarios");

                entity.HasIndex(e => e.BarbeariaIdBarbearia)
                    .HasName("fk_barbearia_has_barbeiro_barbearia1_idx");

                entity.HasIndex(e => e.BarbeiroIdBarbeiro)
                    .HasName("fk_barbearia_has_barbeiro_barbeiro1_idx");

                entity.Property(e => e.BarbeariaIdBarbearia)
                    .HasColumnName("barbearia_id_barbearia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BarbeiroIdBarbeiro)
                    .HasColumnName("barbeiro_id_barbeiro")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.BarbeariaIdBarbeariaNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.BarbeariaIdBarbearia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_barbearia_has_barbeiro_barbearia1");

                entity.HasOne(d => d.BarbeiroIdBarbeiroNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.BarbeiroIdBarbeiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_barbearia_has_barbeiro_barbeiro1");
            });
        }
    }
}
