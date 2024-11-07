using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationDBcontext : DbContext
    {
        //Constructor
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        { 
        
        }

        //Models
        public DbSet<Contacto> Contactos { get; set; }

    }
}
