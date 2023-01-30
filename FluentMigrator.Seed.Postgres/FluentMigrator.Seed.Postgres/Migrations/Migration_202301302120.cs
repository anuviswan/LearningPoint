namespace FluentMigrator.Seed.Postgres.Migrations
{
    [Migration(20231302120)]
    public class Migration202301302120 : Migration
    {
        public override void Down()
        {
            Delete.Table("User");

            Delete.FromTable("User")
                .Row(new { FirstName = "Jia", LastName = "Anu" })
                .Row(new { FirstName = "Naina", LastName = "Anu" });
        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsGuid().NotNullable().Identity().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString();

            Insert.IntoTable("User")
                .Row(new { FirstName = "Jia", LastName = "Anu" })
                .Row(new { FirstName = "Naina", LastName = "Anu"});
        }
    }
}
