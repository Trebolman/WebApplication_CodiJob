using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication_CodiJob.Model.CodiJobDb
{
    public partial class CodiJobDbContext : DbContext
    {
        public CodiJobDbContext()
        {
        }

        // constructor para que lleguen parametros de construccion
        public CodiJobDbContext(DbContextOptions<CodiJobDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tgrupos> Tgrupos { get; set; }
        public virtual DbSet<TgrupoUsuario> TgrupoUsuario { get; set; }
        public virtual DbSet<Tproyectos> Tproyectos { get; set; }
        public virtual DbSet<Tskills> Tskills { get; set; }
        public virtual DbSet<TskillUsuario> TskillUsuario { get; set; }
        public virtual DbSet<TusuarioPerfil> TusuarioPerfil { get; set; }
        public virtual DbSet<TusuarioProyecto> TusuarioProyecto { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("data source = 172.24.2.25; initial catalog = CodiJob; user id = sa; password = desarrollo2012");
                //Quitamos la linea anterior para ponerla en appsetting.json
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tgrupos>(entity =>
            {
                entity.Property(e => e.GrupoId).ValueGeneratedNever();

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Promocion).IsUnicode(false);
            });

            modelBuilder.Entity<TgrupoUsuario>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioId, e.GrupoId });

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.TgrupoUsuario)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TGrupo_Usuario_TGrupos");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.TgrupoUsuario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TGrupo_Usuario_TUsuario_Perfil");
            });

            modelBuilder.Entity<Tproyectos>(entity =>
            {
                entity.Property(e => e.ProyectoId).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);
            });

            modelBuilder.Entity<Tskills>(entity =>
            {
                entity.Property(e => e.SkillId).ValueGeneratedNever();

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<TskillUsuario>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioId, e.SkillId });

                entity.Property(e => e.Nivel).IsUnicode(false);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.TskillUsuario)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSkill_Usuario_TSkills");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.TskillUsuario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSkill_Usuario_TUsuario_Perfil");
            });

            modelBuilder.Entity<TusuarioPerfil>(entity =>
            {
                entity.Property(e => e.UsuarioId).ValueGeneratedNever();

                entity.Property(e => e.Blog).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Git).IsUnicode(false);

                entity.Property(e => e.WebSite).IsUnicode(false);
            });

            modelBuilder.Entity<TusuarioProyecto>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioId, e.ProyectoId });

                entity.HasOne(d => d.Proyecto)
                    .WithMany(p => p.TusuarioProyecto)
                    .HasForeignKey(d => d.ProyectoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUsuarioProyecto_TProyectos1");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.TusuarioProyecto)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUsuarioProyecto_TUsuario_Perfil");
            });
        }
    }
}
