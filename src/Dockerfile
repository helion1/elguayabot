FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS http://*:5100
EXPOSE 5100

FROM microsoft/dotnet:sdk as builder
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./

# Copy csproj and restore as distinct layers
COPY ElGuayaBot.Api.WebApi/*.csproj ElGuayaBot.Api.WebApi/
COPY ElGuayaBot.Application.Contracts/*.csproj ElGuayaBot.Application.Contracts/
COPY ElGuayaBot.Application.Dto/*.csproj ElGuayaBot.Application.Dto/
COPY ElGuayaBot.Application.Implementation/*.csproj ElGuayaBot.Application.Implementation/
COPY ElGuayaBot.Domain.Contracts/*.csproj ElGuayaBot.Domain.Contracts/
COPY ElGuayaBot.Domain.Entity/*.csproj ElGuayaBot.Domain.Entity/
COPY ElGuayaBot.Domain.Implementation/*.csproj ElGuayaBot.Domain.Implementation/
COPY ElGuayaBot.Infrastructure.Contracts/*.csproj ElGuayaBot.Infrastructure.Contracts/
COPY ElGuayaBot.Infrastructure.Dto/*.csproj ElGuayaBot.Infrastructure.Dto/
COPY ElGuayaBot.Infrastructure.Implementation/*.csproj ElGuayaBot.Infrastructure.Implementation/
COPY ElGuayaBot.Persistence.Contracts/*.csproj ElGuayaBot.Persistence.Contracts/
COPY ElGuayaBot.Persistence.Implementation/*.csproj ElGuayaBot.Persistence.Implementation/
COPY ElGuayaBot.Persistence.Model/*.csproj ElGuayaBot.Persistence.Model/
RUN dotnet restore
COPY . .
WORKDIR /src/ElGuayaBot
RUN dotnet build -c $Configuration -o /app ../ElGuayaBot.sln 

FROM builder as publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app ../ElGuayaBot.sln

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ElGuayaBot.Api.WebApi.dll"]
