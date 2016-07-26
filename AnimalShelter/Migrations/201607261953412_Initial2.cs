namespace AnimalShelter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VetHospitals",
                c => new
                    {
                        VetHospitalId = c.Int(nullable: false, identity: true),
                        VetHospitalName = c.String(),
                        VetHospitalAddress = c.String(),
                        VetHospitalHours = c.String(),
                        VetHospitalPhoneNumber = c.String(),
                        VetHospitalEmail = c.String(),
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VetHospitalId)
                .ForeignKey("dbo.AnimalShelters", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VetHospitals", "ShelterId", "dbo.AnimalShelters");
            DropIndex("dbo.VetHospitals", new[] { "ShelterId" });
            DropTable("dbo.VetHospitals");
        }
    }
}
