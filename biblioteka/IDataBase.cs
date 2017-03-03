using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteka
{
    interface IDataBase
    {
        bool IsConnected { get; }
        void Connect(string query);
    }
}
