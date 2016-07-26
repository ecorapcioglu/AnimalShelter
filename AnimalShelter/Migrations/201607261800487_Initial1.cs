namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        PersonnelId = c.Int(nullable: false, identity: true),
                        PersonnelFirstName = c.String(),
                        PersonnelLastName = c.String(),
                        PersonnelPhoneNumber = c.String(),
                        PersonnelEmail = c.String(),
                        PersonnelTypeId = c.Int(nullable: false),
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonnelId)
                .ForeignKey("dbo.AnimalShelters", t => t.ShelterId, cascadeDelete: true)
                .ForeignKey("dbo.PersonnelTypes", t => t.PersonnelTypeId, cascadeDelete: true)
                .Index(t => t.PersonnelTypeId)
                .Index(t => t.ShelterId);
            
            CreateTable(
                "dbo.PersonnelTypes",
                c => new
                    {
                        PersonnelTypeId = c.Int(nullable: false, identity: true),
                        PersonnelTypeTitle = c.String(),
                    })
                .PrimaryKey(t => t.PersonnelTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnels", "PersonnelTypeId", "dbo.PersonnelTypes");
            DropForeignKey("dbo.Personnels", "ShelterId", "dbo.AnimalShelters");
            DropIndex("dbo.Personnels", new[] { "ShelterId" });
            DropIndex("dbo.Personnels", new[] { "PersonnelTypeId" });
            DropTable("dbo.PersonnelTypes");
            DropTable("dbo.Personnels");
        }
    }
}
