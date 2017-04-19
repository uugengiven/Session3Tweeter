namespace Session3Tweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        TweetUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TweetUsers", t => t.TweetUser_ID)
                .Index(t => t.TweetUser_ID);
            
            CreateTable(
                "dbo.TweetUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProfilePic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tweets", "TweetUser_ID", "dbo.TweetUsers");
            DropIndex("dbo.Tweets", new[] { "TweetUser_ID" });
            DropTable("dbo.TweetUsers");
            DropTable("dbo.Tweets");
        }
    }
}
