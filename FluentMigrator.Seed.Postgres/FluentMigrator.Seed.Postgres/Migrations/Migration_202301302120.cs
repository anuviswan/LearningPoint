namespace FluentMigrator.Seed.Postgres.Migrations
{
    public class Migration202301302120 : Migration
    {
        public override void Down()
        {
            Delete.Table("User");
        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString();
        }
    }
}
