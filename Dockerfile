FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

LABEL maintaner="sinedolvra"

WORKDIR /app
EXPOSE 80
EXPOSE 443

# -- Set env vars
ENV ASPNETCORE_ENVIRONMENT=Docker

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR "/src"
COPY ["src/Todo.Api/*.csproj", "Todo.Api/"]
COPY ["src/Todo.Domain/*.csproj", "Todo.Domain/"]
COPY ["src/Todo.Infra/*.csproj", "Todo.Infra/"]
COPY ["src/Todo.Shared/*.csproj", "Todo.Shared/"]
RUN dotnet restore "Todo.Api/Todo.Api.csproj"
COPY . .

WORKDIR "src/Todo.Api"

FROM build AS publish
RUN dotnet publish "Todo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Api.dll"]
