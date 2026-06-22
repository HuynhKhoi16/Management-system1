
using Management_system1.Database_Connection;
using Management_system1.SQL_Connection;
using ManagementSystem1.Database_Connection;
using ManagementSystem1.Models;
using ManagementSystem1.Services;
using ManagementSystem1.Testing;
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
            CWDatabase CWRepo = new SqlCarWashStore(connectionString, "CarWashstores");
            GSDatabase GSRepo = new SqlGasStation(connectionString, "GasStations");
            CarWashStoreService CWService = new CarWashStoreService(CWRepo);
            GasStationService GSService = new GasStationService(GSRepo);


            //INTERFACE FOR LOCATIONS

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
                        GSService.GSMainHub();
                        break;
                    case 2:
                        CWService.CWMainHub();
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }
    }
     
}