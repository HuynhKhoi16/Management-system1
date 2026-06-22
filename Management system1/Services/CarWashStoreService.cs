using ManagementSystem1.Database_Connection;
using ManagementSystem1.Models;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;


namespace ManagementSystem1.Services
{

    class CarWashStoreService
    {
        public readonly CWDatabase Res;

        public CarWashStoreService(CWDatabase res)
        {
            Res = res;
        }



        //CAR WASH STORE INTERFACE
        public void CWMainHub()
        {
            while (true)
            {
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
                        this.Add();
                        break;
                    case 2:
                        this.View();
                        break;
                    case 3:
                        this.Update();
                        break;
                    case 4:
                        this.Delete();
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }



        //CW HELPER
        public static bool CheckValidId(string id)
        {
            if (id.Length != 6)
            {
                Console.WriteLine("Invalid Id length, must have 6 characters start with CW and then 4 numbers");

                return false;
            }
            int check;
            if (id.Substring(0, 2) != "CW" || !int.TryParse(id.Substring(2), out check))
            {
                Console.WriteLine("Invalid ID, must start with CW and then 4 numbers");
                return false;
            }


            else return true;
        }



        //1. ADD CAR WASH
        public void Add()
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

                if (!CheckValidId(id)) { continue; }

                else if (Res.IdInDatabase(id) != null)
                {
                    Console.WriteLine("The Id you enter already exist");
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
                if(!double.TryParse(Console.ReadLine(), out rating) || rating < 0 || rating > 5)
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

            Res.AddToDatabase(carWashStore);

            //carWashStores.Add(carWashStore);


            Console.WriteLine($"Car Wash {id} added successfully");
        }






        //2. VIEW ALL CAR WASH
        public void View()
        {
            Res.ViewDatabase();
        }


        //3. UPDATE CAR WASH INFORMATION
        public void Update()
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
                Console.Write("The new Id for the Car Wash Location: ");
                id2 = Console.ReadLine();

                if (!CheckValidId(id2)) { continue; }

                else if (Res.IdInDatabase(id) != null && id2 != id)
                {
                    Console.WriteLine("The Id you enter already exist");
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

            Res.DeleteFromDatabase(id);

            
            Console.WriteLine($"Car Wash {id} was modified successfully");

        }


        
  




        //4. DELETE GAS STATION
        public void Delete()
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
                if (!CheckValidId(id)) { continue; }
                if (!Res.IdInDatabase(id))
                {
                    Console.WriteLine("The id is not found, try again.");
                    continue;
                }
                break;
            }

            //carWashStores.Remove(carWashStore);
            Res.DeleteFromDatabase(id);
            Console.WriteLine($"Gas Station {id} was removed");
        }


    }
}