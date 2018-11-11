# ElGuayaBot
Simple yet Guayaba. Telegram Bot for my friends.


Setup:
```bash
# Retore nugget packages
dotnet restore

# Start docker containers
cd docker
docker-compose up -d

# Run migrations
cd ../ElGuayaBot.Api.Identity
dotnet ef database update --context ApplicationDbContext
dotnet ef database update --context ConfigurationDbContext
dotnet ef database update --context PersistedGrantDbContext 
```

## Other info

Migrations were created running these commands:

```bash
dotnet ef migrations add initial_identity_migration -c ApplicationDbContext -o Data/Migrations/AspNetIdentity/ApplicationDb

dotnet ef migrations add initial_is4_server_configuration_migration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb

dotnet ef migrations add initial_is4_persisted_grant_migration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
```