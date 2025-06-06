namespace Soltrix.Utils
{
    /// <summary>
    /// Utilitário para geração e verificação de hash de senhas usando BCrypt.
    /// </summary>
    public static class Criptografia
    {
        /// <summary>
        /// Gera um hash seguro a partir da senha informada.
        /// </summary>
        /// <param name="senha">Senha em texto puro.</param>
        /// <returns>Hash criptografado da senha.</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a senha fornecida corresponde ao hash armazenado.
        /// </summary>
        /// <param name="senha">Senha em texto puro para verificação.</param>
        /// <param name="hash">Hash armazenado para comparação.</param>
        /// <returns>True se a senha corresponder ao hash, caso contrário, false.</returns>
        public static bool VerificarSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}