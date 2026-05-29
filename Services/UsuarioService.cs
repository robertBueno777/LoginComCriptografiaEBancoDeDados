using LoginCriptografado.Models;
using LoginCriptografado.Repository;
using LoginCriptografado.Interfaces;
using BCrypt.Net;
using System.ComponentModel.DataAnnotations;

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
                if (ConfirmarSenha(usuario, senhaConfirm) == true)
                {                    
                    Console.WriteLine("erro senhas não coincidem burro");
                    return;
                }

                usuario.SenhaUsuario = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaUsuario);
                usuario.Login.SenhaUsuarioLogin = usuario.SenhaUsuario;
                usuario.Login.EmailUsuarioLogin = usuario.EmailUsuario;
                usuario.Login.Usuario = usuario;
                _iUsuarioRepository.CadastrarUsuario(usuario);  
            }
            return;
        }
        public UsuarioModel? RealizarLogin(string emailUsuario, string senha)
        {
            var usuario = _iUsuarioRepository.BuscarPorEmail(emailUsuario);
            var idUsu = usuario.Id;
            if(senha != usuario.Login.SenhaUsuarioLogin)
            {
                //senha.bcrypt.
                Console.WriteLine("senha ou email não possuem cadastro no banco."); return null;
            }
            return usuario;
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
