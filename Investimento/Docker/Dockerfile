# _____________SQL_____________#

FROM mcr.microsoft.com/mssql/server:2022-latest AS db
WORKDIR /app

# Definir variáveis
ENV ACCEPT_EULA=Y \
    MSSQL_SA_PASSWORD=P4ssW0rd \
    MSSQL_PID=Express

# Mudar para usuário root para instalar dependências
USER root

# Instalar SQLCMD, telnet e drivers ODBC
RUN apt-get update \
    && apt-get install -y curl apt-transport-https gnupg telnet \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && echo "deb [arch=amd64] https://packages.microsoft.com/debian/10/prod buster main" | tee /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev telnet \
    && apt-get clean

# Adicionar SQLCMD ao PATH
ENV PATH="$PATH:/opt/mssql-tools/bin"

# Dá permissão ao entrypoint.sh
RUN chmod +x /docker-entrypoint-initdb.d/entrypoint.sh

# Criar diretório para os scripts SQL
RUN mkdir -p /docker-entrypoint-initdb.d

# Copiar os scripts de inicialização
COPY sql-scripts /docker-entrypoint-initdb.d/

# Mudar para usuário padrão
USER mssql


# _____________API_____________#

# Parte 1

# Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar arquivos do projeto para restaurar pacotes
COPY *.sln ./
COPY Investimento.Api/*.csproj Investimento.Api/
COPY Investimento.App/*.csproj Investimento.App/
COPY Investimento.Domain/*.csproj Investimento.Domain/
COPY Investimento.Repository/*.csproj Investimento.Repository/
COPY Investimento.CrossHelpers/*.csproj Investimento.CrossHelpers/
COPY Investimento.IoC/*.csproj Investimento.IoC/
COPY Investimento.Tests/*.csproj Investimento.Tests/
RUN dotnet restore

# Copiar todo o código e compilar a aplicação
COPY . .
RUN dotnet publish -c Release -o /out


# Parte 2

# Configuração do ambiente
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Instalar SQLCMD e telnet na API
RUN apt-get update \
    && apt-get install -y curl apt-transport-https gnupg telnet \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && echo "deb [arch=amd64] https://packages.microsoft.com/debian/10/prod buster main" | tee /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y mssql-tools telnet \
    && apt-get clean
# Executar migration
#CMD ["sh", "-c", "dotnet ef database update && dotnet Investimento.Api.dll"]

# Expor API
EXPOSE 5217
ENTRYPOINT ["dotnet", "Investimento.Api.dll"]