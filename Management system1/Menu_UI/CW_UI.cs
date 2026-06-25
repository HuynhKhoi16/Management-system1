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


        //CW HELPER



        public bool IdInDatabase(string id)
        {
            return _service.IdInDatabase(id);
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
                            string id;

                            while (true)
                            {
                                Console.Write("The Id for the new Car Wash location( Press 0 to exit ): ");
                                id = Console.ReadLine();

                                if (id == "0")
                                {
                                    Console.WriteLine("Cancel adding.");
                                    return;
                                }

                                if (!CheckValidId(id)) 
                                {
                                    continue; 
                                }


                                if (IdInDatabase(id))
                                {
                                    Console.WriteLine("The Id you enter already exist, try a different Id.");
                                    continue;
                                }


                                break;
                            }


                            Console.Write("The address of the Car Wash location: ");
                            string address = Console.ReadLine();



                            double rating;
                            while (true)
                            {
                                Console.Write("Enter the current rating of the location: ");
                                if (!double.TryParse(Console.ReadLine(), out rating) || rating < 0 || rating > 5)
                                {
                                    Console.WriteLine("Invalid entry, the number must be between 0 and 5)");
                                    continue;
                                }
                                break;
                            }




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

                            CarWashStore carWashStore = new(id, address, numOfWorkers, rating, profit);
                            _service.Add(carWashStore);

                                break;
                            }



                    case 2:
                        _service.View();
                        break;




                    case 3:
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
                                if (!CheckValidId(id)) 
                                {
                                    continue; 
                                }


                                if (!IdInDatabase(id))
                                {
                                    Console.WriteLine("The Id you enter cannot be found, try a different Id.");
                                    continue;
                                }
                                break;
                            }

                            

                            string id2;

                            while (true)
                            {
                                Console.Write("The new Id for the Car Wash Location: ");
                                id2 = Console.ReadLine();

                                if (!CheckValidId(id2)) 
                                {
                                    continue; 
                                }

                                if (IdInDatabase(id2) && id != id2)
                                {
                                    Console.WriteLine("The new Id you enter already exist, try a different Id.");
                                    continue;

                                }


                                break;
                            }


                            Console.Write("The new address of the Car Wash location: ");
                            string address = Console.ReadLine();

                            Console.Write("The new number of workers: ");
                            int numOfWorkers;
                            while (!int.TryParse(Console.ReadLine(), out numOfWorkers) || numOfWorkers < 0)
                            {
                                Console.Write("Invalid entry, re-enter the number: ");

                            }


                            double rating;
                            while (true)
                            {
                                Console.Write("Enter the current rating of the location: ");
                                if (!double.TryParse(Console.ReadLine(), out rating) || rating < 0 || rating > 5)
                                {
                                    Console.WriteLine("Invalid entry, the number must be between 0 and 5)");
                                    continue;
                                }
                                break;
                            }

                            Console.Write("The profit per week: ");
                            int profit;
                            while (!int.TryParse(Console.ReadLine(), out profit) || profit < 0)
                            {
                                Console.Write("Invalid entry, re-enter the number: ");

                            }

                            CarWashStore carWashStore = new CarWashStore(id2, address,numOfWorkers,rating,profit);
                            _service.Update(carWashStore, id);
                                break;
                         }
                    case 4:
                        {
                            string id;
                            CarWashStore carWashStore;
                            while (true)
                            {
                                Console.Write("The Id you need to modify (0 to cancel): ");
                                id = Console.ReadLine();
                                if (id == "0")
                                {
                                    Console.WriteLine("Cancel deleting.");
                                    return;
                                }
                                if (!CheckValidId(id)) 
                                {
                                    continue; 
                                }
                                if (!IdInDatabase(id))
                                {
                                    Console.WriteLine("The Id you enter cannot be found, try a different Id.");
                                    return;
                                }

                                break;
                            }
                            _service.Delete(id);
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
