using AnimalShelter.Models;

namespace AnimalShelter.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AnimalShelter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AnimalShelter.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.PersonnelTypes.AddOrUpdate(p => p.PersonnelTypeTitle,
                new PersonnelType { PersonnelTypeTitle = "Employee" },
                new PersonnelType { PersonnelTypeTitle = "Volunteer" },
                new PersonnelType { PersonnelTypeTitle = "Manager" },
                new PersonnelType { PersonnelTypeTitle = "Donor" });
        }
    }
}
