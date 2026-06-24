using ManagementSystem1.Models;
using ManagementSystem1.Services;
using System;
using System.Xml.Serialization;

namespace ManagementSystem1.Services
{
    interface LocationService<T> where T : class
    {
        bool IdInDatabase(string id);

        void Add(T entity);
        void View();
        void Update(T entity, string oldId);
        void Delete(string id);
        
    }
}
