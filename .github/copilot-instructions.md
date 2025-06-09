# .NET Core 8.0 Database Migration Instructions

## Project Setup and Configuration

### 1. Create New .NET Core 8.0 Project

```bash
dotnet new webapi -n MigrationDemo
cd MigrationDemo
```

### 2. Install Required NuGet Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 3. Connection String Configuration

Update `appsettings.json` with SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MigrationDemoDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

## Entity Framework Setup

### 4. Create DbContext Class

Create `Data/ApplicationDbContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;

namespace MigrationDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Add your DbSets here
        // Example: public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
        }
    }
}
```

### 5. Register DbContext in Program.cs

Add the following to `Program.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using MigrationDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Other service registrations...
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure pipeline...
```

## Entity Models

### 6. Create Entity Models

Create model classes in `Models/` folder. Example `Models/User.cs`:

```csharp
using System.ComponentModel.DataAnnotations;

namespace MigrationDemo.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}
```

### 7. Update DbContext with DbSets

Add your entities to `ApplicationDbContext.cs`:

```csharp
public DbSet<User> Users { get; set; }
```

## Migration Commands

### 8. Create Initial Migration

```bash
dotnet ef migrations add InitialCreate
```

### 9. Update Database

```bash
dotnet ef database update
```

### 10. Common Migration Commands

```bash
# Add new migration
dotnet ef migrations add [MigrationName]

# Update database to latest migration
dotnet ef database update

# Update to specific migration
dotnet ef database update [MigrationName]

# Remove last migration (if not applied to database)
dotnet ef migrations remove

# List all migrations
dotnet ef migrations list

# Generate SQL script
dotnet ef migrations script

# Drop database
dotnet ef database drop
```

## Migration Best Practices

### 11. Migration Naming Convention

- Use descriptive names: `AddUserTable`, `UpdateUserEmailColumn`, `CreateIndexOnUserEmail`
- Use PascalCase
- Include the action and affected entity

### 12. Data Seeding

Add seed data in `OnModelCreating` method:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<User>().HasData(
        new User { Id = 1, Name = "Admin User", Email = "admin@example.com" },
        new User { Id = 2, Name = "Test User", Email = "test@example.com" }
    );
}
```

### 13. Custom Migration Operations

For complex migrations, customize in the migration file:

```csharp
protected override void Up(MigrationBuilder migrationBuilder)
{
    // Auto-generated code...

    // Custom SQL
    migrationBuilder.Sql("UPDATE Users SET IsActive = 1 WHERE IsActive IS NULL");
}
```

## Troubleshooting

### 14. Common Issues and Solutions

**Issue: "No migrations configuration type was found"**

- Ensure EntityFrameworkCore.Tools is installed
- Verify DbContext is properly registered

**Issue: "Unable to create an object of type 'ApplicationDbContext'"**

- Add parameterless constructor or implement IDesignTimeDbContextFactory

**Issue: Connection string problems**

- Verify SQL Server is running on localhost
- Check connection string format
- Ensure database exists or can be created

### 15. Environment-Specific Configurations

Create separate `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MigrationDemo_Dev;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

## Advanced Migration Scenarios

### 16. Code-First Approach Workflow

1. Create/modify entity models
2. Add migration: `dotnet ef migrations add [Name]`
3. Review generated migration code
4. Apply migration: `dotnet ef database update`
5. Test changes

### 17. Production Deployment

```bash
# Generate SQL script for production
dotnet ef migrations script --output migration.sql

# Or generate from specific migration
dotnet ef migrations script [FromMigration] [ToMigration] --output migration.sql
```

### 18. Rollback Strategy

```bash
# Rollback to previous migration
dotnet ef database update [PreviousMigrationName]

# Remove migration files (if needed)
dotnet ef migrations remove
```

## Testing Migrations

### 19. Integration Testing Setup

Create test DbContext with in-memory database for testing:

```csharp
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("TestDatabase"));
```

### 20. Verify Migration Success

- Check database schema matches expectations
- Verify data integrity after migrations
- Test application functionality
- Validate indexes and constraints

## Final Checklist

- [✅] Project created with .NET Core 8.0
- [✅] Required NuGet packages installed
- [✅] Connection string configured
- [✅] DbContext created and registered
- [✅] Entity models defined
- [✅] Initial migration created
- [ ] Database updated successfully
- [ ] Migration commands tested
- [ ] Seed data configured (if needed)
- [ ] Environment-specific configs set up

## Quick Reference Commands

```bash
# Project setup
dotnet new webapi -n [ProjectName]
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

# Migration workflow
dotnet ef migrations add [MigrationName]
dotnet ef database update
dotnet ef migrations list
dotnet ef database drop --force
```

---

_Use this guide with GitHub Copilot agent mode to implement database migrations in your .NET Core 8.0 application with SQL Server._
