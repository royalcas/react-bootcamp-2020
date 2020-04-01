# Health Api Dot Net Core 3.1.3

This project has been created using the Dot Net Core SDK

# Mapping

Mapping made using [Mapster](https://github.com/MapsterMapper/Mapster/wiki/Mappers)

## Entity Framework Commands

### Add Migrations

Visual Studio Nuget Package Manager:

```
Add-Migration InitialCreate -s HealthApi.WebApi -Context HealthAppContext
```

```
Script-Migration -s HealthApi.WebApi -Context HealthAppContext
```

```
Remove-Migration Recommendations -s HealthApi.WebApi -Context HealthAppContext
```

[More Information about Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
