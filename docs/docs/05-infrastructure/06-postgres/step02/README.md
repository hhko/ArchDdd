# 환경 구성 자동화

![](./.images/2024-05-02-16-26-25.png)

## pgAdmin 자동화
### 서버 추가
```yml
volumes:
  - ./docker_pgadmin_servers.json:/pgadmin4/servers.json
```

```json
{
  "Servers": {
    "1": {
      "Name": "Docker Compose",
      "Group": "Servers",
      "Port": 5432,
      "Username": "postgres",
      "Host": "postgres",
      "SSLMode": "prefer",
      "MaintenanceDB": "postgres",
      "PassFile": "/tmp/pgpassfile"
    }
  }
}
```

### PassFile 파일
```yml
# hostname:port:database:username:password
entrypoint:
  - "/bin/sh"
  - "-c"
  - "/bin/echo 'postgres:5432:*:postgres:postgres' > /tmp/pgpassfile && chmod 600 /tmp/pgpassfile && /entrypoint.sh"
```

<br/>

## PostgreSQL 자동화
### 데이터베이스 생성
```yml
volumes:
  - ./docker_postgres_init.sql:/docker-entrypoint-initdb.d/init.sql
```

```sql
-- 데이터베이스 생성
CREATE DATABASE demo1
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

CREATE DATABASE demo2
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-- 테이블 생성
CREATE TABLE test(
  id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  name TEXT NOT NULL,
  archived BOOLEAN NOT NULL DEFAULT FALSE
);

-- 데이터 추가
INSERT INTO test (name, archived)
  VALUES ('test row 1', true),
  ('test row 2', false);
```

```cs
// Npgsql.EntityFrameworkCore.PostgreSQL

public class Test
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Archived { get; set; }
}

// DbContext class
public class AppDbContext : DbContext
{
    public DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace the connection string with your own Postgres connection string
        optionsBuilder.UseNpgsql("Host=localhost;Database=mydb;Username=myuser;Password=mypassword");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional: Configure the Test entity mapping if necessary
        modelBuilder.Entity<Test>(entity =>
        {
            entity.ToTable("test");

            entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .IsRequired();

            entity.Property(e => e.Archived)
                  .HasColumnName("archived")
                  .HasDefaultValue(false);
        });
    }
}

using (var context = new AppDbContext())
{
    // Ensure database and tables are created (for demo purposes)
    context.Database.EnsureCreated();

    // Query to retrieve all rows from the 'test' table
    var tests = context.Tests.ToList();

    foreach (var test in tests)
    {
        Console.WriteLine($"Id: {test.Id}, Name: {test.Name}, Archived: {test.Archived}");
    }
}
```

```cs
var respawnerOptions = new RespawnerOptions
{
    SchemasToInclude = 
    [
        "dbo"
    ],
    TablesToIgnore = 
    [
        "__EFMigrationsHistory",
        "Helloworld"
    ],
    DbAdapter = DbAdapter.SqlServer
};

DbConnection dbConnection = _dbContext.Database.GetDbConnection();
dbConnection.OpenAsync().Wait();
Respawner  respawner = Respawner.CreateAsync(dbConnection, respawnerOptions).Result;
respawner.ResetAsync(dbConnection);
```