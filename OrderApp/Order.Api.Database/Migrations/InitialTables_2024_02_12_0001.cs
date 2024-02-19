using FluentMigrator;

namespace Order.Api.Database.Migrations
{
  [Migration(2024_02_16_0001)]
  internal sealed class CreateInitialTables : Migration
  {
    public override void Up()
    {
      Create.Table("Orders")
        .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
        .WithColumn("OrderState").AsInt16().NotNullable()
        .WithColumn("CustomerGuid").AsGuid().NotNullable()
        .WithColumn("CustomerFullName").AsString(50).NotNullable();
    }

    public override void Down()
    {
      Delete.Table("Orders");
    }
  }
}
