using ManagementSystem1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Management_system1.Database_Connection
{
    public interface GSDatabase
    {
        public bool IdInDatabase(string Id);
        public void AddToDatabase(GasStation gasStation);
        public void ViewDatabase();
        public void UpdateToDatabase(GasStation gasStation, string Id);
        public void DeleteFromDatabase(String Id);

    }
}
