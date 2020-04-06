using System;
using System.Collections.Generic;
using System.Text;
using News.SQLite;
using SQLite;

namespace News.SQLite
{
    public interface SQLiteConn
    {
        SQLiteConnection GetConnection();
    }
}
