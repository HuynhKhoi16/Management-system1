using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem1.Models
{
    public class CarWashStore 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Address { get; set; }

        public int NumOfWorkers { get; set; }

        public decimal Rating { get; set; }

        public int Profit { get; set; }

        public CarWashStore() { }
        public CarWashStore(string  id, string address, int numOfWorkers, decimal rating, int profit) { 
            Id = id;
            Address = address;
            NumOfWorkers = numOfWorkers;
            Rating = rating;
            Profit = profit;
        }
    }
}
