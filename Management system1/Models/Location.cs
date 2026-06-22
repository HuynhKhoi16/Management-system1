using System;

namespace ManagementSystem1.Models
{
    public abstract class location
    {
        public abstract string Id { get; set; }
        public abstract string Address { get; set; }
        public abstract int NumOfWorkers {  get; set; }

        public location(string id, string address, int numOfWorkers)
        {
            Id = id;
            Address = address;
            NumOfWorkers = numOfWorkers;
        }
    }
}
