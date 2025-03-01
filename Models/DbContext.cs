using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class MyDbContext : DbContext
    {
        // Constructor que recibe opciones
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}

        // Tablas principales
        public DbSet<Centro> Centros { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        DbSet<Anuncio> Anuncios { get; set; }

        // Tablas intermedias
        public DbSet<UsuarioTutor> UsuariosTutores { get; set; }
        public DbSet<ServicioCentro> ServiciosCentros { get; set; }
        public DbSet<UsuarioCentro> UsuariosCentros { get; set; }
        public DbSet<EmpleadosCentros> EmpleadosCentros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de UsuarioTutor (N:N)
            modelBuilder.Entity<UsuarioTutor>()
                .HasKey(ut => new { ut.ID_USUARIO, ut.ID_TUTOR });

            modelBuilder.Entity<UsuarioTutor>()
                .HasOne(ut => ut.Usuario)
                .WithMany(u => u.UsuariosTutores)
                .HasForeignKey(ut => ut.ID_USUARIO);

            modelBuilder.Entity<UsuarioTutor>()
                .HasOne(ut => ut.Tutor)
                .WithMany(t => t.UsuariosTutores)
                .HasForeignKey(ut => ut.ID_TUTOR);

            modelBuilder.Entity<ServicioCentro>()
                .HasKey(sc => new { sc.ID_SERVICIO, sc.IdCentro });

            modelBuilder.Entity<ServicioCentro>()
                .HasOne(sc => sc.Servicio)
                .WithMany(s => s.ServiciosCentros)
                .HasForeignKey(sc => sc.ID_SERVICIO);

            modelBuilder.Entity<ServicioCentro>()
                .HasOne(sc => sc.Centro)
                .WithMany(c => c.ServiciosCentros)
                .HasForeignKey(sc => sc.IdCentro);

            // Configuración de UsuarioCentro (N:N)
            modelBuilder.Entity<UsuarioCentro>()
                .HasKey(uc => new { uc.ID_USUARIO, uc.ID_CENTRO });

            modelBuilder.Entity<UsuarioCentro>()
                .HasOne(uc => uc.Usuario)
                .WithMany(u => u.UsuariosCentros)   
                .HasForeignKey(uc => uc.ID_USUARIO);

            modelBuilder.Entity<UsuarioCentro>()
                .HasOne(uc => uc.Centro)
                .WithMany(c => c.UsuariosCentros)
                .HasForeignKey(uc => uc.ID_CENTRO);

            // Configuración de EmpleadosCentros (N:N)
            modelBuilder.Entity<EmpleadosCentros>()
                .HasKey(ec => new { ec.ID_EMPLEADO, ec.ID_CENTRO });

            modelBuilder.Entity<EmpleadosCentros>()
                .HasOne(ec => ec.Empleado)
                .WithMany(e => e.EmpleadosCentros)
                .HasForeignKey(ec => ec.ID_EMPLEADO);

            modelBuilder.Entity<EmpleadosCentros>()
                .HasOne(ec => ec.Centro)
                .WithMany(c => c.EmpleadosCentros)
                .HasForeignKey(ec => ec.ID_CENTRO);

            base.OnModelCreating(modelBuilder);
        }
    }
}