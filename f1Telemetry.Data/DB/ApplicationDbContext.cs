namespace AdfinityMapper.Data.DB;
public class ApplicationContext : DbContext
{
    public DbSet<PacketHeader> Headers { get; set; }
    public DbSet<PacketMotionData> MotionPackets { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //These env variables can be filled in under the project properties > Debug > Open debug launch UI
        // var dbpass = Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD");
        // ArgumentNullException.ThrowIfNull(dbpass);
        // var dbuser = Environment.GetEnvironmentVariable("MYSQL_ROOT_USER");
        // ArgumentNullException.ThrowIfNull(dbuser);
        // var dbhost = Environment.GetEnvironmentVariable("MYSQL_HOST");
        // ArgumentNullException.ThrowIfNull(dbhost);
        // var dbport = Environment.GetEnvironmentVariable("MYSQL_PORT");
        // ArgumentNullException.ThrowIfNull(dbhost);
        // var conString = $"server={dbhost};port={dbport};database=F1Telemetry;user={dbuser};password={dbpass};pooling=false";
        const string conString = "server=192.168.0.7;port=3306;database=F1Telemetry;user=admin;password=klp246135;pooling=false";
        options.UseMySql(conString, ServerVersion.AutoDetect(conString));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PacketHeader>().ToTable("PacketHeaders");
    }
#if DEBUG
        // modelBuilder.Entity<Authentication>().ToTable("Authentications").HasData(
        //     new Authentication
        //     {
        //         Id = 1,
        //         TransferType = TransferType.IFS,
        //         TokenType = "type 1",
        //         ContentType = "JSON",
        //         UserName = "RobinL",
        //         Password = "Some encrypted pass",
        //     });
#endif
}

//     public override int SaveChanges()
//     {
        // var entries = ChangeTracker
        //     .Entries()
        //     .Where(e => e.Entity is TimestampsEntity && (
        //             e.State == EntityState.Added
        //             || e.State == EntityState.Modified));

        // foreach (var entityEntry in entries)
        // {
        //     ((TimestampsEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

        //     if (entityEntry.State == EntityState.Added)
        //     {
        //         ((TimestampsEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
        //     }
        // }

        // return base.SaveChanges();
//     }
// }
