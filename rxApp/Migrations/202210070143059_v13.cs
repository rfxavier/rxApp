namespace rxApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.message", "user_id", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.message", "user_name", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.message", "user_lastname", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.message", "user_lastname");
            DropColumn("dbo.message", "user_name");
            DropColumn("dbo.message", "user_id");
        }
    }
}
