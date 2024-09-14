# Tech Challenger - Gest�o de Investimentos
## _The Last Markdown Editor, Ever_

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

**Tech Challenger** � uma aplica��o de gest�o de investimentos baseada na Clean Architecture, desenvolvida com .NET 8. A aplica��o utiliza Docker, SQL Server, Entity Framework, MediatR, Identity, JwtBearer, FluentValidation e AutoMapper para fornecer uma solu��o robusta e escal�vel para o gerenciamento de portf�lios de investimentos.

## Funcionalidades

- Gest�o de Portf�lios e Ativos: Crie, edite e visualize portf�lios e ativos.
- Transa��es: Registre transa��es de compra e venda de ativos.
- Autentica��o e Autoriza��o: Proteje a aplica��o com autentica��o JWT.
- Valida��o de Dados: Valide dados de entrada usando FluentValidation.
- Mapeamento Autom�tico: Utilize AutoMapper para mapear entre DTOs e entidades.
- API RESTful: Exponha endpoints para intera��o com clientes e outros sistemas.
 
## Tecnologias

- NET 8 - A plataforma para desenvolvimento da aplica��o.
- Docker - Para containeriza��o e execu��o consistente em diferentes ambientes.
- SQL Server - Banco de dados relacional para armazenamento de dados.
- Entity Framework - ORM para intera��o com o banco de dados.
- MediatR - Para a implementa��o de padr�es CQRS e Mediator.
- Identity - Para autentica��o e gerenciamento de usu�rios.
- JwtBearer - Para autentica��o baseada em tokens JWT.
- FluentValidation - Para valida��o de dados de entrada.
- AutoMapper - Para mapeamento entre objetos DTO e entidades.

## Instala��o

**Pr�-requisitos**
Certifique-se de ter o Docker e o .NET 8 instalados em seu sistema.

**Configura��o**
- Num terminal digite: git clone https://github.com/MarcondesOliveira/TechChallengeGestaoInvestimentos.git
- cd TechChallengeGestaoInvestimentos
- git checkout develop
- dotnet restore
- dotnet build
- Com o Docker Desktop em execu��o digite o comando para criar o banco pelo docker:
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