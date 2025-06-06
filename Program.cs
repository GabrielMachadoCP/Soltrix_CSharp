using Soltrix.Models;
using Soltrix.Services;
using Soltrix.Services.Soltrix.Services;
using Soltrix.Utils;
using System.Globalization;

class Program
{
    static UsuarioService usuarioService = new();
    static EnergiaService energiaService = new();
    static BackupService backupService = new();
    static DicaService dicaService = new();

    /// <summary>
    /// Fluco principal do programa Soltrix.
    /// </summary>
    static void Main()
    {
        try
        {
            MostrarBoasVindas();
            Usuario usuario = CadastrarUsuario();
            Usuario usuarioAutenticado = FazerLogin();

            if (usuarioAutenticado == null)
            {
                Console.WriteLine("Encerrando programa...");
                return;
            }

            MostrarMenu(usuarioAutenticado);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
        }
    }

    /// <summary>
    /// Mostra mensagem de boas-vindas ao usuário.
    /// </summary>
    static void MostrarBoasVindas()
    {
        Console.WriteLine("=== BEM-VINDO À SOLTRIX ===");
        Console.WriteLine("Olá, seja parte da revolução energética com a Soltrix!");
    }

    /// <summary>
    /// Realiza o processo de cadastro de um novo usuário, com validações.
    /// </summary>
    /// <returns>Retorna o objeto do usuário cadastrado.</returns>
    static Usuario CadastrarUsuario()
    {
        Console.WriteLine("\n=== CADASTRO DE NOVO USUÁRIO ===");

        string nome = Validador.LerCampoObrigatorio("Nome");

        string cpf;
        do
        {
            cpf = Validador.LerCampoObrigatorio("CPF (somente números)");
            if (!Validador.ValidarCPF(cpf))
            {
                Console.WriteLine("CPF inválido. Tente novamente.");
            }
        } while (!Validador.ValidarCPF(cpf));

        Console.Write("Data de nascimento (dd/mm/aaaa): ");
        DateTime dataNascimento;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
        {
            Console.Write("Formato inválido. Digite novamente (dd/mm/aaaa): ");
        }

        string senha = Validador.LerCampoObrigatorio("Senha");

        Console.WriteLine("\n--- Endereço ---");

        string cep;
        do
        {
            cep = Validador.LerCampoObrigatorio("CEP (somente números)");
            Console.Clear();
            if (!Validador.ValidarCEP(cep))
            {
                Console.WriteLine("CEP inválido. Digite exatamente 8 números (ex: 12345678).");
            }
        } while (!Validador.ValidarCEP(cep));

        string rua;
        rua = Validador.LerCampoObrigatorio("Rua");
        Console.Clear();

        int numero;
        while (true)
        {
            Console.Write("Número: ");
            if (int.TryParse(Console.ReadLine(), out numero) && numero > 0)
                break;

            Console.WriteLine("Número inválido. Digite um número inteiro positivo.");
        }

        Endereco endereco = new()
        {
            CEP = cep,
            Rua = rua,
            Numero = numero,
            Bairro = Validador.LerCampoObrigatorio("Bairro"),
            Cidade = Validador.LerCampoObrigatorio("Cidade"),
            Estado = Validador.LerCampoObrigatorio("Estado (sigla)")
        };

        bool possuiEstabelecimento = Validador.LerConfirmacaoSimNao("Possui estabelecimento?");

        Usuario novoUsuario = new()
        {
            Nome = nome,
            CPF = cpf,
            DataNascimento = dataNascimento,
            Endereco = endereco,
            PossuiEstabelecimento = possuiEstabelecimento
        };

        usuarioService.CadastrarUsuario(novoUsuario, senha);
        Console.Clear();
        Console.WriteLine("Usuário cadastrado com sucesso!");

        return novoUsuario;
    }

    /// <summary>
    /// Realiza o processo de login do usuário, com tentativa múltipla.
    /// </summary>
    /// <returns>Usuário autenticado ou null se falhar.</returns>
    static Usuario FazerLogin()
    {
        Usuario usuarioAutenticado = null;
        bool tentarLogin = true;

        while (tentarLogin && usuarioAutenticado == null)
        {
            Console.WriteLine("\n=== LOGIN SOLTRIX ===");
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            usuarioAutenticado = usuarioService.Autenticar(cpf, senha);

            if (usuarioAutenticado == null)
            {
                Console.WriteLine("Login inválido.");
                tentarLogin = Validador.LerConfirmacaoSimNao("Deseja tentar novamente?");
            }
            Console.Clear();
        }

        if (usuarioAutenticado != null)
        {
            Console.Clear();
            Console.WriteLine($"\nBem-vindo(a), {usuarioAutenticado.Nome}!");
        }

        return usuarioAutenticado;
    }

    /// <summary>
    /// Mostra o menu principal com as funcionalidades disponíveis.
    /// </summary>
    /// <param name="usuario">Usuário autenticado.</param>
    static void MostrarMenu(Usuario usuario)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- MENU PRINCIPAL SOLTRIX ---");
            Console.WriteLine("\n1 - Registrar queda de energia");
            Console.WriteLine("2 - Ver previsões de falhas energéticas na regiao");
            Console.WriteLine("3 - Ver histórico de eventos");
            Console.WriteLine("4 - Gerar backup das quedas de energia");
            Console.WriteLine("5 - Ver dicas da Sol");
            Console.WriteLine("6 - Calcular prejuízos do estabelecimento\n");
            Console.WriteLine("0 - Sair");

