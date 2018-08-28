using System;
using System.Collections.Generic;
using System.Data;
using DP;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        List<String> GetAllTables();
        List<String> GetAllDB();
        DataTable GetTable(String table);
        void ChangeDataBaseInfo(DBInfo db);
        DBInfo GetCurrentInfo();
        bool CheckUserInfo(DBInfo db);
    }
}
