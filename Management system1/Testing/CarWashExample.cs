using ManagementSystem1.Models;
using System;


namespace ManagementSystem1.Testing
{
    class CarWashExample
    {
        public static void Example1(List<CarWashStore> carWashStores)
        {
            carWashStores.Add(new CarWashStore("CW2942", "429 Dawn Street", 15, 4.9, 10342));
            carWashStores.Add(new CarWashStore("CW3534", "03 South Street", 12, 4.0, 9743));
            carWashStores.Add(new CarWashStore("CW0293", "101 Lion Street", 20, 4.3, 14652));
            carWashStores.Add(new CarWashStore("CW1432", "796 North Street", 10, 4.1, 75423));
            carWashStores.Add(new CarWashStore("CW9427", "1425 DownTown Road", 8, 3.2, 5426));
        }
    }
}
