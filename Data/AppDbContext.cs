using Microsoft.EntityFrameworkCore;
using LoginCriptografado.Models;

namespace LoginCriptografado.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<LoginUsuarioModel> LoginUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                .HasOne(u => u.Login)
                .WithOne(l => l.Usuario)
                .HasForeignKey<UsuarioModel>(u => u.LoginId);
        }

    }
}
