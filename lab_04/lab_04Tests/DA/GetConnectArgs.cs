using lab_04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04Tests.DA
{
    public static class GetConnectArgs
    {
        public static ConnectionArgs getarg()
        {
            return new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432); 
        }
    }
}
