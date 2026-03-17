# Tech Challenge - Gestão de Investimentos

<div style="text-align: center;">
  <img src="https://img.shields.io/badge/.NET%208-333333?style=flat&logo=.net&logoColor=white" alt=".NET 8" />
  <img src="https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white" alt="Docker" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/Entity%20Framework-5C2D91?style=flat&logo=dotnet&logoColor=white" alt="Entity Framework" />
  <img src="https://img.shields.io/badge/MediatR-004B87?style=flat&logo=dotnet&logoColor=white" alt="MediatR" />
  <img src="https://img.shields.io/badge/Identity-0078D4?style=flat&logo=microsoft&logoColor=white" alt="Identity" />
  <img src="https://img.shields.io/badge/JWT%20Bearer-000000?style=flat&logo=json-web-tokens&logoColor=white" alt="JwtBearer" />
  <img src="https://img.shields.io/badge/FluentValidation-6ABBD0?style=flat&logo=dotnet&logoColor=white" alt="FluentValidation" />
  <img src="https://img.shields.io/badge/AutoMapper-003B57?style=flat&logo=dotnet&logoColor=white" alt="AutoMapper" />
  <img src="https://img.shields.io/badge/Blazor-512BD4?style=flat&logo=blazor&logoColor=white" alt="Blazor" />
  <img src="https://img.shields.io/badge/xUnit-5C2D91?style=flat&logo=dotnet&logoColor=white" alt="xUnit" />
  <img src="https://img.shields.io/badge/status-in_development-yellow" alt="Em Desenvolvimento" />
  <img src="https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos/actions/workflows/ci.yml/badge.svg" alt="CI" />
</div>

**Tech Challenge** é uma aplicação de gestão de investimentos baseada na Clean Architecture, desenvolvida com .NET 8. A aplicação utiliza Docker, SQL Server, Entity Framework, MediatR, Identity, JwtBearer, FluentValidation e AutoMapper para fornecer uma solução robusta e escalável para o gerenciamento de portfólios de investimentos.

## Funcionalidades

- **Gestão de Portfólios e Ativos:** Cria, edita e visualiza portfólios e ativos.
- **Transações:** Registra transações de compra e venda de ativos automaticamente.
- **Autenticação e Autorização:** Protege a aplicação com autenticação JWT.
- **Validação de Dados:** Valida dados de entrada usando FluentValidation.
- **Mapeamento Automático:** Utiliza AutoMapper para mapear entre DTOs e entidades.
- **API RESTful:** Expõe endpoints para interação com clientes e outros sistemas.
- **Frontend Blazor:** Interface web SPA (Single Page Application) com Blazor WebAssembly.
- **Testes Automatizados:** Cobertura de testes unitários com xUnit e Moq.

## Diagrama DDD

![DDD](https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos/blob/blazor-app-modificado/Documentation/DDD.png)

## Arquitetura

O projeto segue os princípios da **Clean Architecture**, organizado em camadas bem definidas:

```
┌─────────────────────────────────────────────┐
│              Presentation Layer             │
│  API (ASP.NET Core) │ Frontend (Blazor WASM)│
├─────────────────────────────────────────────┤
│              Application Layer              │
│     CQRS (MediatR) │ DTOs │ Validações      │
├─────────────────────────────────────────────┤
│               Domain Layer                  │
│    Entidades │ Interfaces │ Enumerações      │
├─────────────────────────────────────────────┤
│           Infrastructure Layer              │
│  Persistence (EF Core) │ Identity │ Serviços│
└─────────────────────────────────────────────┘
```

**Padrões de projeto aplicados:**
- **CQRS** (Command Query Responsibility Segregation) via MediatR
- **Repository Pattern** com repositório genérico assíncrono
- **Mediator Pattern** para desacoplamento entre camadas
- **DTO Pattern** com AutoMapper

## Estrutura do Projeto

