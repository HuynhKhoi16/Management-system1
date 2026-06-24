using ManagementSystem1.Database_Connection;
using ManagementSystem1.Models;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Globalization;


namespace ManagementSystem1.Services
{

    class CarWashStoreService : LocationService<CarWashStore>
    {
        public readonly IDatabase<CarWashStore> Res;

        public CarWashStoreService(IDatabase<CarWashStore> res)
        {
            Res = res;
        }


        public bool IdInDatabase(String id)
        {
            return Res.IdInDatabase(id);
        }



        //1. ADD CAR WASH
        public void Add(CarWashStore carWashStore)
        {
            Res.AddToDatabase(carWashStore);

            Console.WriteLine($"Car Wash {carWashStore.Id} added successfully");
        }






        //2. VIEW ALL CAR WASH
        public void View()
        {
            Res.ViewDatabase();
        }


        //3. UPDATE CAR WASH INFORMATION
        public void Update(CarWashStore carWashStore, string oldId)
        {

     


            

            Res.UpdateToDatabase(carWashStore, oldId);

            
            Console.WriteLine($"Car Wash {oldId} was modified successfully");

        }


        //4. DELETE GAS STATION
        public void Delete(string id)
        {
            Res.DeleteFromDatabase(id);
            Console.WriteLine($"Gas Station {id} was removed");
        }
    }
}