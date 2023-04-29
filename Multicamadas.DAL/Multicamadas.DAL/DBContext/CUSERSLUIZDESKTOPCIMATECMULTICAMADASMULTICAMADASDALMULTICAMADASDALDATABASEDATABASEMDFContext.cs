using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

using Multicamadas.MODEL;

namespace Multicamadas.DAL.DBContext
{
    public partial class MDFContext : DbContext
    {
        public MDFContext()
        {
        }

        public MDFContext(DbContextOptions<MDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projetos> Projetos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\luiz\\Desktop\\cimatec\\Multicamadas\\Multicamadas.DAL\\Multicamadas.DAL\\database\\database.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projetos>(entity =>
            {
                entity.Property(e => e.DataFim).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.NomeGerente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NomeProjeto)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Resumo).HasColumnType("text");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
