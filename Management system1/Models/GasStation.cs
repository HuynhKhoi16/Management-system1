
using System;

namespace ManagementSystem1.Models
{
    //GAS STATION
    public class GasStation : location
    {
        public override string Id { get; set; }
        public override string Address { get; set; }

        public override int NumOfWorkers { get; set; }

        public int Profit { get; set; }

        public GasStation(string id, string address, int numOfWorkers, int profit) : base(id, address, numOfWorkers)
        {
            Id = id;
            Address = address;
            NumOfWorkers = numOfWorkers;
            Profit = profit;
        }


    }
}
