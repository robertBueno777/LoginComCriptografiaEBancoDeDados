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

        //vai validar o email separadamente.
        public string ValidandoEmail(string email)
        {
            var usuario = _iUsuarioRepository.BuscarPorEmail(email);
            if (email == null)
                return "Por favor, insira um email válido.";
            else if (!email.Contains("@"))
                return "Por favor, insira um email válido.";
            else if(usuario != null)
                return "Email já cadastrado.";
            return null;
        }


        //vai validar o nome completo separadamente
        public string ValidandoNomeCompleto(string nomeCompleto)
        {
            if (nomeCompleto == null)
                return "Por favor, insira um nome válido.";
            else if (nomeCompleto.Length < 7 || nomeCompleto.Length > 50)
                return "Por favor, insira um nome válido.";
            else if (nomeCompleto.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))
                return "Por favor, insira um nome válido.";
            return null;         
        }


        //vai validar o nome de usuario
        public string ValidandoNomeUsuario(string nomeUsuario)
        {
            var usuario = _iUsuarioRepository.BuscarPorNomeUsuario(nomeUsuario);
            if (nomeUsuario == null)
                return "Insira um nome de usuário válido, por favor.";
            else if (usuario != null)
                return "Nome de usuario ja cadastrado.";
            return null; 
        }


        //vai validar o cadastro todo utilizando os outros métodos de validação.
        public string ValidandoCadastro(UsuarioModel usuario)
        {
            string validationEmail = ValidandoEmail(usuario.EmailUsuario);
            string validationNomeCompleto = ValidandoNomeCompleto(usuario.NomeCompletoUsuario);
            string validationNomeUsuario = ValidandoNomeUsuario(usuario.NomeUsuario);
           
            if(validationEmail != null)
            {
                return validationEmail;
            }
            else if(validationNomeCompleto != null)
            {
                return validationNomeCompleto;
            }
            else if(validationNomeUsuario != null)
            {
                return validationNomeUsuario;
            }
            return null;
        }

        public string CadastrarUsuario(UsuarioModel usuario, string senhaConfirm)
        {
            if (usuario != null)
            {
                if(ValidandoCadastro(usuario) != null)
                {
                    return ValidandoCadastro(usuario);
                }
                ;
                if (ConfirmarSenha(usuario, senhaConfirm) == true)
                {                       
                    return "erro: senhas não coincidem, amigo";
                }
                usuario.Login.SenhaUsuarioLogin = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaUsuario);
                usuario.SenhaUsuario = null;
                usuario.Login.EmailUsuarioLogin = usuario.EmailUsuario;
                usuario.Login.Usuario = usuario;
                _iUsuarioRepository.CadastrarUsuario(usuario);  
            }
            return "excelente, cadastro realizado com sucesso.";
        }

        public bool RealizarLogin(string emailUsuario, string senha)
        {
            
            var usuario = _iUsuarioRepository.BuscarPorEmail(emailUsuario);
            if(usuario == null)
            {
                return false;
            }
            if (BCrypt.Net.BCrypt.Verify(senha, usuario.Login.SenhaUsuarioLogin))
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
        public string ValidarLogin(string email, string senha)
        {
            if(email == null)
            {
                return "Por favor, preencha o campo email.";
            }
            if(senha == null)
            {
                return "Por favor, preencha o campo senha.";
            }
            var usuario = _iUsuarioRepository.BuscarPorEmail(email);
            if(usuario == null)
            {
                return "Credenciais erradas.";
            }
            return null;
        }

    }
}
