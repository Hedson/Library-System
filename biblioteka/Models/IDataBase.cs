using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteka
{
    interface IDataBase
    {
        bool IsConnected { get; }
        void DoQuery(string query);
        void SaveChanges(SqlDataAdapter dataAdapter);
    }
}
