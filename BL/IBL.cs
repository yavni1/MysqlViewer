using DP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        List<String> GetAllDB();
        List<String> GetAllTables();
        DataTable GetTable(String table);
        DBInfo GetUserInfo();
        void ChangeDatabase(DBInfo db);
        void SetUserInfo(DBInfo db);
        bool CheckUserInfo(DBInfo db);
    }
}
