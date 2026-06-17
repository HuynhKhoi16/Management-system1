using System;

namespace ManagementSystem1.Models
{
    abstract class location
    {
        public abstract string Id { get; set; }
        public abstract string Address { get; set; }

        public location(string id, string address)
        {
            Id = id;
            Address = address;
        }
    }
}
