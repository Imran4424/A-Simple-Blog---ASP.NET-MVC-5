namespace SimpleBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPostIdToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "PostId");
        }
    }
}
