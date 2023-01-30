using FluentMigrator.Runner;

namespace FluentMigrator.Seed.Postgres.Migrations
{
    public static class MigrationsExtensions
    {
        public static IApplicationBuilder Migrate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            migrator?.ListMigrations();
            migrator?.MigrateUp(20231302120);
            return app;
        }
    }
}
