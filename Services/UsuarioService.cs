using LoginCriptografado.Models;
using LoginCriptografado.Repository;
using LoginCriptografado.Interfaces;

namespace LoginCriptografado.Services
{
    public class UsuarioService 
    {
        private readonly IUsuarioRepository _iUsuarioRepository; // aplicar depois tratamento de erros.
        public UsuarioService(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        public void CadastrarUsuario(UsuarioModel usuario, string senhaConfirm)
        {
            if (usuario != null)
            {
                if(ConfirmarSenha(usuario, senhaConfirm))
                    Console.WriteLine("erro senhas não coincidem burro"); return;

                usuario.Login.SenhaUsuarioLogin = usuario.SenhaUsuario;
                usuario.Login.EmailUsuarioLogin = usuario.EmailUsuario;
                usuario.Login.Usuario = usuario;

                _iUsuarioRepository.CadastrarUsuario(usuario);
            }
        }

       
        public bool ConfirmarSenha(UsuarioModel usuario, string senhaConfirm)
        {
            if (usuario.SenhaUsuario == senhaConfirm)
            {
                return false;
            }
            return true;
        }


    }
}
