using Soltrix.Models;
using Soltrix.Utils;

namespace Soltrix.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UsuarioService
    {
        private List<Usuario> _usuarios = new();

        public void CadastrarUsuario(Usuario usuario, string senha)
        {
            usuario.SenhaHash = Criptografia.GerarHash(senha);
            _usuarios.Add(usuario);
        }

        public Usuario Autenticar(string cpf, string senha)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.CPF == cpf);
            if (usuario != null && Criptografia.VerificarSenha(senha, usuario.SenhaHash))
            {
                return usuario;
            }
            return null;
        }

        public List<Usuario> ObterTodosUsuarios() => _usuarios;
    }

}
