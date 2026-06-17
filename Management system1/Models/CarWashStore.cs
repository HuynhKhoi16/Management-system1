using System;

namespace ManagementSystem1.Models
{
    class CarWashStore : location
    {
        public override string Id { get; set; }
        public override string Address { get; set; }

        public override int NumOfWorkers { get; set; }

        public double Rating { get; set; }

        public string Profit { get; set; }
        public CarWashStore(string  id, string address, int numOfWorkers, double rating, int profit) : base (id, address, numOfWorkers)
        {
            Id = id;
            Address = address;
            NumOfWorkers = numOfWorkers;
            Rating = rating;
            Profit = "$" + Convert.ToString(profit);
        }
    }
}
