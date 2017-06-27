namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedEditionDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Edition", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Edition", c => c.Byte(nullable: false));
        }
    }
}
