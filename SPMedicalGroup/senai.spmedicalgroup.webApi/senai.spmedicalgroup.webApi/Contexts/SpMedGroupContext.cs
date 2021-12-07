using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.spmedicalgroup.webApi.Domains;

#nullable disable

namespace senai.spmedicalgroup.webApi.Contexts
{
    public partial class SpMedGroupContext : DbContext
    {
        public SpMedGroupContext()
        {
        }

        public SpMedGroupContext(DbContextOptions<SpMedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Data Source=DESKTOP-BHEJL7O\\SQLEXPRESS; initial catalog=SP_MEDICAL_GROUP; user id=sa; pwd=qwerty;");
                optionsBuilder.UseSqlServer("Data Source=NOTE0113A5\\SQLEXPRESS; initial catalog=SP_MEDICAL_GROUP_MANHA; user id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__C73A6055DD0D1D52");

                entity.ToTable("Clinica");

                entity.HasIndex(e => e.NomeClinica, "UQ__Clinica__2F80697ACDDC8745")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__Clinica__AA57D6B417741BE1")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.HorarioAber).HasColumnName("horarioAber");

                entity.Property(e => e.HorarioFecha).HasColumnName("horarioFecha");

                entity.Property(e => e.NomeClinica)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeClinica");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__CA9C61F544F33544");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("datetime")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Situacao)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("situacao");

                entity.Property(e => e.Valor)
                    .HasColumnType("money")
                    .HasColumnName("valor")
                    .HasDefaultValueSql("('50.00')");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__idMedi__534D60F1");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__Consulta__idPaci__5441852A");

                entity.HasOne(d => d.SituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Situacao)
                    .HasConstraintName("FK__Consulta__situac__5535A963");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__40969805DA389BB4");

                entity.ToTable("Especialidade");

                entity.HasIndex(e => e.NomeEspecialidade, "UQ__Especial__EF876A54CD47C8FD")
                    .IsUnique();

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.NomeEspecialidade)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("nomeEspecialidade");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medico__4E03DEBAA36FEF7B");

                entity.ToTable("Medico");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.Crm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CRM");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__Medico__email__33D4B598");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medico__idClinic__31EC6D26");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__Medico__idEspeci__32E0915F");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__F48A08F240F23173");

                entity.ToTable("Paciente");

                entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C87BBF1044")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F89731A1CC0150")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataNasc)
                    .HasColumnType("date")
                    .HasColumnName("dataNasc");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.Property(e => e.Tel)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("tel");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__Paciente__email__44FF419A");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.Situacao1)
                    .HasName("PK__Situacao__52F4F120E4BA33CF");

                entity.ToTable("Situacao");

                entity.Property(e => e.Situacao1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("situacao");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.Sigla)
                    .HasName("PK__TipoUsua__3C47D5185C7DFE8D");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__TipoUsua__A9585C05A16900B6")
                    .IsUnique();

                entity.Property(e => e.Sigla)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("sigla");

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Usuario__AB6E616541948D70");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.NomeUsuario, "UQ__Usuario__8C9D1DE5D17638D8")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.TipoUsuario)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("tipoUsuario");

                entity.HasOne(d => d.TipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuario)
                    .HasConstraintName("FK__Usuario__tipoUsu__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
