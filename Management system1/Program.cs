using System;
using ManagementSystem1.Models;
using ManagementSystem1.Services;
namespace ManagementSystem1
{
    


    class Program
        {
        //INTERFACE FOR LOCATIONS
        static void mainHub(List<GasStation> gasStations)
        {
            while (true)
            {
                Console.WriteLine("====Welcome to Location Management====");
                Console.WriteLine("1. GasStation");

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
                Console.WriteLine("4. Delete Loaction");
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
                        GasStationService.AddGS(gasStations);
                        break;
                    case 2:
                        GasStationService.ViewAllGS(gasStations);
                        break;
                    case 3:
                        GasStationService.UpdateGS(gasStations);
                        break;
                    case 4:
                        GasStationService.DeleteGS(gasStations);
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

                mainHub(gasStations);


            }
    }

}










   
