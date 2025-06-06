namespace Soltrix.Utils
{
    /// <summary>
    /// Classe utilitária para validação de dados comuns, como CPF e CEP, além de entrada de dados segura.
    /// </summary>
    public static class Validador
    {

        /// <summary>
        /// Valida se um CPF é válido com base nos dígitos verificadores.
        /// </summary>
        /// <param name="cpf">CPF em formato numérico (11 dígitos, sem pontos ou traços).</param>
        /// <returns>True se o CPF for válido, false caso contrário.</returns>
        public static bool ValidarCPF(string cpf)
        {
            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * (10 - i);

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * (11 - i);

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }


        /// <summary>
        /// Valida se um CEP é válido com 8 dígitos numéricos.
        /// </summary>
        /// <param name="cep">CEP em formato numérico (8 dígitos, sem traços).</param>
        /// <returns>True se o CEP for válido, false caso contrário.</returns>
        public static bool ValidarCEP(string cep)
        {
            return cep.Length == 8 && long.TryParse(cep, out _);
        }

        /// <summary>
        /// Solicita a entrada de um campo obrigatório, impedindo que o usuário deixe em branco.
        /// </summary>
        /// <param name="label">Texto do campo a ser exibido para o usuário.</param>
        /// <returns>Valor digitado pelo usuário, garantido como não vazio.</returns>
        public static string LerCampoObrigatorio(string label)
        {
            string valor;
            do
            {
                Console.Write($"{label}: ");
                valor = Console.ReadLine();
                Console.Clear();
                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine($"{label} é obrigatório. Tente novamente.");
                }
            } while (string.IsNullOrWhiteSpace(valor));

            return valor;
        }

        /// <summary>
        /// Lê uma confirmação do usuário (sim ou não), garantindo que apenas "s" ou "n" sejam aceitos.
        /// </summary>
        /// <param name="mensagem">Mensagem de confirmação a ser exibida ao usuário.</param>
        /// <returns>True se a resposta for "s", false se for "n".</returns>
        public static bool LerConfirmacaoSimNao(string mensagem)
        {
            string resposta;
            do
            {
                Console.Write($"{mensagem} (s/n): ");
                resposta = Console.ReadLine().Trim().ToLower();
                Console.Clear();

                if (resposta != "s" && resposta != "n")
                {
                    Console.WriteLine("Entrada inválida. Digite apenas 's' ou 'n'.");
                }

            } while (resposta != "s" && resposta != "n");

            return resposta == "s";
        }
    }
    

    }
