
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem1.Models
{
    //GAS STATION
    public class GasStation 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Address { get; set; }

        public int NumOfWorkers { get; set; }

        public int Profit { get; set; }

        public GasStation() { }

        public GasStation(string id, string address, int numOfWorkers, int profit) 
        {
            Id = id;
            Address = address;
            NumOfWorkers = numOfWorkers;
            Profit = profit;
        }


    }
}
