using System;
using System.Collections.Generic;
using System.Text;

namespace Management_system1.Menu_UI
{
    public interface UI
    {
        bool IdInDatabase(string Id);
        bool CheckValidId(string id);
        void MainHub();
    }
}
