using ManagementSystem1.Models;
using Microsoft.Data.SqlClient;
using System;


namespace ManagementSystem1.Services
{
    public class GasStationService : LocationService<GasStation>
    {
        private readonly AppDbContext _db;

        public GasStationService(AppDbContext db)
        {
            _db = db;
        }

        //1. ADD GAS STATION
        public void Add(GasStation gasStation)
        {

            if (_db.GasStations.Any(v => v.Id == gasStation.Id)) throw new Exception("The id is already used");
            _db.GasStations.Add(gasStation);
            _db.SaveChanges();
        }



        //2. VIEW ALL GAS STATION

        public List<GasStation> View()
        {
            return _db.GasStations.ToList();
        }


        //3. UPDATE GAS STATION INFORMATION
        public void Update(GasStation gasStation)
        {
            var newGasStation = _db.GasStations.FirstOrDefault(s => s.Id == gasStation.Id);
            if (newGasStation != null)
            {
                _db.Entry(newGasStation).CurrentValues.SetValues(gasStation);
                _db.SaveChanges();
            }
            else throw new Exception("The id is not found.");

            Console.WriteLine($"Gas Station {gasStation.Id} was modified successfully");

        }
        




        //4. DELETE GAS STATION
        public void Delete(string id)
        {
            var gasStation = _db.GasStations.FirstOrDefault(s =>s.Id == id);
            if (gasStation != null)
            {
                _db.Remove(gasStation);
                _db.SaveChanges();
            }
            else throw new Exception("The id is not found.");
            
            Console.WriteLine($"Gas Station {id} was removed");
        }
}
}
