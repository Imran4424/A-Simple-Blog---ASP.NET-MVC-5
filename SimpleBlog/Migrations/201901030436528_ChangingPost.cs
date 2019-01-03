namespace SimpleBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostedBy", c => c.String(nullable: false));
            DropColumn("dbo.Posts", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Posts", "PostedBy");
        }
    }
}
