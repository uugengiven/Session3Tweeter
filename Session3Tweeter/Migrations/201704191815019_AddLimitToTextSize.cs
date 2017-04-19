namespace Session3Tweeter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLimitToTextSize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tweets", "Text", c => c.String(maxLength: 140));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tweets", "Text", c => c.String());
        }
    }
}