```
TechChallengeGestaoInvestimentos/
├── TechChallengeGestaoInvestimentos.API/          # Camada de API (Controllers, Middleware)
│   ├── Controllers/                               # Endpoints REST
│   │   ├── AssetController.cs
│   │   ├── PortfolioController.cs
│   │   └── TransactionController.cs
│   ├── Middleware/                                # Tratamento global de exceções
│   └── Program.cs                                # Ponto de entrada da aplicação
├── TechChallengeGestaoInvestimentos.Application/  # Camada de Aplicação (CQRS)
│   └── Features/
│       ├── Assets/        # Commands e Queries de Ativos
│       ├── Portfolios/    # Commands e Queries de Portfólios
│       └── Transactions/  # Commands e Queries de Transações
├── TechChallengeGestaoInvestimentos.Domain/       # Camada de Domínio (Entidades)
│   ├── Entities/          # Portfolio, Asset, Transaction
│   ├── Enum/              # AssetType, TransactionType, Code
│   └── Interfaces/        # Contratos de repositório
├── TechChallengeGestaoInvestimentos.Persistence/  # Camada de Dados (EF Core)
├── TechChallengeGestaoInvestimentos.Identity/     # Autenticação e Autorização
├── TechChallengeGestaoInvestimentos.Infrastructure/ # Serviços transversais
├── TechChallengeGestaoInvestimentos.AppWebAssembly/ # Frontend Blazor WebAssembly
└── TechChallengeGestaoInvestimentos.Application.Tests/ # Testes unitários
```

## Tecnologias

| Tecnologia | Versão | Descrição |
|---|---|---|
| .NET | 8.0 | Plataforma de desenvolvimento |
| ASP.NET Core | 8.0 | Framework para a API REST |
| Blazor WebAssembly | 8.0 | Frontend SPA |
| Entity Framework Core | 8.0.8 | ORM para acesso ao banco de dados |
| MediatR | 12.4.0 | Implementação do padrão CQRS/Mediator |
| AutoMapper | 13.0.1 | Mapeamento entre objetos DTO e entidades |
| FluentValidation | 11.9.2 | Validação de dados de entrada |
| JWT Bearer | 8.0.8 | Autenticação baseada em tokens |
| ASP.NET Identity | 8.0.8 | Gerenciamento de usuários |
| SQL Server | 2019+ | Banco de dados relacional |
| Docker | - | Containerização |
| xUnit | 2.5.3 | Framework de testes unitários |
| Moq | 4.20.72 | Mocking para testes |
| FluentAssertions | 6.12.1 | Asserções fluentes nos testes |

## Testes

O projeto conta com testes unitários organizados por funcionalidade:

```
TechChallengeGestaoInvestimentos.Application.Tests/
├── Assets/
│   ├── CreateAssetTests.cs
│   ├── GetAssetListTests.cs
│   └── UpdateAssetTests.cs
├── Portfolios/
│   ├── CreatePortfolioTests.cs
│   ├── DeletePortfolioTests.cs
│   └── GetPortfolioListTests.cs
└── Transactions/
    └── GetTransactionsForMonthTests.cs
```

Para executar os testes:

```bash
dotnet test
```

## Instalação

**Pré-requisitos**

Certifique-se de ter o Docker e o .NET 8 instalados em seu sistema.

**Configuração**

- Num terminal digite:

      git clone https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos.git
      cd TechChallengeGestaoInvestimentos
      git checkout develop
      dotnet restore
      dotnet build

- Com o Docker Desktop em execução, digite o comando para criar o banco pelo Docker:

      docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<S3Nh4F0rT3>" -p 1433:1433 --name sqlserver-tech5 -h sqlserver-tech5 -d mcr.microsoft.com/mssql/server:2019-latest

- Abra a Solution no Visual Studio 2022 e habilite o projeto API como principal:

![StartupProject](https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos/blob/blazor-app-modificado/Documentation/startupproject.png)

- Abra o Package Manager Console:

![PackageManagerConsole](https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos/blob/blazor-app-modificado/Documentation/packagemanagerconsole.png)

- Em Default Project selecione o **Identity** e rode os comandos:

