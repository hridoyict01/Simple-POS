namespace Pos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupplierModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsManufacturer = c.Boolean(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        AccountPayable = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
        }
    }
}
