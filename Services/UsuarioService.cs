using Soltrix.Models;
using Soltrix.Utils;

namespace Soltrix.Services
{
    using System.Collections.Generic;
    using System.Linq;


    /// <summary>
    /// Serviço para gerenciamento de usuários, incluindo cadastro e autenticação.
    /// </summary>
    public class UsuarioService
    {
        private List<Usuario> _usuarios = new();


        /// <summary>
        /// Cadastra um novo usuário e armazena sua senha criptografada.
        /// </summary>
        /// <param name="usuario">Objeto usuário a ser cadastrado.</param>
        /// <param name="senha">Senha em texto puro que será criptografada.</param>
        public void CadastrarUsuario(Usuario usuario, string senha)
        {
            usuario.SenhaHash = Criptografia.GerarHash(senha);
            _usuarios.Add(usuario);
        }

        /// <summary>
        /// Autentica um usuário pelo CPF e senha.
        /// </summary>
        /// <param name="cpf">CPF do usuário.</param>
        /// <param name="senha">Senha em texto puro para validação.</param>
        /// <returns>Usuário autenticado ou null se falhar.</returns>
        public Usuario Autenticar(string cpf, string senha)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.CPF == cpf);
            if (usuario != null && Criptografia.VerificarSenha(senha, usuario.SenhaHash))
            {
                return usuario;
            }
            return null;
        }

    }

}
