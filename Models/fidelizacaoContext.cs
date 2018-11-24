using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace ApiFidelizacao1.Models
{
    public partial class fidelizacaoContext : DbContext
    {
        public fidelizacaoContext(DbContextOptions<fidelizacaoContext> options)
            : base(options)
        {
        }
        // dotnet ef dbcontext scaffold "Server=localhost;Database=fidelizacao;User=root;Password=7227234888Gg;" "Pomelo.EntityFrameworkCore.MySql" -o Models
        public virtual DbSet<Cartao> Cartao { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Historicopontos> Historicopontos { get; set; }
        public virtual DbSet<Selo> Selo { get; set; }
        public virtual DbSet<Valor> Valor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=fidelizacao;User=root;Password=7227234888Gg;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartao>(entity =>
            {
                entity.HasKey(e => e.NumeroCartao);

                entity.ToTable("cartao");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("fk_idCliente_idx");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("fk_idEmpresa_idx");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("fk_idFuncionario_idx");

                entity.Property(e => e.NumeroCartao).HasColumnType("int(11)");

                entity.Property(e => e.DataVencimento).HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnType("int(11)");

                entity.Property(e => e.IdEmpresa).HasColumnType("int(11)");

                entity.Property(e => e.IdFuncionario).HasColumnType("int(11)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Cartao)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_idCliente");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Cartao)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idEmpresa");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Cartao)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("fk_idFuncionario");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("cliente");

                entity.HasIndex(e => e.Cpf)
                    .HasName("Cpf_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnType("varchar(14)");

                entity.Property(e => e.DataNasc).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnType("varchar(14)");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.ToTable("empresa");

                entity.HasIndex(e => e.Cnpj)
                    .HasName("CNPJ_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("idEmpresa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnType("varchar(14)");

                entity.Property(e => e.TipoCartao)
                    .IsRequired()
                    .HasColumnName("Tipo_Cartao")
                    .HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario);

                entity.ToTable("funcionario");

                entity.HasIndex(e => e.EmpresaIdEmpresa)
                    .HasName("fk_Funcionario_Empresa1_idx");

                entity.HasIndex(e => e.Login)
                    .HasName("Login_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("idFuncionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmpresaIdEmpresa)
                    .HasColumnName("Empresa_idEmpresa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.EmpresaIdEmpresaNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.EmpresaIdEmpresa)
                    .HasConstraintName("fk_Funcionario_Empresa1");
            });

            modelBuilder.Entity<Historicopontos>(entity =>
            {
                entity.HasKey(e => e.CartaoNumeroCartao);

                entity.ToTable("historicopontos");

                entity.HasIndex(e => e.CartaoNumeroCartao)
                    .HasName("fk_numCartao_idx");

                entity.Property(e => e.CartaoNumeroCartao)
                    .HasColumnName("Cartao_NumeroCartao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.TipoCartao)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.Valor).HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.CartaoNumeroCartaoNavigation)
                    .WithOne(p => p.Historicopontos)
                    .HasForeignKey<Historicopontos>(d => d.CartaoNumeroCartao)
                    .HasConstraintName("fk_numCartao");
            });

            modelBuilder.Entity<Selo>(entity =>
            {
                entity.HasKey(e => e.NumeroCartao);

                entity.ToTable("selo");

                entity.HasIndex(e => e.NumeroCartao)
                    .HasName("fk_numCartao_index");

                entity.Property(e => e.NumeroCartao).HasColumnType("int(11)");

                entity.Property(e => e.Frequencia).HasColumnType("int(11)");

                entity.HasOne(d => d.NumeroCartaoNavigation)
                    .WithOne(p => p.Selo)
                    .HasForeignKey<Selo>(d => d.NumeroCartao)
                    .HasConstraintName("fk_numCartao1");
            });

            modelBuilder.Entity<Valor>(entity =>
            {
                entity.HasKey(e => e.NumeroCartao);

                entity.ToTable("valor");

                entity.HasIndex(e => e.NumeroCartao)
                    .HasName("fk_numCartao2_idx");

                entity.Property(e => e.NumeroCartao).HasColumnType("int(11)");

                entity.Property(e => e.Valor1)
                    .HasColumnName("Valor")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.NumeroCartaoNavigation)
                    .WithOne(p => p.Valor)
                    .HasForeignKey<Valor>(d => d.NumeroCartao)
                    .HasConstraintName("fk_numCartao2");
            });
        }
    }
}
