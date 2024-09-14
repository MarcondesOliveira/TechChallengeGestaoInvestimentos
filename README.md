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
  <img src="https://img.shields.io/badge/status-in_development-yellow" alt="Em Desenvolvimento" />
</div>

**Tech Challenge** é uma aplicação de gestão de investimentos baseada na Clean Architecture, desenvolvida com .NET 8. A aplicação utiliza Docker, SQL Server, Entity Framework, MediatR, Identity, JwtBearer, FluentValidation e AutoMapper para fornecer uma solução robusta e escalável para o gerenciamento de portfólios de investimentos.

## Funcionalidades

- Gestão de Portfólios e Ativos: Cria, edita e visualiza portfólios e ativos.
- Transações: Registra transações de compra e venda de ativos.
- Autenticação e Autorização: Proteje a aplicação com autenticação JWT.
- Validação de Dados: Valida dados de entrada usando FluentValidation.
- Mapeamento Automático: Utiliza AutoMapper para mapear entre DTOs e entidades.
- API RESTful: Exponhe endpoints para interação com clientes e outros sistemas.

## Diagrama DDD

![DDD](https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos/blob/blazor-app-modificado/Documentation/DDD.png)
 
## Tecnologias

- NET 8 - A plataforma para desenvolvimento da aplicação.
- Docker - Para containerização e execução consistente em diferentes ambientes.
- SQL Server - Banco de dados relacional para armazenamento de dados.
- Entity Framework - ORM para interação com o banco de dados.
- MediatR - Para a implementação de padrões CQRS e Mediator.
- Identity - Para autenticação e gerenciamento de usuários.
- JwtBearer - Para autenticação baseada em tokens JWT.
- FluentValidation - Para validação de dados de entrada.
- AutoMapper - Para mapeamento entre objetos DTO e entidades.

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
- Com o Docker Desktop em execução digite o comando para criar o banco pelo docker:
    
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


## Roteiro de uso da Api
**Autenticação**
    - Para usar o sistema, é necessário estar logado

        - Criar usuário
        - Fazer login
**Gestão de Portfólios e Ativos**
    - Portfólio

        - Criar portfólio
        - Um portfólio só pode ser deletado se não houver ativos associados ainda não vendidos (Status 'A').
        - O portfólio muda de status para 'I' (inativo) após a venda de todos os ativos.
**Ativo**
    - Criar ativo

    - Ao criar um ativo, uma transação de compra é criada e o ativo recebe o status 'A'.
    - Um ativo só pode ser consultado se ainda não tiver sido vendido.
    - Ao editar um ativo, uma transação de venda é criada e o status muda para 'I'.
**Transações Automáticas**

    - Ao criar um ativo, uma transação de compra é criada automaticamente com a quantidade definida como 1.
    - Ao editar um ativo, uma transação de venda é criada automaticamente com a quantidade definida como 2.


## Exemplo de payloads
**Criar Portfólio**

    {
      "name": "Ações deletar 2",
      "description": "Portfólio de ações"
    }

**Criar Ativo**

    {
      "assetType": 3,
      "name": "Bitcoin Teste",
      "date": "2024-09-13T23:43:08.000Z",
      "code": 2,
      "portfolioId": "A92B11F1-F0B7-486A-A895-8DC9B7B47803"
    }

**Atualizar Ativo**

    {
      "assetId": "78A752FE-B72D-4355-B548-8E63FF8CED07",
      "portfolioId": "A92B11F1-F0B7-486A-A895-8DC9B7B47803",
      "price": 25000,
      "transactionDate": "2024-09-14T00:12:03.768Z"
    }

**Consultar Transações**

    {
      "date": "2024-09-14",
      "page": 1,
      "size": 10
    }

## Valoes válidos para AssetType e Code
**AssetType**

    1 = Stocks (Ações)
    2 = Bonds (Títulos)
    3 = Cryptocurrencies (Criptomoedas)

**Code**

    1 = AAPL (Apple)
    2 = BTC (Bitcoin)

- O Client em Blazor irá interpretar os valores com a descrição de forma que possa ser selecionado de acordo com o nome/tipo do ativo e o nome/tipo do Codigo <img src="https://img.shields.io/badge/status-in_development-yellow" alt="Em Desenvolvimento" />

## Consulta ao banco
**Como fazer consulta dos registro no banco de dados**
- Eu usei o Microsoft SQL Server Management com as seguintes configurações:
![ConsultaSQL](https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos/blob/develop/Documentation/consultasql.png)
   
- Mas qualquer Gerenciador de banco de dados poder ser utilizado


## License

MIT