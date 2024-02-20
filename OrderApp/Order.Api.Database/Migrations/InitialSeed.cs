using FluentMigrator;
using Order.Api.Data.Models;

namespace Order.Api.Database.Migrations
{
  [Migration(2024_02_20_0001)]
  public class InitialSeed : Migration
  {
    public override void Up()
    {
      Insert.IntoTable("Orders")
        .Row(new OrderTable(
          new Guid("67fbac34-1ee1-4697-b916-1748861dd275"),
          0,
          new Guid("22874488-1c32-412f-b42b-00bc92c31c9c"),
          "John Dawn"
        ));

      Insert.IntoTable("Orders")
        .Row(new OrderTable(
        
          new Guid("f3279be5-a0fb-40d9-883e-73e743d6ad5a"),
          1,
          new Guid("67154e1d-eff8-4d5b-b82c-4594b5be2c68"),
          "Peter Griffin"
        ));

      Insert.IntoTable("Orders")
        .Row(new OrderTable(
          new Guid("3d2b5031-3931-452d-b258-bc2094bdc933"),
          3,
          new Guid("e7884e59-0aa1-4ec4-9fe1-870d993c563c"),
          "Kenny McCormick" 
        )); 

      Insert.IntoTable("Orders")
        .Row(new OrderTable(
          new Guid("7c892121-6553-45ed-9fae-24e80f260ab0"),
          2,
          new Guid("1b232333-4a3f-4f7d-89fc-b1cf84623baa"), 
          "Bart Simpson"
        ));

      Insert.IntoTable("Orders")
        .Row(new OrderTable(
          new Guid("c5433e9e-eeea-4a8f-9266-fb3d4d964ad4"),
          3,
          new Guid("d96db6c6-c3ec-4ce4-8c95-2499a4ea65a1"),
          "Bob Belcher"
        ));

      Insert.IntoTable("Orders")
        .Row(new OrderTable(
          new Guid("d92af5fd-3eb3-4e47-8287-5f12ef95c058"),
          2,
          new Guid("ff57c226-8d0b-4ca4-8343-452ab663bcd9"),
          "BoJack Horseman"
        ));

      Insert.IntoTable("Orders")
        .Row(new OrderTable(
          new Guid("529dfae8-dcf1-4b5b-8cda-5b8e33c2917d"),
          1,
          new Guid("ee6a849e-dd40-4648-9cf1-bc3bbe34f8e9"),
          "Philip J. Fry" 
        ));
    }

    public override void Down()
    {
      Delete.FromTable("Orders")
        .Row(new OrderTable(
          new Guid("67fbac34-1ee1-4697-b916-1748861dd275"),
          0,
          new Guid("22874488-1c32-412f-b42b-00bc92c31c9c"),
          "John Dawn"
        ));

      Delete.FromTable("Orders")
        .Row(new OrderTable(

          new Guid("f3279be5-a0fb-40d9-883e-73e743d6ad5a"),
          1,
          new Guid("67154e1d-eff8-4d5b-b82c-4594b5be2c68"),
          "Peter Griffin"
        ));

      Delete.FromTable("Orders")
        .Row(new OrderTable(
          new Guid("3d2b5031-3931-452d-b258-bc2094bdc933"),
          3,
          new Guid("e7884e59-0aa1-4ec4-9fe1-870d993c563c"),
          "Kenny McCormick"
        ));

      Delete.FromTable("Orders")
        .Row(new OrderTable(
          new Guid("7c892121-6553-45ed-9fae-24e80f260ab0"),
          2,
          new Guid("1b232333-4a3f-4f7d-89fc-b1cf84623baa"),
          "Bart Simpson"
        ));

      Delete.FromTable("Orders")
        .Row(new OrderTable(
          new Guid("c5433e9e-eeea-4a8f-9266-fb3d4d964ad4"),
          3,
          new Guid("d96db6c6-c3ec-4ce4-8c95-2499a4ea65a1"),
          "Bob Belcher"
        ));

      Delete.FromTable("Orders")
        .Row(new OrderTable(
          new Guid("d92af5fd-3eb3-4e47-8287-5f12ef95c058"),
          2,
          new Guid("ff57c226-8d0b-4ca4-8343-452ab663bcd9"),
          "BoJack Horseman"
        ));

      Delete.FromTable("Orders")
        .Row(new OrderTable(
          new Guid("529dfae8-dcf1-4b5b-8cda-5b8e33c2917d"),
          1,
          new Guid("ee6a849e-dd40-4648-9cf1-bc3bbe34f8e9"),
          "Philip J. Fry"
        ));
    }
  }
}
