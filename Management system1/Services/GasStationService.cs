using ManagementSystem1.Models;
using System;


namespace ManagementSystem1.Services
{
    class GasStationService
    {
        //GS HELPER
        public static bool CheckValidId(string id, List<GasStation> gasStations)
        {
            if (id.Length != 6)
            {
                Console.WriteLine("Invalid Id length, must have 6 characters start with GS and then 4 numbers");

                return false;
            }
            int check;
            if (id.Substring(0, 2) != "GS" || !int.TryParse(id.Substring(2), out check))
            {
                Console.WriteLine("Invalid ID, must start with GS and then 4 numbers");
                return false;
            }


            else return true;
        }


        public static GasStation findId(string id, List<GasStation> gasStations)
        {
            GasStation result = gasStations.Find(x => x.Id == id);
            return result;

        }


        //1.ADD GAS STATION
        public static void AddGS(List<GasStation> gasStations)
        {
            string id;

            while (true)
            {
                Console.Write("The Id for the new Gas Station( Press 0 to exit ): ");
                id = Console.ReadLine();

                if (id == "0")
                {
                    Console.WriteLine("Cancel adding.");
                    return;
                }

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



        //2. VIEW ALL GAS STATION
        public static void ViewAllGS(List<GasStation> gasStations)
        {
            if (gasStations.Count == 0)
            {
                Console.WriteLine("No Gas Station found");
            }
            else
            {
                Console.WriteLine($"{"GasStationId",-20} {"Address",-25} {"Number of Workers",-10} {"Profit per week",-10}");

                foreach (GasStation gasStation in gasStations.OrderBy(x => x.Id))
                {
                    Console.WriteLine($"{gasStation.Id,-20} {gasStation.Address,-25} {gasStation.NumOfWorkers,-10} {gasStation.Profit,-10}");
                }
            }
        }






        //3. UPDATE GAS STATION INFORMATION
        public static void UpdateGS(List<GasStation> gasStations)
        {
            string id;
            GasStation gasStation;
            while (true)
            {
                Console.Write("The Id you need to modify (press 0 to exit): ");
                id = Console.ReadLine();
                if (id == "0")
                {
                    Console.WriteLine("Cancel updating.");
                    return;
                }
                if (!CheckValidId(id, gasStations)) { continue; }
                gasStation = findId(id, gasStations);
                if (gasStation == null)
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

                else if (findId(id, gasStations) != null && id2 != gasStation.Id)
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
        public static void DeleteGS(List<GasStation> gasStations)
        {
            string id;
            GasStation gasStation;
            while (true)
            {
                Console.Write("The Id you need to modify (0 to cancel): ");
                id = Console.ReadLine();
                if (id == "0")
                {
                    Console.WriteLine("Cancel deleting.");
                    return;
                }
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
    }
}
