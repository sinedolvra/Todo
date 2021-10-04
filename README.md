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

## About the project
- This project is a basic Api for studies of:
   - CQRS
   - Mediator Pattern
   - Code Quality
   - Github Actions

## Instalação
1. Install the .NET Core v5+ <a href="https://dotnet.microsoft.com/download"><img src="https://img.shields.io/badge/.NET%20Core-v5.0%2B-blueviolet"></a>


2. Clone the repository
```sh
git clone git@github.com:sinedolvra/Todo.git
```
3. Restore packages
```sh
dotnet restore Todo.sln
```

## Application use

### Run the application
1. Build
```sh
dotnet build
```
2. Run it
```sh
dotnet run --project .\src\Todo.Api\Todo.Api.csproj
```
3. Access the application
```sh
Acesse https://localhost:5001 ou http://localhost:5000
```

#### Docker
1. At the root of the project, run the command:
```sh
docker-compose up
```

## Contributing

#### If you want to contribute to this project and make it better, your help is most welcome. 

### How to make a clean pull request

- Create a personal fork of the project on Github.
- Clone the fork on your local machine. Your remote repo on Github is called `origin`.
- Add the original repository as a remote called `upstream`.
- If you created your fork a while ago be sure to pull upstream changes into your local repository.
- Create a new branch to work on! Branch from `develop` if it exists, else from `master`.
- Implement/fix your feature, comment your code.
- Follow the code style of the project, including indentation.
- If the project has tests run them!
- Write or adapt tests as needed.
- Add or change the documentation as needed.
- Push your branch to your fork on Github, the remote `origin`.
- From your fork open a pull request in the correct branch. Target the project's `develop` branch if there is one, else go for `master`!
- Once the pull request is approved and merged you can pull the changes from `upstream` to your local repo and delete
  your extra branch(es).

And last but not least: Always write your commit messages in the present tense. Your commit message should describe what the commit, when applied, does to the code – not what you did to the code.

## Contato
<div class="LI-profile-badge"  data-version="v1" data-size="medium" data-locale="pt_BR" data-type="vertical" data-theme="dark" data-vanity="denisolvra"><a class="LI-simple-link" href='https://br.linkedin.com/in/denisolvra?trk=profile-badge'>Denis Oliveira</a></div>