using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace SPS_2
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
