using ManagementSystem1.Models;
using ManagementSystem1.Services;
using System;
using System.Xml.Serialization;

namespace ManagementSystem1.Services
{
    interface LocationService<T> where T : class
    {

        void Add(T entity);
        List <T> View();
        void Update(T entity);
        void Delete(string id);
        
    }
}
