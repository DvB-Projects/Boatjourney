namespace BoatJourney.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BoatJourneyEntities : DbContext
    {
        // Your context has been configured to use a 'BoatJourneyEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BoatJourney.Models.BoatJourneyEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BoatJourneyEntities' 
        // connection string in the application configuration file.
        public BoatJourneyEntities()
            : base("name=BoatJourneyEntities")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Zipcode> Zipcodes { get; set; }
        public virtual DbSet<Vessel> Vessels { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
        public virtual DbSet<TravelOrganiser> TravelOrganisers { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}