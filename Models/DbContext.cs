using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class MyDbContext : DbContext
    {
        // Constructor que recibe opciones
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}

        // Tablas (DbSet)
        public DbSet<Centros> Centros { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tutor> Tutores { get; set; }

        // Tablas intermedias y relaciones
        public DbSet<UsuarioTutor> UsuariosTutores { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<ServicioCentro> ServiciosCentros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de claves compuestas para tablas intermedias
            modelBuilder.Entity<UsuarioTutor>()
                .HasKey(ut => new { ut.ID_USUARIO, ut.ID_TUTOR });

            modelBuilder.Entity<ServicioCentro>()
                .HasKey(sc => new { sc.ID_SERVICIO, sc.IdCentro });

            base.OnModelCreating(modelBuilder);
        }
    }
}
