using DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DALFactory
    {
        public static IDAL Dal = null;

        public static IDAL GetInstance()
        {
            if (Dal == null)
                Dal = new DALMySql();
            return Dal;
        }
    }
}
