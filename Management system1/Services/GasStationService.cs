using ManagementSystem1.Models;
using Microsoft.Data.SqlClient;
using Management_system1.SQL_Connection;
using System;
using ManagementSystem1.Database_Connection;


namespace ManagementSystem1.Services
{
    public class GasStationService : LocationService<GasStation>
    {

        private readonly IDatabase<GasStation> Database;
        public GasStationService(IDatabase<GasStation> database)
        {
            Database = database;
        }



        //INTERFACE FOR GAS STATIONS
        






        //GS HELPER
        
        public bool IdInDatabase(string id)
        {
            return Database.IdInDatabase(id);
            
        }

        


        //1. ADD GAS STATION
        public void Add(GasStation gasStation)
        {
            Database.AddToDatabase(gasStation);
            Console.WriteLine($"Gas Station {gasStation.Id} added successfully");
        }



        //2. VIEW ALL GAS STATION

        public void View()
        {
            Database.ViewDatabase();
        }


        //3. UPDATE GAS STATION INFORMATION
        public void Update(GasStation gasStation, string oldId)
        {
            Database.UpdateToDatabase(gasStation, oldId);

            Console.WriteLine($"Gas Station {oldId} was modified successfully");

        }




        //4. DELETE GAS STATION
        public void Delete(string id)
        {
            Database.DeleteFromDatabase(id);
            Console.WriteLine($"Gas Station {id} was removed");

        }
    }
}
