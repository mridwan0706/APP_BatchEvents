namespace App_BatchEventsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelinDatabase2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventVMBatcheVMs",
                c => new
                    {
                        EventVM_Id = c.Int(nullable: false),
                        BatcheVM_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventVM_Id, t.BatcheVM_Id })
                .ForeignKey("dbo.TB_T_Event", t => t.EventVM_Id, cascadeDelete: true)
                .ForeignKey("dbo.TB_M_Batches", t => t.BatcheVM_Id, cascadeDelete: true)
                .Index(t => t.EventVM_Id)
                .Index(t => t.BatcheVM_Id);
            
            CreateTable(
                "dbo.EmployeeVMEventVMs",
                c => new
                    {
                        EmployeeVM_Id = c.Int(nullable: false),
                        EventVM_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeVM_Id, t.EventVM_Id })
                .ForeignKey("dbo.TB_M_Employee", t => t.EmployeeVM_Id, cascadeDelete: true)
                .ForeignKey("dbo.TB_T_Event", t => t.EventVM_Id, cascadeDelete: true)
                .Index(t => t.EmployeeVM_Id)
                .Index(t => t.EventVM_Id);
            
            CreateTable(
                "dbo.RoomVMEventVMs",
                c => new
                    {
                        RoomVM_Id = c.Int(nullable: false),
                        EventVM_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomVM_Id, t.EventVM_Id })
                .ForeignKey("dbo.TB_M_Room", t => t.RoomVM_Id, cascadeDelete: true)
                .ForeignKey("dbo.TB_T_Event", t => t.EventVM_Id, cascadeDelete: true)
                .Index(t => t.RoomVM_Id)
                .Index(t => t.EventVM_Id);
            
            AddColumn("dbo.TB_M_Login", "LoginVM_Email", c => c.String(maxLength: 128));
            AddColumn("dbo.TB_M_Login", "EmployeeVM_Id", c => c.Int());
            AddColumn("dbo.TB_M_Login", "RoleVM_Id", c => c.Int());
            CreateIndex("dbo.TB_M_Login", "LoginVM_Email");
            CreateIndex("dbo.TB_M_Login", "EmployeeVM_Id");
            CreateIndex("dbo.TB_M_Login", "RoleVM_Id");
            AddForeignKey("dbo.TB_M_Login", "LoginVM_Email", "dbo.TB_M_Login", "Email");
            AddForeignKey("dbo.TB_M_Login", "EmployeeVM_Id", "dbo.TB_M_Employee", "Id");
            AddForeignKey("dbo.TB_M_Login", "RoleVM_Id", "dbo.TB_M_Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_M_Login", "RoleVM_Id", "dbo.TB_M_Roles");
            DropForeignKey("dbo.RoomVMEventVMs", "EventVM_Id", "dbo.TB_T_Event");
            DropForeignKey("dbo.RoomVMEventVMs", "RoomVM_Id", "dbo.TB_M_Room");
            DropForeignKey("dbo.TB_M_Login", "EmployeeVM_Id", "dbo.TB_M_Employee");
            DropForeignKey("dbo.TB_M_Login", "LoginVM_Email", "dbo.TB_M_Login");
            DropForeignKey("dbo.EmployeeVMEventVMs", "EventVM_Id", "dbo.TB_T_Event");
            DropForeignKey("dbo.EmployeeVMEventVMs", "EmployeeVM_Id", "dbo.TB_M_Employee");
            DropForeignKey("dbo.EventVMBatcheVMs", "BatcheVM_Id", "dbo.TB_M_Batches");
            DropForeignKey("dbo.EventVMBatcheVMs", "EventVM_Id", "dbo.TB_T_Event");
            DropIndex("dbo.RoomVMEventVMs", new[] { "EventVM_Id" });
            DropIndex("dbo.RoomVMEventVMs", new[] { "RoomVM_Id" });
            DropIndex("dbo.EmployeeVMEventVMs", new[] { "EventVM_Id" });
            DropIndex("dbo.EmployeeVMEventVMs", new[] { "EmployeeVM_Id" });
            DropIndex("dbo.EventVMBatcheVMs", new[] { "BatcheVM_Id" });
            DropIndex("dbo.EventVMBatcheVMs", new[] { "EventVM_Id" });
            DropIndex("dbo.TB_M_Login", new[] { "RoleVM_Id" });
            DropIndex("dbo.TB_M_Login", new[] { "EmployeeVM_Id" });
            DropIndex("dbo.TB_M_Login", new[] { "LoginVM_Email" });
            DropColumn("dbo.TB_M_Login", "RoleVM_Id");
            DropColumn("dbo.TB_M_Login", "EmployeeVM_Id");
            DropColumn("dbo.TB_M_Login", "LoginVM_Email");
            DropTable("dbo.RoomVMEventVMs");
            DropTable("dbo.EmployeeVMEventVMs");
            DropTable("dbo.EventVMBatcheVMs");
        }
    }
}
