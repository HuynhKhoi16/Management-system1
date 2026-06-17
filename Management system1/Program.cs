using System;
using Management_system1.Models;
using Management_system1.Services;
using ManagementSystem1.Models;
using ManagementSystem1.Services;
namespace ManagementSystem1
{
    


    class Program
        {
        //INTERFACE FOR LOCATIONS
        static void mainHub(List<GasStation> gasStations, List<CarWashStore> carWashStores)
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
                        GSMainHub(gasStations);
                        break;
                    case 2:
                        CWMainHub(carWashStores);
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }


        //INTERFACE FOR GAS STATIONS
        static void GSMainHub(List<GasStation> gasStations)
        {
            while (true)
            {
                Console.WriteLine("===Welcome to Gas Station Management===");
                Console.WriteLine("1. Add Gas Station Location");
                Console.WriteLine("2. View all location");
                Console.WriteLine("3. Update Location Information");
                Console.WriteLine("4. Delete Location");
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
                        GasStationService.AddCW(gasStations);
                        break;
                    case 2:
                        GasStationService.ViewAllCW(gasStations);
                        break;
                    case 3:
                        GasStationService.UpdateCW(gasStations);
                        break;
                    case 4:
                        GasStationService.DeleteCW(gasStations);
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }



        //CAR WASH STORE INTERFACE
        static void CWMainHub(List<CarWashStore> carWashStores)
        {
            while (true)
            {
                Console.WriteLine("===Welcome to Car Wash store Management===");
                Console.WriteLine("1. Add a new store");
                Console.WriteLine("2. View all location");
                Console.WriteLine("3. Update Location Information");
                Console.WriteLine("4. Delete Location");
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
                        CarWashStoreService.AddGS(carWashStores);
                        break;
                    case 2:
                        CarWashStoreService.ViewAllGS(carWashStores);
                        break;
                    case 3:
                        CarWashStoreService.UpdateGS(carWashStores);
                        break;
                    case 4:
                        CarWashStoreService.DeleteGS(carWashStores);
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }



        static void Main(string[] args)
            {
                List<GasStation> gasStations = new List<GasStation>()
                {
                    new GasStation("GS0001", "43 Troll Street", 6, 1937),
                    new GasStation("GS0002", "195 Baker Street", 3, 1547),
                    new GasStation("GS0003", "210 King Street", 10, 976),
                    new GasStation("GS0004", "68 Downtown Road", 8, 2147)
                };


            List<CarWashStore> carWashStores = new List<CarWashStore>()
            {
                new CarWashStore("CW2942", "429 Dawn Street", 15, 4.9, 10342),
                new CarWashStore("CW3534", "03 South Street", 12, 4.0, 9743),
                new CarWashStore("CW0293", "101 Lion Street", 20, 4.3, 14652),
                new CarWashStore("CW1432", "796 North Street", 10, 4.1, 75423),
                new CarWashStore("CW9427", "1425 DownTown Road", 8, 3.2, 5426),

            };

                mainHub(gasStations, carWashStores);


            }
    }

}










   
