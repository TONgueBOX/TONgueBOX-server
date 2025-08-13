# Tongue App Backend

## Step-by-step Setup Guide

### 1. Install .NET SDK
Install **.NET SDK 10.0.0-preview.7.25380.108**:  
[Download for Windows x64](https://builds.dotnet.microsoft.com/dotnet/Sdk/10.0.100-preview.7.25380.108/dotnet-sdk-10.0.100-preview.7.25380.108-win-x64.exe)

---

### 2. Create a Local Database in Docker
Run PostgreSQL 15 in Docker:

```bash
docker run -d --name Tongue-Postgres --restart=no -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=local -v tongue_pg_data:/var/lib/postgresql/data  -p 5432:5432 postgres:15
```

---

### 3. Update Database with Migrations
Run EF Core migrations:

```bash
dotnet ef database update --project Tongue.Data\Tongue.Data.csproj --startup-project Tongue.Web\Tongue.Web.csproj --context Tongue.Data.DbContexts.TonguePgDbContext --configuration Debug
```

---

### 4. Run the Application
Run with HTTPS:

```bash
dotnet run --project Tongue.Web\Tongue.Web.csproj --launch-profile https
```

Run with HTTP:

```bash
dotnet run --project Tongue.Web\Tongue.Web.csproj --launch-profile http
```

---

### 5. Swagger UI
- HTTP: [http://localhost:5256/swagger/index.html](http://localhost:5256/swagger/index.html)
- HTTPS: [https://localhost:7098/swagger/index.html](https://localhost:7098/swagger/index.html)

---

## Additional Commands

### Add a New Migration
Change ```MIGRATION_NAME_EXAMPLE``` to your migration name
```bash
dotnet ef migrations add --project Tongue.Data\Tongue.Data.csproj --startup-project Tongue.Web\Tongue.Web.csproj --context Tongue.Data.DbContexts.TonguePgDbContext --configuration Debug MIGRATION_NAME_EXAMPLE --output-dir Migrations
```

### Update Database
```bash
dotnet ef database update --project Tongue.Data\Tongue.Data.csproj  --startup-project Tongue.Web\Tongue.Web.csproj --context Tongue.Data.DbContexts.TonguePgDbContext --configuration Debug
```
