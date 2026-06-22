using ManagementSystem1.Models;
using ManagementSystem1.Services;
using System;
using System.Xml.Serialization;

namespace ManagementSystem1.Services
{
    interface LocationService
    {


        void add();
        void view();
        void Update();
        void Delete();
    }
}
