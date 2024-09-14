# Tech Challenge - Gest�o de Investimentos

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

**Tech Challenger** � uma aplica��o de gest�o de investimentos baseada na Clean Architecture, desenvolvida com .NET 8. A aplica��o utiliza Docker, SQL Server, Entity Framework, MediatR, Identity, JwtBearer, FluentValidation e AutoMapper para fornecer uma solu��o robusta e escal�vel para o gerenciamento de portf�lios de investimentos.

## Funcionalidades

- Gest�o de Portf�lios e Ativos: Cria, edita e visualiza portf�lios e ativos.
- Transa��es: Registra transa��es de compra e venda de ativos.
- Autentica��o e Autoriza��o: Proteje a aplica��o com autentica��o JWT.
- Valida��o de Dados: Valida dados de entrada usando FluentValidation.
- Mapeamento Autom�tico: Utiliza AutoMapper para mapear entre DTOs e entidades.
- API RESTful: Exponhe endpoints para intera��o com clientes e outros sistemas.

## Diagrama DDD

 
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