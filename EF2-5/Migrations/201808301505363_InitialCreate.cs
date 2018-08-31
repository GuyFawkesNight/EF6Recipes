namespace EF2_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PictureCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.PictureCategories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PictureCategories", "ParentCategoryId", "dbo.PictureCategories");
            DropIndex("dbo.PictureCategories", new[] { "ParentCategoryId" });
            DropTable("dbo.PictureCategories");
        }
    }
}
