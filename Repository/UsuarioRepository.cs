using LoginCriptografado.Data;
using LoginCriptografado.Interfaces;
using LoginCriptografado.Models;
using Microsoft.EntityFrameworkCore;


namespace LoginCriptografado.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void CadastrarUsuario(UsuarioModel usuario)
        {
            _appDbContext.Add(usuario);
            _appDbContext.SaveChanges();
            
        }
        public UsuarioModel? BuscarPorId(int idUsuario)
        {
            var usuario = _appDbContext.Usuarios.Where(u => u.Id == idUsuario).Include(u => u.Login).FirstOrDefault();
            return usuario;
        }
        public UsuarioModel? BuscarPorNomeUsuario(string nomeUsuario)
        {
            var usuario = _appDbContext.Usuarios.Where(u => u.NomeUsuario == nomeUsuario).Include(u => u.Login).FirstOrDefault();
            return usuario;
        }
        public UsuarioModel? BuscarPorEmail(string emailUsuario)
        {
            var usuario = _appDbContext.Usuarios.Where(u => u.EmailUsuario == emailUsuario).Include(u => u.Login).FirstOrDefault();
            return usuario;
        }





    }
}
