using ManagementSystem1.Database_Connection;
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

        public bool IdInDatabase(string id)
        {
            return _service.IdInDatabase(id);
        }

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
                        {string id;

                        while (true)
                        {
                            Console.Write("The Id for the new Gas Station( Press 0 to exit ): ");
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

                        GasStation gasStation = new(id, address, numOfWorkers, profit);
                            _service.Add(gasStation);

                            break;
                        }



                    case 2:
                        _service.View();
                        break;




                    case 3:
                        {string id;
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
                                Console.WriteLine("The Id you enter can't be found in the database, try the a different one.");
                                continue;
                            }


                            break;
                        }


                        string id2;

                        while (true)
                        {
                            Console.Write("The new Id for the Gas Station: ");
                            id2 = Console.ReadLine();

                            if (!CheckValidId(id2)) 
                            {
                                continue; 
                            }

                            if(IdInDatabase(id2) && id2 != id)
                                {
                                    Console.WriteLine("The Id you enter is already used by another person, try the different one.");
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
                            _service.Update(gasStation,id);
                            break;
                        }
                    
                    
                    
                    
                    case 4:
                       { string id;
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
                            if (!CheckValidId(id)) 
                            {
                                continue; 
                            }


                            if(!IdInDatabase(id))
                            {
                                Console.WriteLine("The Id you enter cannot be found, try a different Id.");
                                continue;
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
