namespace App_BatchEventsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelinDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TB_M_Batche", newName: "TB_M_Batches");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TB_M_Batches", newName: "TB_M_Batche");
        }
    }
}