            Console.Write("\nEscolha uma opção: ");
            string opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    RegistrarEvento(usuario);
                    break;
                case "2":
                    VerPrevisoes(usuario);
                    break;
                case "3":
                    VerHistorico(usuario);
                    break;
                case "4":
                    GerarBackup(usuario);
                    break;
                case "5":
                    MenuDicas();
                    break;
                case "6":
                    CalcularPrejuizos(usuario);
                    break;
                case "0":
                    continuar = false;
                    Console.WriteLine("Saindo da Soltrix. Até a próxima!");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    /// <summary>
    /// Registra um evento de queda de energia para o usuário.
    /// </summary>
    /// <param name="usuario">Usuário que está registrando o evento.</param>
    static void RegistrarEvento(Usuario usuario)
    {
        EventoEnergia evento = new()
        {
            UsuarioCPF = usuario.CPF,
            DataHora = DateTime.Now,
            EnergiaAtiva = false,
            Fonte = "Usuário"
        };

        Console.Write("Motivo da queda de energia: (Onda de Calor, Tempestade, Manutencao...) ");
        evento.Motivo = Console.ReadLine();

        energiaService.RegistrarEvento(evento);
        Console.WriteLine("Evento registrado com sucesso.");
    }

    /// <summary>
    /// Exibe previsão de falhas energéticas baseada em porcentagem aleatória.
    /// </summary>
    /// <param name="usuario">Usuário autenticado.</param>
    static void VerPrevisoes(Usuario usuario)
    {
        Random random = new Random();
        int previsaoPorcentagem = random.Next(0, 101);

        Console.WriteLine($"Olá {usuario.Nome}, as previsões Soltrix de falhas energéticas para o seu endereco, " +
            $"\n{usuario.Endereco.ExibirEndereco()} é de: {previsaoPorcentagem}% de chance de falha nos próximos dias.");
    }

    /// <summary>
    /// Mostra o histórico de eventos de queda de energia do usuário.
    /// </summary>
    /// <param name="usuario">Usuário autenticado.</param>
    static void VerHistorico(Usuario usuario)
    {
        var eventos = energiaService.ObterEventosPorUsuario(usuario.CPF);
        if (eventos.Count == 0)
        {
            Console.WriteLine("Nenhum evento registrado.");
        }
        else
        {
            Console.WriteLine("--- HISTÓRICO DE EVENTOS SOLTRIX ---");
            foreach (var e in eventos)
            {
                Console.WriteLine($"{e.DataHora}: {e.Motivo} (Fonte: {e.Fonte})");
            }
        }
    }

    /// <summary>
    /// Gera um backup dos eventos de energia do usuário no formato JSON.
    /// </summary>
    /// <param name="usuario">Usuário autenticado.</param>
    static void GerarBackup(Usuario usuario)
    {
        var dados = energiaService.ObterEventosPorUsuario(usuario.CPF);
        string arquivo = $"backup_{usuario.CPF}.json";
        backupService.CriarBackup(dados, arquivo);
        Console.WriteLine($"Backup salvo em: {arquivo}");
    }

    /// <summary>
    /// Exibe menu com dicas antes, durante e após a falta de energia.
    /// </summary>
    static void MenuDicas()
    {
        bool voltar = false;

        while (!voltar)
        {
            Console.WriteLine("\n--- DICAS DA SOL ---\n");
            Console.WriteLine("1 - Antes da falta de energia");
            Console.WriteLine("2 - Durante a falta de energia");
            Console.WriteLine("3 - Após a falta de energia");
            Console.WriteLine("\n4 - Voltar");

            Console.Write("\nEscolha uma opção: ");
            string opcao = Console.ReadLine();
            Console.Clear();

            List<Dica> dicas = new();

            switch (opcao)
            {
                case "1":
                    dicas = dicaService.ObterDicasAntes();
                    Console.WriteLine("DICAS ANTES DA FALTA DE ENERGIA:\n");
                    break;
                case "2":
                    dicas = dicaService.ObterDicasDurante();
                    Console.WriteLine("DICAS DURANTE A FALTA DE ENERGIA:\n");
                    break;
                case "3":
                    dicas = dicaService.ObterDicasDepois();
                    Console.WriteLine("DICAS APÓS A FALTA DE ENERGIA:\n");
                    break;
                case "4":
                    voltar = true;
                    continue;
                default:
                    Console.WriteLine("Opção inválida.");
                    continue;
            }

            foreach (var dica in dicas)
            {
                Console.WriteLine($"- {dica}");
            }
        }
    }

    /// <summary>
    /// Calcula prejuízos estimados do estabelecimento com base nos eventos de queda de energia.
    /// </summary>
    /// <param name="usuario">Usuário autenticado.</param>
    static void CalcularPrejuizos(Usuario usuario)
    {
        if (!usuario.PossuiEstabelecimento)
        {
            Console.WriteLine($"{usuario.Nome}, você não possui estabelecimento!");
            return;
        }

        var eventos = energiaService.ObterEventosPorUsuario(usuario.CPF);

        if (eventos.Count == 0)
        {
            Console.WriteLine("Nenhuma queda de energia registrada para calcular prejuízo.");
            return;
        }

        decimal prejuizoTotal = CalculadoraPrejuizo.CalcularPrejuizo(eventos);
        Console.WriteLine($"Total estimado de prejuízo pelas quedas de energia: R$ {prejuizoTotal:F2}");
    }
}