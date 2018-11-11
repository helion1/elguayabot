# ElGuayaBot
SImple yet Guayaba. Telegram Bot for my friends.

```bash
cd docker
docker-compose up -d
```

dotnet ef migrations add initial_identity_migration -c ApplicationDbContext -o Data/Migrations/AspNetIdentity/ApplicationDb
dotnet ef migrations add initial_is4_server_configuration_migration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
dotnet ef migrations add initial_is4_persisted_grant_migration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
