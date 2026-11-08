# FTELMarket API

ASP.NET Core Web API (.NET 10) with Entity Framework Core and PostgreSQL.

## Run

1. Start PostgreSQL (the `ftelmarket-postgres` service of the front's `docker-compose.yml`):

   ```bash
   docker compose up -d ftelmarket-postgres
   ```

2. Create the tables and seed data:

   ```bash
   dotnet ef database update
   ```

3. Start the API on `http://localhost:5082`:

   ```bash
   dotnet watch run
   ```

## Routes

| Method | Route |
|---|---|
| GET | `/api/products` |
| POST | `/api/products` |
| PUT | `/api/products/{id}` |
| DELETE | `/api/products/{id}` |
| GET | `/api/categories` |
