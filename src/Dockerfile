FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS http://*:5100
EXPOSE 5100

FROM microsoft/dotnet:sdk as builder
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./

#API
COPY ElGuayabot.Api.WebApi/*.csproj ElGuayabot.Api.WebApi/
#APPLICATION
COPY ElGuayabot.Application.Contract/*.csproj ElGuayabot.Application.Contract/
COPY ElGuayabot.Application.Implementation/*.csproj ElGuayabot.Application.Implementation/
#COMMON
COPY ElGuayabot.Common/*.csproj ElGuayabot.Common/
COPY ElGuayabot.Common.IoC/*.csproj ElGuayabot.Common.IoC/
#DOMAIN
COPY ElGuayabot.Domain/*.csproj ElGuayabot.Domain/
COPY ElGuayabot.Domain.Entity/*.csproj ElGuayabot.Domain.Entity/
#INFRASTRUCTURE
COPY ElGuayabot.Infrastructure.Contract/*.csproj ElGuayabot.Infrastructure.Contract/
COPY ElGuayabot.Infrastructure.Implementation/*.csproj ElGuayabot.Infrastructure.Implementation/
#PERSISTENCE
COPY ElGuayabot.Persistence.Contract/*.csproj ElGuayabot.Persistence.Contract/
COPY ElGuayabot.Persistence.Implementation/*.csproj ElGuayabot.Persistence.Implementation/

RUN dotnet restore
COPY . .
WORKDIR /src/ElGuayabot
RUN dotnet build -c $Configuration -o /app ../ElGuayabot.sln 

FROM builder as publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app ../ElGuayabot.sln

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ElGuayabot.Api.WebApi.dll"]
