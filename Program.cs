using Soltrix.Models;
using Soltrix.Services;
using Soltrix.Services.Soltrix.Services;
using Soltrix.Utils;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Security.Cryptography;

class Program
{
    static UsuarioService usuarioService = new();
    static EnergiaService energiaService = new();
    static BackupService backupService = new();
    static DicaService dicaService = new();

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

    static void MostrarBoasVindas()
    {
        Console.WriteLine("=== BEM-VINDO À SOLTRIX ===");
        Console.WriteLine("Olá, seja parte da revolução energética com a Soltrix!");
    }

    static string LerCampoObrigatorio(string label)
    {
        string valor;
        do
        {
            Console.Write($"{label}: ");
            valor = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(valor))
            {
                Console.WriteLine($"{label} é obrigatório. Tente novamente.");
            }
        } while (string.IsNullOrWhiteSpace(valor));

        return valor;
    }

    static Usuario CadastrarUsuario()
    {
        Console.WriteLine("\n=== CADASTRO DE NOVO USUÁRIO ===");

        string nome = LerCampoObrigatorio("Nome");

        string cpf;
        do
        {
            cpf = LerCampoObrigatorio("CPF (somente números)");
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

        string senha = LerCampoObrigatorio("Senha");

        Console.WriteLine("\n--- Endereço ---");

        string cep;
        do
        {
            cep = LerCampoObrigatorio("CEP (somente números)");
            if (!Validador.ValidarCEP(cep))
            {
                Console.WriteLine("CEP inválido. Digite exatamente 8 números (ex: 12345678).");
            }
        } while (!Validador.ValidarCEP(cep));

        string rua;
        rua = LerCampoObrigatorio("Rua");

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
            Bairro = LerCampoObrigatorio("Bairro"),
            Cidade = LerCampoObrigatorio("Cidade"),
            Estado = LerCampoObrigatorio("Estado (sigla)")
        };

        Console.Write("Possui estabelecimento? (s/n): ");
        bool possuiEstabelecimento = Console.ReadLine().ToLower() == "s";

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
                Console.Write("Deseja tentar novamente? (s/n): ");
                tentarLogin = Console.ReadLine().ToLower() == "s";
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

    static void MostrarMenu(Usuario usuario)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- MENU PRINCIPAL SOLTRIX ---");
            Console.WriteLine("1 - Registrar queda de energia");
            Console.WriteLine("2 - Ver histórico de eventos");
            Console.WriteLine("3 - Gerar backup");
            Console.WriteLine("4 - Ver dicas da Sol");
            Console.WriteLine("5 - Calcular prejuízos do estabelecimento");
            Console.WriteLine("0 - Sair");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    RegistrarEvento(usuario);
                    break;
                case "2":
                    VerHistorico(usuario);
                    break;
                case "3":
                    GerarBackup(usuario);
                    break;
                case "4":
                    MenuDicas();
                    break;
                case "5":
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

    static void RegistrarEvento(Usuario usuario)
    {
        EventoEnergia evento = new()
        {
            UsuarioCPF = usuario.CPF,
            DataHora = DateTime.Now,
            EnergiaAtiva = false,
            Fonte = "Usuário"
        };

        Console.Write("Motivo da queda de energia: (Onda de Calor, Tempestade, Manutencao...)");
        evento.Motivo = Console.ReadLine();

        energiaService.RegistrarEvento(evento);
        Console.WriteLine("Evento registrado com sucesso.");
    }

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

    static void GerarBackup(Usuario usuario)
    {
        var dados = energiaService.ObterEventosPorUsuario(usuario.CPF);
        string arquivo = $"backup_{usuario.CPF}.json";
        backupService.CriarBackup(dados, arquivo);
        Console.WriteLine($"Backup salvo em: {arquivo}");
    }

    static void MenuDicas()
    {
        bool voltar = false;

        while (!voltar)
        {
            Console.WriteLine("\n--- DICAS DA SOL ---");
            Console.WriteLine("1 - Antes da falta de energia");
            Console.WriteLine("2 - Durante a falta de energia");
            Console.WriteLine("3 - Após a falta de energia");
            Console.WriteLine("4 - Voltar");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            Console.Clear();

            List<Dica> dicas = new();

            switch (opcao)
            {
                case "1":
                    dicas = dicaService.ObterDicasAntes();
                    Console.WriteLine("DICAS ANTES DA FALTA DE ENERGIA:");
                    break;
                case "2":
                    dicas = dicaService.ObterDicasDurante();
                    Console.WriteLine("DICAS DURANTE A FALTA DE ENERGIA:");
                    break;
                case "3":
                    dicas = dicaService.ObterDicasDepois();
                    Console.WriteLine("DICAS APÓS A FALTA DE ENERGIA:");
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
