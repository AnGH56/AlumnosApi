using AlumnosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumnosApi.Data
{
    public class AlumnosContext : DbContext
    {
        public AlumnosContext(DbContextOptions<AlumnosContext> options): base(options) { }  

        public DbSet<Alumno> Alumnos { get; set; }

       
    }
}
