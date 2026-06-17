
using ManagementSystem1.Models;
using ManagementSystem1.Services;
using ManagementSystem1.Testing;
using System;


namespace ManagementSystem1
{ 
    class Program
        {
        static void Main(string[] args)
        {
            List<GasStation> gasStations = new List<GasStation>();
            List<CarWashStore> carWashStores = new List<CarWashStore>();

            GasStationExample.Example1(gasStations);
            CarWashExample.Example1(carWashStores);

            LocationService.mainHub(gasStations, carWashStores);
        }
    }
}