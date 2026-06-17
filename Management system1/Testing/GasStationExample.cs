using System;
using ManagementSystem1.Models;

namespace ManagementSystem1.Testing
{
    internal class GasStationExample
    {
        public static void Example1(List<GasStation> gasStations)
        {
            gasStations.Add(new GasStation("GS0001", "43 Troll Street", 6, 1937));
            gasStations.Add(new GasStation("GS0002", "195 Baker Street", 3, 1547));
            gasStations.Add(new GasStation("GS0003", "210 King Street", 10, 976));
            gasStations.Add(new GasStation("GS0004", "68 Downtown Road", 8, 2147));
        }
    }
}
