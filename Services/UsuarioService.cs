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
                    Console.WriteLine("erro: senhas não coincidem, amigo");
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

        public bool RealizarLogin(string emailUsuario, string senha)
        {
            var usuario = _iUsuarioRepository.BuscarPorEmail(emailUsuario);
            if (BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaUsuario))
            {
                Console.WriteLine("senha ou email não possuem cadastro no banco.");
                return true;
            }
            return false;
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
