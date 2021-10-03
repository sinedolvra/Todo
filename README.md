<h1 align="center"> Todo </h1>
<h3 align="center">A CRUD Todo api</h3>

<div align="center">
<a href="https://github.com/sinedolvra/Todo/actions/workflows/dotnet.yml"><img src="https://github.com/sinedolvra/Todo/actions/workflows/dotnet.yml/badge.svg"></a>
<a href="https://sonarcloud.io/dashboard?id=sinedolvra_Todo"><img src="https://sonarcloud.io/api/project_badges/measure?project=sinedolvra_Todo&metric=alert_status"></a>
<a href="https://sonarcloud.io/dashboard?id=sinedolvra_Todo"><img src="https://sonarcloud.io/api/project_badges/measure?project=sinedolvra_Todo&metric=code_smells"></a>
<a href="https://sonarcloud.io/dashboard?id=sinedolvra_Todo"><img src="https://sonarcloud.io/api/project_badges/measure?project=sinedolvra_Todo&metric=sqale_rating"></a>
<a href="https://sonarcloud.io/dashboard?id=sinedolvra_Todo"><img src="https://sonarcloud.io/api/project_badges/measure?project=sinedolvra_Todo&metric=reliability_rating"></a>
<a href="https://sonarcloud.io/dashboard?id=sinedolvra_Todo"><img src="https://sonarcloud.io/api/project_badges/measure?project=sinedolvra_Todo&metric=bugs"></a>

</div>

## Sobre o Projeto
- Este projeto é uma Api básica para estudos de:
   - CQRS
   - Padrão Mediator
   - Qualidade de código
   - Github Action

## Instalação
1. Instale o .NET Core v5+ <a href="https://dotnet.microsoft.com/download"><img src="https://img.shields.io/badge/.NET%20Core-v5.0%2B-blueviolet"></a>
2. Clone o repositório
```sh
git clone git@github.com:sinedolvra/Todo-Api.git
```
3. Restaure os pacotes da solução
```sh
dotnet restore Todo.sln
```

## Uso da aplicação

### Rodando a aplicação
1. Build a aplicação
```sh
dotnet build
```
2. Execute-a
```sh
dotnet run --project .\src\Todo\DevelopersChallenge2.Application\DevelopersChallenge2.Application.csproj
```
3. Acesse a aplicação
```sh
Acesse https://localhost:5001 ou http://localhost:5000
```

#### Via Docker
1. Na raiz do projeto, basta executar o comando:
```sh
docker-compose up
```

## Contato
<div class="LI-profile-badge"  data-version="v1" data-size="medium" data-locale="pt_BR" data-type="vertical" data-theme="dark" data-vanity="denisolvra"><a class="LI-simple-link" href='https://br.linkedin.com/in/denisolvra?trk=profile-badge'>Denis Oliveira</a></div>