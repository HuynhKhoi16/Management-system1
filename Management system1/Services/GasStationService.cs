using ManagementSystem1.Models;
using Microsoft.Data.SqlClient;
using Management_system1.SQL_Connection;
using Management_system1.Database_Connection;
using System;


namespace ManagementSystem1.Services
{
    public class GasStationService
    {

        private readonly GSDatabase Res;
        public GasStationService(GSDatabase res)
        {
            Res = res;
        }



        //INTERFACE FOR GAS STATIONS
        public void GSMainHub()
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
                        this.AddGS();
                        break;
                    case 2:
                        Res.ViewDatabase();
                        break;
                    case 3:
                        this.UpdateGS();
                        break;
                    case 4:
                        this.DeleteGS();
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }






        //GS HELPER
        public bool CheckValidId(string id)
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


        


        //1. ADD GAS STATION
        public void AddGS()
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

                if (!CheckValidId(id)) { continue; }


                if (Res.IdInDatabase(id))
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
                Console.Write("Invalid entry, re-enter the number: ");

            }

            Console.Write("The profit per week: ");
            int profit;
            while (!int.TryParse(Console.ReadLine(), out profit) || profit < 0)
            {
                Console.Write("Invalid entry, re-enter the number: ");

            }

            GasStation gasStation =  new(id, address, numOfWorkers, profit);
            Res.AddToDatabase(gasStation);


            Console.WriteLine($"Gas Station {id} added successfully");
        }



        //2. VIEW ALL GAS STATION


        //3. UPDATE GAS STATION INFORMATION
        public void UpdateGS()
        {
            string id;
            while (true)
            {
                Console.Write("The Id you need to modify (press 0 to exit): ");
                id = Console.ReadLine();
                if (id == "0")
                {
                    Console.WriteLine("Cancel updating.");
                    return;
                }
                if (!CheckValidId(id)) { continue; }
                if (!Res.IdInDatabase(id))
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

                if (!CheckValidId(id2)) { continue; }

                else if (Res.IdInDatabase(id) != null && id2 != id)
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
                Console.Write("Invalid entry, re-enter the number: ");

            }

            Console.Write("The profit per week: ");
            int profit;
            while (!int.TryParse(Console.ReadLine(), out profit) || profit < 0)
            {
                Console.Write("Invalid entry, re-enter the number: ");

            }

            GasStation gasStation = new GasStation(id2, address, numOfWorkers, profit);
            Res.UpdateToDatabase(gasStation, id);

            Console.WriteLine($"Gas Station {id} was modified successfully");

        }




        //4. DELETE GAS STATION
        public void DeleteGS()
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
                if (!CheckValidId(id)) { continue; }
                if (!Res.IdInDatabase(id))
                {
                    Console.WriteLine("The id is not found, try again.");
                    continue;
                }
                break;
            }

            Res.DeleteFromDatabase(id);
            Console.WriteLine($"Gas Station {id} was removed");
        }
    }
}
