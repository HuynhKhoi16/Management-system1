using ManagementSystem1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem1.Database_Connection
{
    public interface IDatabase<T> where T : class
    {
        bool IdInDatabase(string id);
        void AddToDatabase(T Entity);
        void ViewDatabase();
        void UpdateToDatabase(T Entity, string oldId);
        void DeleteFromDatabase(String Id);

    }
}
