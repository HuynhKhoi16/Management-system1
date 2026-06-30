using ManagementSystem1.Models;
using ManagementSystem1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management_system1.Menu_UI
{
    class CW_UI : UI
    {
        private readonly LocationService<CarWashStore> _service;

        public CW_UI(LocationService<CarWashStore> service)
        {
            _service = service;
        }




        public void MainHub()
        {
            while (true)
            {
                Console.WriteLine("");
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
                        {
                            try
                            {
                                string id = InputHelper.GetCW("Enter the Id for the new Car Wash: ");
                                string street = InputHelper.GetString("Enter the address of the new location: ");
                                int numOfWorkers = InputHelper.GetInt("The number of workers in this locations: ");
                                decimal rating = InputHelper.GetRating("The rating of the location: ");
                                int profit = InputHelper.GetInt("The profit per week: ");
                                _service.Add(new CarWashStore(id, street, numOfWorkers, rating, profit));
                                Console.WriteLine($"Car Wash {id} added successfully");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }

                            break;
                        }



                    case 2:
                        List<CarWashStore> list = _service.View();
                        Console.WriteLine($"{"Id",-8} {"Address",-20} {"Number of workers",-20} {"Rating",-5} {"Profit",-5}");
                        foreach (var i in list)
                        {
                            Console.WriteLine($"{i.Id,-8} {i.Address,-20} {i.NumOfWorkers,-20} {i.Rating, -5} {i.Profit,-5}");
                        }
                        break; 

                    case 3:
                        {
                            try
                            {
                                string id = InputHelper.GetCW("Enter the id you want to update: ");
                                string address = InputHelper.GetCW("Enter the new Address: ");
                                int numOfWorkers = InputHelper.GetInt("Enter the new number of employees: ");
                                decimal rating = InputHelper.GetRating("Enter the new rating of the location: ");
                                int profit = InputHelper.GetInt("Enter the new profit per week: ");
                                _service.Update(new CarWashStore(id, address, numOfWorkers, rating, profit));
                            }
                            catch(Exception ex) {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                string id = InputHelper.GetCW("Enter the id of the location you want to delete: ");
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
