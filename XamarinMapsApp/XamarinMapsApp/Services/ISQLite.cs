using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMapsApp
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
