namespace App_BatchEventsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModelinDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BatcheVMs", newName: "TB_M_Batche");
            RenameTable(name: "dbo.EventVMs", newName: "TB_T_Event");
            RenameTable(name: "dbo.RoomVMs", newName: "TB_M_Room");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TB_M_Room", newName: "RoomVMs");
            RenameTable(name: "dbo.TB_T_Event", newName: "EventVMs");
            RenameTable(name: "dbo.TB_M_Batche", newName: "BatcheVMs");
        }
    }
}
