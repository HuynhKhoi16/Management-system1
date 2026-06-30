
using ManagementSystem1.Models;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Globalization;


namespace ManagementSystem1.Services
{

    class CarWashStoreService : LocationService<CarWashStore>
    {
        private readonly AppDbContext _db;

        public CarWashStoreService(AppDbContext db)
        {
            _db = db;
        }

        //1. ADD CAR WASH
        public void Add(CarWashStore carWashStore)
        {
            if (_db.CarWashStores.Any(s => s.Id == carWashStore.Id)) throw new Exception("The id is already used.");
            _db.CarWashStores.Add(carWashStore);
            _db.SaveChanges();
        }


        //2. VIEW ALL CAR WASH
        public List<CarWashStore> View()
        {
            return _db.CarWashStores.ToList();
        }


        //3. UPDATE CAR WASH INFORMATION
        public void Update(CarWashStore updatedCarWashStore)
        {

            var carWash = _db.CarWashStores.FirstOrDefault(s => s.Id == updatedCarWashStore.Id);
            if (carWash != null)
            {
                _db.Entry(carWash).CurrentValues.SetValues(updatedCarWashStore);
                _db.SaveChanges();
            }
            else throw new Exception("The id is not found.");
            
            Console.WriteLine($"Car Wash {updatedCarWashStore.Id} was modified successfully");

        }


        //4. DELETE GAS STATION
        public void Delete(string id)
        {
            var CarWash = _db.CarWashStores.FirstOrDefault(v=>v.Id == id);
            if (CarWash != null)
            {
                _db.CarWashStores.Remove(CarWash);
                _db.SaveChanges();
            }
            else throw new Exception("The id is not found");
            
            Console.WriteLine($"The location with the id {id} has been removed");
        }
    }
}
