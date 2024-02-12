using FluentMigrator;

namespace Order.Api.Database.Migrations
{
  [Migration(2024_02_12_0001)]
  internal sealed class InitialTables_2024_02_12_0001 : Migration
  {
    public override void Down()
    {
      Delete.Table("Orders");
    }

    public override void Up()
    {
      Create.Table("Orders")
        .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
        .WithColumn("Name").AsString(50).NotNullable()
        .WithColumn("Address").AsString(60).NotNullable()
        .WithColumn("Country").AsString(50).NotNullable();
    }
  }
}
