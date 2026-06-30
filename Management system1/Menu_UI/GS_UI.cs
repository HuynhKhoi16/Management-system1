
using ManagementSystem1.Models;
using ManagementSystem1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management_system1.Menu_UI
{
    class GS_UI : UI
    {
        private readonly LocationService<GasStation> _service;

        public GS_UI(LocationService<GasStation> service)
        {
            _service = service;
        }

        public void MainHub()
        {
            while (true)
            {
                Console.WriteLine("");
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
                    Console.Write("Invalid number, Re-enter the value: ");
                }

                switch (num0)
                {
                    case 0:
                        return;
                    case 1:
                        {
                            try{
                                string id = InputHelper.GetGS("Enter the Id for the new GasStation");

                                string address = InputHelper.GetString("The address of the Gas Station: ");

                                int numOfWorkers = InputHelper.GetInt("The number of workers: ");

                                int profit = InputHelper.GetInt("The profit per week: ");

                                _service.Add(new GasStation(id, address, numOfWorkers, profit));

                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }



                    case 2:
                        List <GasStation> list = _service.View();
                        Console.WriteLine($"{"Id",-5} {"Address",-20} {"Number of workers",-10} {"Profit",-5}");
                        foreach(var i in list)
                        {
                            Console.WriteLine($"{i.Id,-5} {i.Address,-20} {i.NumOfWorkers,-10} {i.Profit,-5}");
                        }
                        break;




                    case 3:
                        {
                            try{
                                string id = InputHelper.GetGS("Enter the Id of the Gas Station you want to modify: ");

                                string address = InputHelper.GetString("The new address of the Gas Station: ");

                                int numOfWorkers = InputHelper.GetInt("The new number of workers: ");

                                int profit = InputHelper.GetInt("The profit per week: ");
    
                                _service.Update(new GasStation(id, address, numOfWorkers, profit));
                                break;
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }
                    
                    
                    
                    
                    case 4:
                        {
                            try
                            {
                                string id = InputHelper.GetGS("The id of the location you want to delete: ");
                                _service.Delete(id);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                       }
                    

                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }
    }
}
