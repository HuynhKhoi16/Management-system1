
using Management_system1.Menu_UI;
using Management_system1.SQL_Connection;
using ManagementSystem1.Database_Connection;
using ManagementSystem1.Models;
using ManagementSystem1.Services;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Data.SqlTypes;


namespace ManagementSystem1
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ManagementSystem;Integrated Security=True;Encrypt=True;";
            IDatabase<CarWashStore> CWRepo = new SqlCarWashStore(connectionString, "CarWashstores");
            IDatabase<GasStation> GSRepo = new SqlGasStation(connectionString, "GasStations");
            LocationService<CarWashStore> CWService = new CarWashStoreService(CWRepo);
            LocationService<GasStation> GSService = new GasStationService(GSRepo);
            UI carWash = new CW_UI(CWService);
            UI gasStation = new GS_UI(GSService);


            //INTERFACE FOR LOCATIONS

            while (true)
            {
                Console.WriteLine("");
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
                        gasStation.MainHub();
                        break;
                    case 2:
                        carWash.MainHub();
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }
    }
     
}