using ManagementSystem1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem1.Models
{
    //GAS STATION
    class GasStation : location
    {
        public override string Id { get; set; }
        public override string Address { get; set; }

        public int NumOfWorkers { get; set; }

        public string Profit { get; set; }

        public GasStation(string id, string address, int numOfWorkers, int profit) : base(id, address)
        {
            Id = id;
            Address = address;
            NumOfWorkers = numOfWorkers;
            Profit = "$" + Convert.ToString(profit);
        }


    }
}
