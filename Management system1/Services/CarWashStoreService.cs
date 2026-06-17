using ManagementSystem1.Models;
using System;


namespace ManagementSystem1.Services
{
    class CarWashStoreService
    {
        //CAR WASH STORE INTERFACE
        public static void CWMainHub(List<CarWashStore> carWashStores)
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
                        CarWashStoreService.AddGS(carWashStores);
                        break;
                    case 2:
                        CarWashStoreService.ViewAllGS(carWashStores);
                        break;
                    case 3:
                        CarWashStoreService.UpdateGS(carWashStores);
                        break;
                    case 4:
                        CarWashStoreService.DeleteGS(carWashStores);
                        break;
                    default:
                        Console.WriteLine("Out of range number.");
                        break;
                }
            }
        }



        //CW HELPER
        public static bool CheckValidId(string id, List<CarWashStore> carWashStores)
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


        public static CarWashStore findId(string id, List<CarWashStore> carWashStores)
        {
            CarWashStore result = carWashStores.Find(x => x.Id == id);
            return result;

        }


        //1. ADD GAS STATION
        public static void AddGS(List<CarWashStore> carWashStores)
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

                if (!CheckValidId(id, carWashStores)) { continue; }

                else if (findId(id, carWashStores) != null)
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

            carWashStores.Add(new(id, address, numOfWorkers, rating, profit));


            Console.WriteLine($"Car Wash {id} added successfully");
        }



        //2. VIEW ALL GAS STATION
        public static void ViewAllGS(List<CarWashStore> carWashStores)
        {
            if (carWashStores.Count == 0)
            {
                Console.WriteLine("No Car Wash found");
            }
            else
            {
                Console.WriteLine($"{"CarWashID",-20} {"Address",-25} {"Number of Workers",-22} {"Rating", -10} {"Profit per week",-10}");

                foreach (CarWashStore carWashStore in carWashStores.OrderBy(x => x.Id))
                {
                    Console.WriteLine($"{carWashStore.Id,-20} {carWashStore.Address,-25} {carWashStore.NumOfWorkers,-22} {carWashStore.Rating, -10} {carWashStore.Profit,-10}");
                }
            }
        }



        //3. UPDATE GAS STATION INFORMATION
        public static void UpdateGS(List<CarWashStore> carWashStores)
        {
            string id;
            CarWashStore carWashStore ;
            while (true)
            {
                Console.Write("The Id you need to modify (press 0 to exit): ");
                id = Console.ReadLine();
                if (id == "0")
                {
                    Console.WriteLine("Cancel updating.");
                    return;
                }
                if (!CheckValidId(id, carWashStores)) { continue; }
                carWashStore = findId(id, carWashStores);
                if (carWashStore == null)
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

                if (!CheckValidId(id2, carWashStores)) { continue; }

                else if (findId(id, carWashStores) != null && id2 != carWashStore.Id)
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

            carWashStore.Id = id2;
            carWashStore.Address = address;
            carWashStore.NumOfWorkers = numOfWorkers;
            carWashStore.Rating = rating;
            carWashStore.Profit = "$" + Convert.ToString(profit);


            Console.WriteLine($"Gas Station {id} was modified successfully");

        }




        //4. DELETE GAS STATION
        public static void DeleteGS(List<CarWashStore> carWashStores)
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
                if (!CheckValidId(id, carWashStores)) { continue; }
                carWashStore = findId(id, carWashStores);
                if (carWashStore == null)
                {
                    Console.WriteLine("The id is not found, try again.");
                    continue;
                }
                break;
            }

            carWashStores.Remove(carWashStore);
            Console.WriteLine($"Gas Station {id} was removed");
        }
    }
}