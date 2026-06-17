using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace LocationManagement
{
    abstract class location
    {
        public abstract string Id { get; set; }
        public abstract string Address { get; set; }

        public location(string id, string address)
        {
            Id = id;
            Address = address;
        }
    }

    //GAS STATION
    class GasStation : location
    {
        public override string Id { get; set; }
        public override string Address { get; set; }

        public int NumOfWorkers { get; set; }

        public string Profit { get; set; }

        public GasStation(string id, string address, int numOfWorkers, int profit) : base(id, address)
        {
            Id = id;
            Address = address;
            NumOfWorkers = numOfWorkers;
            Profit = "$"+Convert.ToString(profit);
        }


    }












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






        //helper
        static bool CheckValidId(string id, List<GasStation> gasStations)
        {
            if (id.Length != 6)
            {
                Console.WriteLine("Invalid Id length");

                return false;
            }
            int check;
            if (id.Substring(0, 2) != "GS" || !int.TryParse(id.Substring(2), out check))
            {
                Console.WriteLine("Invalid ID, must start with GS and then numbers");
                return false;
            }
            

            else return true;
        }


        static GasStation findId(string id, List<GasStation> gasStations)
        {
            GasStation result = gasStations.Find(x => x.Id == id);
            return result;

        }


        //ADD GAS STATION
        static void AddGS(List<GasStation> gasStations)
        {
            string id;

            while (true)
            {
                Console.Write("The Id for the new Gas Station( Press 0 to exit ): ");
                id = Console.ReadLine();

                if (id == "0") { return; }

                if (!CheckValidId(id, gasStations)) { continue; }

                else if (findId(id, gasStations) != null)
                {
                    Console.WriteLine("The Id you enter already exist");
                    continue;
                    
                }
                break;
            }


            Console.Write("The address of the Gas Station: ");
            string address = Console.ReadLine();

            Console.Write("The number of workers: ");
            int numOfWorkers;
            while (!int.TryParse(Console.ReadLine(), out numOfWorkers) || numOfWorkers < 0)
            {
                Console.WriteLine("Invalid entry, re-enter the number: ");

            }

            Console.Write("The profit per week: ");
            int profit;
            while (!int.TryParse(Console.ReadLine(), out profit) || profit < 0)
            {
                Console.Write("Invalid entry, re-enter the number: ");

            }

            gasStations.Add(new(id, address, numOfWorkers, profit));


            Console.WriteLine($"Gas Station {id} added successfully");
        }



        //VIEW ALL GAS STATION
        static void ViewAllGS(List<GasStation> gasStations)
        {
            if(gasStations.Count == 0)
            {
                Console.WriteLine("No Gas Station found");
            }
            else
            {
                Console.WriteLine($"{"GasStationId",-20} {"Address",-25} {"Number of Workers",-10} {"Profit per week",-10}");

                foreach(GasStation gasStation in gasStations.OrderBy(x => x.Id)){
                    Console.WriteLine($"{gasStation.Id,-20} {gasStation.Address,-25} {gasStation.NumOfWorkers,-10} {gasStation.Profit,-10}");
                }
            }
        }


        



        //3. UPDATE GAS STATION INFORMATION
        static void UpdateGS(List<GasStation> gasStations)
        {
            string id;
            GasStation gasStation;
            while (true)
            {
                Console.Write("The Id you need to modify (press 0 to exit): ");
                id = Console.ReadLine();
                if (id == "0") { return; }
                if (!CheckValidId(id, gasStations)) { continue; }
                gasStation = findId(id, gasStations);
                if(gasStation == null)
                {
                    Console.WriteLine("The id is not found, try again.");
                    continue;
                }
                break;
            }


            string id2;

            while (true)
            {
                Console.Write("The new Id for the Gas Station: ");
                id2 = Console.ReadLine();

                if (!CheckValidId(id2, gasStations)) { continue; }

                else if (findId(id, gasStations) != null && id2!=gasStation.Id)
                {
                    Console.WriteLine("The Id you enter already exist");
                    continue;

                }

                break;
            }


            Console.Write("The new address of the Gas Station: ");
            string address = Console.ReadLine();

            Console.Write("The new number of workers: ");
            int numOfWorkers;
            while (!int.TryParse(Console.ReadLine(), out numOfWorkers) || numOfWorkers < 0)
            {
                Console.WriteLine("Invalid entry, re-enter the number: ");

            }

            Console.Write("The profit per week: ");
            int profit;
            while (!int.TryParse(Console.ReadLine(), out profit) || profit < 0)
            {
                Console.Write("Invalid entry, re-enter the number: ");

            }

            gasStation.Id = id2;
            gasStation.Address = address;
            gasStation.NumOfWorkers = numOfWorkers;
            gasStation.Profit = "$" + Convert.ToString(profit);


            Console.WriteLine($"Gas Station {id} was modified successfully");

        }




        //DELETE GAS STATION
        static void DeleteGS(List<GasStation> gasStations)
        {
            string id;
            GasStation gasStation;
            while (true)
            {
                Console.Write("The Id you need to modify (0 to cancel): ");
                id = Console.ReadLine();
                if(id == "0") { return; }
                if (!CheckValidId(id, gasStations)) { continue; }
                gasStation = findId(id, gasStations);
                if (gasStation == null)
                {
                    Console.WriteLine("The id is not found, try again.");
                    continue;
                }
                break;
            }

            gasStations.Remove(gasStation);
            Console.WriteLine($"Gas Station {id} was removed");
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
                        AddGS(gasStations);
                        break;
                    case 2:
                        ViewAllGS(gasStations);
                        break;
                    case 3:
                        UpdateGS(gasStations);
                        break;
                    case 4:
                        DeleteGS(gasStations);
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










   
