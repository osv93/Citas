using Microsoft.EntityFrameworkCore;
using CitasClientes.Model;

namespace CitasClientes.DA
{
    public class Context : DbContext
    {

        //public CitaRepositoryContext(DbContextOptions<CitaRepositoryContext> options): base(options)
        //{ }
        //public CitaRepositoryContext()
        //{ }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<TipoCita> TiposCitas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase"));
            //optionsBuilder.UseSqlServer("Server=PF13GPM9;Database=Shop;Trusted_Connection=True;");
            
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder.UseSqlServer(@"Data Source=PF13GPM9\SQLEXPRESS;Initial Catalog=Hospital;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoCita>().HasData(
                new TipoCita { TipoCitaID = 1, TipoCitaNombre = "Medicina General" },
                new TipoCita { TipoCitaID = 2, TipoCitaNombre = "Odontología" },
                new TipoCita { TipoCitaID = 3, TipoCitaNombre = "Pediatría" },
                new TipoCita { TipoCitaID = 4, TipoCitaNombre = "Neurología" }
            );

            modelBuilder.Entity<Paciente>().HasData(
                new Paciente { PacienteID = "1111", PacienteFullName = "Paciente 1" },
                new Paciente { PacienteID = "2222", PacienteFullName = "Paciente 2" },
                new Paciente { PacienteID = "3333", PacienteFullName = "Paciente 3" },
                new Paciente { PacienteID = "4444", PacienteFullName = "Paciente 4" }
            );
        }
    }
}
