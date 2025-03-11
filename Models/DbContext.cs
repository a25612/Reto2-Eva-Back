using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Centro> Centros { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<UsuarioTutor> UsuariosTutores { get; set; }
        public DbSet<ServicioCentro> ServiciosCentros { get; set; }
        public DbSet<UsuarioCentro> UsuariosCentros { get; set; }
        public DbSet<EmpleadosCentros> EmpleadosCentros { get; set; }
        public DbSet<OpcionServicio> OpcionesServicio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioTutor>()
       .HasKey(ut => ut.Id);

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

            modelBuilder.Entity<OpcionServicio>()
                .HasOne(os => os.Servicio)
                .WithMany(s => s.Opciones)
                .HasForeignKey(os => os.IdServicio);

            modelBuilder.Entity<Servicio>()
                .HasOne(s => s.Empleado)
                .WithMany()
                .HasForeignKey(s => s.ID_EMPLEADO);

            modelBuilder.Entity<Sesion>()
                .HasOne(s => s.Usuario)
                .WithMany()
                .HasForeignKey(s => s.ID_USUARIO)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sesion>()
                .HasOne(s => s.Tutor)
                .WithMany()
                .HasForeignKey(s => s.ID_TUTOR)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sesion>()
                .HasOne(s => s.Empleado)
                .WithMany()
                .HasForeignKey(s => s.ID_EMPLEADO)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sesion>()
               .HasOne(s => s.Servicio)
               .WithMany()
               .HasForeignKey(s => s.ID_SERVICIO)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sesion>()
                .HasOne(s => s.OpcionServicio)
                .WithMany()
                .HasForeignKey(s => s.ID_OPCION_SERVICIO)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sesion>()
                .HasOne(s => s.Centro)
                .WithMany()
                .HasForeignKey(s => s.ID_CENTRO)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
