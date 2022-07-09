namespace rxApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GetLockClienteId", c => c.Long());
            CreateIndex("dbo.AspNetUsers", "GetLockClienteId");
            AddForeignKey("dbo.AspNetUsers", "GetLockClienteId", "dbo.cliente", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GetLockClienteId", "dbo.cliente");
            DropIndex("dbo.AspNetUsers", new[] { "GetLockClienteId" });
            DropColumn("dbo.AspNetUsers", "GetLockClienteId");
        }
    }
}