![Identity](https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos/blob/blazor-app-modificado/Documentation/identity.png)

      Add-Migration firstMigration -Context TechChallengeIdentityDbContext
      Update-Database -Context TechChallengeIdentityDbContext

- Ainda em Default Project selecione o **Persistence** e rode os comandos:

![Persistence](https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos/blob/blazor-app-modificado/Documentation/persistence.png)

      Add-Migration firstMigrationPersistence -Context TechChallengeGestaoInvestimentosDbContext
      Update-Database -Context TechChallengeGestaoInvestimentosDbContext

## Roteiro de uso da API

**Autenticação**

Para usar o sistema, é necessário estar autenticado:

1. Criar usuário (`POST /api/auth/register`)
2. Fazer login (`POST /api/auth/login`) — obter o token JWT
3. Usar o token JWT no cabeçalho `Authorization: Bearer {token}` nas demais requisições

**Gestão de Portfólios e Ativos**

- **Portfólio:**
  - Criar portfólio
  - Um portfólio só pode ser deletado se não houver ativos associados ainda não vendidos (Status `A`).
  - O portfólio muda de status para `I` (inativo) após ser deletado.

- **Ativo:**
  - Ao criar um ativo, uma transação de compra é criada automaticamente e o ativo recebe o status `A`.
  - Um ativo só pode ser consultado se ainda não tiver sido vendido.
  - Ao editar um ativo (venda), uma transação de venda é criada e o status muda para `I`.

**Transações Automáticas**

- Ao criar um ativo → transação de **compra** criada automaticamente com quantidade `1`.
- Ao editar um ativo (venda) → transação de **venda** criada automaticamente com quantidade `2`.

## Exemplo de payloads

**Criar Portfólio**

```json
{
  "name": "Ações Tecnologia",
  "description": "Portfólio de ações de tecnologia"
}
```

**Criar Ativo**

```json
{
  "assetType": 3,
  "name": "Bitcoin Teste",
  "date": "2024-09-13T23:43:08.000Z",
  "code": 2,
  "portfolioId": "A92B11F1-F0B7-486A-A895-8DC9B7B47803"
}
```

**Atualizar Ativo (Venda)**

```json
{
  "assetId": "78A752FE-B72D-4355-B548-8E63FF8CED07",
  "portfolioId": "A92B11F1-F0B7-486A-A895-8DC9B7B47803",
  "price": 25000,
  "transactionDate": "2024-09-14T00:12:03.768Z"
}
```

**Consultar Transações**

```json
{
  "date": "2024-09-14",
  "page": 1,
  "size": 10
}
```

## Valores válidos para AssetType e Code

**AssetType**

| Valor | Nome | Descrição |
|---|---|---|
| 1 | Stocks | Ações |
| 2 | Bonds | Títulos |
| 3 | Cryptocurrencies | Criptomoedas |

**Code**

| Valor | Código | Descrição |
|---|---|---|
| 1 | AAPL | Apple |
| 2 | BTC | Bitcoin |

> O Client em Blazor irá interpretar os valores com a descrição, de forma que o usuário possa selecionar de acordo com o nome/tipo do ativo e o código. <img src="https://img.shields.io/badge/status-in_development-yellow" alt="Em Desenvolvimento" />

> **Obs.:** Para evitar erro de build no início do processo ou nas migrations, [Desligue, descarregue ou dê unload] no projeto Blazor em Presentation.

## Consulta ao banco

Para consultar os registros no banco de dados, utilize o Microsoft SQL Server Management Studio com as seguintes configurações:

![ConsultaSQL](https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos/blob/develop/Documentation/consultasql.png)

Qualquer outro gerenciador de banco de dados compatível com SQL Server também pode ser utilizado.

## CI/CD

O projeto utiliza **GitHub Actions** para integração e entrega contínua. O pipeline é acionado em pushes e pull requests para as branches `master` e `develop`, executando as seguintes etapas:

1. Checkout do código
2. Configuração do .NET 8 SDK
3. Restauração de dependências (`dotnet restore`)
4. Build em modo Release (`dotnet build`)
5. Execução dos testes (`dotnet test`)

## License

MIT
