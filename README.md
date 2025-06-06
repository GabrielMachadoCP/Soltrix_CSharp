# Soltrix  
Onde o calor vira potência

## Integrantes do grupo:

- Gabriel Machado Carrara Pimentel – RM 99880  
- Leticia Cristina Gandarez Resina – RM 98069  
- Vitor Hugo Gonçalves Rodrigues – RM 97758  

---

## Documento descritivo do projeto:
**[Acessar Documento](https://docs.google.com/document/d/1ION-ZlJLDRZeh8MAy2C9sj2bXQ-QciGbk2SR1C8mEPE/edit?usp=sharing)**

---

## 💡 Explicação e Finalidade do Programa

**Soltrix** é um sistema voltado à gestão e prevenção de crises energéticas, com foco especial em regiões impactadas 
por quedas frequentes de energia causadas por fenômenos como ondas de calor. 
O programa permite que usuários registrem eventos de queda, acompanhem previsões de falhas, consultem histórico de ocorrências, 
acessem dicas úteis em diferentes momentos da crise e calculem possíveis prejuízos financeiros – 
principalmente voltado para estabelecimentos comerciais.

Este projeto faz parte da Global Solution do curso de Engenharia de Software da FIAP, com o objetivo de integrar 
conceitos de sustentabilidade, tecnologia e automação em um sistema funcional e realista.

---

## 🛠️ Funcionalidades

- Registro de quedas de energia com data e motivo
- Visualização de previsões de falhas energéticas por endereço
- Histórico de eventos registrados
- Geração de backup dos dados (formato `.json`) na pasta C: de seu computador
- Acesso a dicas úteis da assistente Sol em três momentos: antes, durante e após a falta de energia
- Cálculo estimado de prejuízos financeiros para estabelecimentos

---

## ▶️ Instruções de Execução

1. Clone ou baixe o repositório:
   ```bash
   git clone https://github.com/GabrielMachadoCP/Soltrix_CSharp
   ```

2. Abra o projeto em um editor compatível com C# (como Visual Studio 2022 ou superior).

3. Compile o projeto e execute o `Program.cs` (aplicação de console).

4. Siga as instruções no terminal para:
   - Cadastrar um novo usuário
   - Realizar login
   - Navegar pelo menu principal e utilizar as funcionalidades

---

## 📦 Dependências

O projeto utiliza bibliotecas padrão da linguagem **C# (.NET 6.0 ou superior)**. 
Certifique-se de que seu ambiente tenha o SDK adequado instalado. 
Além disso utilizamos o Bcrypt para criptografar a senha do usuário e deixar o sistema mais seguro contra ataques cibernéticos.

**Namespaces usados:**

- `System`
- `System.Collections.Generic`
- `System.Globalization`
- `System.Security.Cryptography`

Além disso, o projeto depende dos seguintes arquivos/classes organizados em namespaces personalizados:

- `Soltrix.Models`: classes `Usuario`, `Endereco`, `EventoEnergia`, `Dica`, etc.
- `Soltrix.Services`: serviços `UsuarioService`, `EnergiaService`, `BackupService`, `DicaService`
- `Soltrix.Utils`: classes auxiliares como `Validador` e `CalculadoraPrejuizo`

---

## 📁 Estrutura de Pastas

```
Soltrix/
│
├── Program.cs                 # Classe principal com o fluxo de execução do sistema
│
├── Models/                   # Classes de modelo (dados)
│   ├── Usuario.cs
│   ├── Endereco.cs
│   ├── EventoEnergia.cs
│   ├── Dica.cs
│
├── Services/                 # Camada de serviços (lógica de negócio)
│   ├── UsuarioService.cs
│   ├── EnergiaService.cs
│   ├── BackupService.cs
│   ├── DicaService.cs
│
├── Utils/                    # Utilitários (validações, cálculos)
│   ├── Validador.cs
│   ├── CalculadoraPrejuizo.cs
|   ├── Criptografia.cs
│

 C:\Backups_{cpf}\                   # Pasta gerada com arquivos de backup JSON em C:
```

---

## ✅ Requisitos Atendidos

- Código limpo, comentado e organizado
- Uso de orientação a objetos (encapsulamento, coesão)
- Tratamento de exceções com `try-catch`
- Funcionalidades úteis e alinhadas ao tema do projeto
- Projeto publicado no GitHub com README completo

---

## 🌱 Tecnologias

- C#
- .NET 6.0
- Programação orientada a objetos
- Sustentabilidade e automação aplicadas ao setor energético

---

## 📄 Licença

Este projeto é de uso educacional no contexto da FIAP. Reutilização para fins acadêmicos deve ser autorizada pelos autores.
