using LoginCriptografado.Models;

namespace LoginCriptografado.Interfaces
{
    public interface IUsuarioRepository
    {
        public void CadastrarUsuario(UsuarioModel usuario);
        public UsuarioModel? BuscarPorId(int idUsuario);
        public UsuarioModel? BuscarPorNome(string nomeUsuario);
        public UsuarioModel? BuscarPorEmail(string emailUsuario);

    }
}
