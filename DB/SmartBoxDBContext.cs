using Microsoft.EntityFrameworkCore;
using smartbox.DB.Map;
using SmartBox.Model;

namespace SmartBox.DB
{
    public class SmartBoxDBContext : DbContext
    {
        public SmartBoxDBContext(DbContextOptions<SmartBoxDBContext> options) 
            : base(options) 
        {           
        
        }

        public DbSet<UsuariosModel> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
