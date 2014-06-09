namespace AAventura.Migrations
{
    using AAventura.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AAventura.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AAventura.DAL.AAventuraDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AAventura.DAL.AAventuraDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Utilizadores.AddOrUpdate(
                 p => p.UserName,
                 new Utilizador { 
                     UserName = "admin",
                     Nome = "Serafim Pinto",
                     Email = "smcp92@gmail.com",
                     Avatar = "~/Images/defaul.jpg",
                     Estado = 0,
                     NrRespostasCertas = 0,
                     NrRespostasErradas = 0,
                     VoltasDadas = 0,
                     TempoTotal = 0,
                     HighScore = 0
                 });
            //
        }
    }
}
