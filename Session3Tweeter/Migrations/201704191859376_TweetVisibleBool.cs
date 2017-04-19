namespace Session3Tweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TweetVisibleBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tweets", "visible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tweets", "visible");
        }
    }
}
