using System;

namespace ManagementSystem1.Models
{
    public class Location
    {
        public virtual string Id { get; set; }
        public virtual string Address { get; set; }
        public virtual int NumOfWorkers {  get; set; }

        public Location() { }
        public Location(string id, string address, int numOfWorkers)
        {
            Id = id;
            Address = address;
            NumOfWorkers = numOfWorkers;
        }
    }
}
