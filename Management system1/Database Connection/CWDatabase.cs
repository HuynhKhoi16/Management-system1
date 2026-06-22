using ManagementSystem1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem1.Database_Connection
{
    public interface CWDatabase
    {
        bool IdInDatabase(string id);
        void AddToDatabase(CarWashStore carWashStore);
        void ViewDatabase();
        void UpdateToDatabase(CarWashStore carWashStore, string oldId);
        void DeleteFromDatabase(String Id);

    }
}
