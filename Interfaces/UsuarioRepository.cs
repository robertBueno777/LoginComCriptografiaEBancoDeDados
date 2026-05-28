using LoginCriptografado.Models;

namespace LoginCriptografado.Repository
{
    public interface IUsuarioRepository
    {
        public void CadastrarUsuario(UsuarioModel usuario);
        public int BuscarPorId(int idUsuario);

    }
}
