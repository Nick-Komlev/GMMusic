namespace GMMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColorAdding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "Color");
        }
    }
}
