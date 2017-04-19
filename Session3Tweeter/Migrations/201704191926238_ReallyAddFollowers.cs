namespace Session3Tweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReallyAddFollowers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Followee_ID = c.Int(),
                        TweetUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TweetUsers", t => t.Followee_ID)
                .ForeignKey("dbo.TweetUsers", t => t.TweetUser_ID)
                .Index(t => t.Followee_ID)
                .Index(t => t.TweetUser_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followers", "TweetUser_ID", "dbo.TweetUsers");
            DropForeignKey("dbo.Followers", "Followee_ID", "dbo.TweetUsers");
            DropIndex("dbo.Followers", new[] { "TweetUser_ID" });
            DropIndex("dbo.Followers", new[] { "Followee_ID" });
            DropTable("dbo.Followers");
        }
    }
}
