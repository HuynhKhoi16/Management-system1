using ManagementSystem1.Models;
using ManagementSystem1.Services;
using System;

namespace ManagementSystem1.Services
{
    internal class LocationService
    {
        //INTERFACE FOR LOCATIONS
        public static void mainHub(List<GasStation> gasStations, List<CarWashStore> carWashStores)
        {
            while (true)
            {
                Console.WriteLine("====Welcome to Location Management====");
                Console.WriteLine("1. Gas Station");
                Console.WriteLine("2. Car Wash Location");
                Console.WriteLine("0. Exit");
                Console.Write("Choose the number to proceed: ");

                int num0;
                while (!int.TryParse(Console.ReadLine(), out num0))
                {
                    Console.Write("Invalid entry, Re-enter the value: ");
                }

                switch (num0)
                {
                    case 0:
                        return;
                    case 1:
                        GasStationService.GSMainHub(gasStations);
                        break;
                    case 2:
                        CarWashStoreService.CWMainHub(carWashStores);
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }
    }
}
