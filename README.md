# Tech Challenger - Gestão de Investimentos
## _The Last Markdown Editor, Ever_

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

**Tech Challenger** é uma aplicação de gestão de investimentos baseada na Clean Architecture, desenvolvida com .NET 8. A aplicação utiliza Docker, SQL Server, Entity Framework, MediatR, Identity, JwtBearer, FluentValidation e AutoMapper para fornecer uma solução robusta e escalável para o gerenciamento de portfólios de investimentos.

## Funcionalidades

- Gestão de Portfólios e Ativos: Crie, edite e visualize portfólios e ativos.
- Transações: Registre transações de compra e venda de ativos.
- Autenticação e Autorização: Proteje a aplicação com autenticação JWT.
- Validação de Dados: Valide dados de entrada usando FluentValidation.
- Mapeamento Automático: Utilize AutoMapper para mapear entre DTOs e entidades.
- API RESTful: Exponha endpoints para interação com clientes e outros sistemas.
 
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
- Num terminal digite: git clone https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos.git
- cd TechChallengeGestaoInvestimentos
- git checkout develop
- dotnet restore
- dotnet build
- Com o Docker Desktop em execução digite o comando para criar o banco pelo docker:
    - docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<S3Nh4F0rT3>" -p 1433:1433 --name sqlserver-tech5 -h sqlserver-tech5 -d mcr.microsoft.com/mssql/server:2019-latest
- Abra a Solution no Visual Studio 2022 e habilite o projeto API como principal:
- Abra o Package Manager Console:
- Em Default Project selecione o **Identity** e rode os comandos:
    - Add-Migration firstMigration -Context TechChallengeIdentityDbContext
    - Update-Database -Context TechChallengeIdentityDbContext
- Ainda em Default Project selecione o **Persistence** e rode os comandos:
    - Add-Migration firstMigrationPersistence -Context TechChallengeGestaoInvestimentosDbContext
    - Update-Database -Context TechChallengeGestaoInvestimentosDbContext


## License

MIT