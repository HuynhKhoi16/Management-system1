
using Management_system1.Menu_UI;
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

            var db = new AppDbContext();
            LocationService < GasStation > GSService = new GasStationService(db);
            LocationService <CarWashStore> CWService = new CarWashStoreService(db);
            UI GSMenu = new GS_UI(GSService);
            UI CWMenu = new CW_UI(CWService);


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
                        GSMenu.MainHub();
                        break;
                    case 2:
                        CWMenu.MainHub();
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }
    }
     
}