# TestePge

Este projeto foi desenvolvido utilizando a versão 7.0 do .NET e segue a arquitetura da "cebola", dividida em cinco camadas:

## Domain
Nesta camada, você encontrará o modelo de domínio da aplicação, que define as entidades e regras de negócios além do diagrama de classes.

## Infra.DataBase
Esta camada lida com todas as operações relacionadas ao banco de dados, incluindo persistência de dados. Foi implementado o padrão Repository e Unity of Work, e o Entity Framework foi utilizado como ORM (Object-Relational Mapping).

## Infra.IoC
Aqui, é aplicado o princípio de Inversão de Controle (IoC - Inversion of Control), permitindo uma melhor gerência das dependências da aplicação.

## Application
Nesta camada, estão os serviços da aplicação. O projeto utiliza a abordagem CQRS (Command Query Responsibility Segregation) com o pacote MediatR e FluentResults. Todos os comandos (Commands) e consultas (Queries) estão na pasta "features". Também é feita a validação dos dados de entrada na API com o uso do FluentValidation e o tratamento de erros é realizado com o FluentResults.

## Presentation
Aqui se encontram os endpoints da aplicação, responsáveis por lidar com as requisições HTTP. Além disso, foi implementado um Response Adapter para adaptar as respostas de acordo com o tipo de resposta ou erro lançado pelos comandos e consultas.

## Execução do Projeto
Para executar o projeto, siga os passos abaixo:

1. Altere a string de conexão no arquivo `appsettings.json` de acordo com a configuração do seu ambiente.

2. No Console do NuGet Package Manager, execute o comando `update-database` na camada `Infra.DataBase` para criar as tabelas do banco de dados.

3. Defina a camada `Application` como o projeto de inicialização.

4. Ao executar a aplicação, o banco de dados será populado automaticamente.

Certifique-se de que todas as dependências estejam instaladas corretamente antes de executar o projeto.
