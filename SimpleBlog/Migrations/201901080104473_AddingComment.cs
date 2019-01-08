namespace SimpleBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.String(nullable: false),
                        CommentBy = c.String(nullable: false),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
