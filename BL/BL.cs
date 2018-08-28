using DAL;
using DP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class BL : IBL
    {
        IDAL Dal;
        DBInfo db;
        public BL()
        {
            Dal = DALFactory.GetInstance();  
        }

        public void ChangeDatabase(DBInfo db)
        {
            Dal.ChangeDataBaseInfo(db);
        }
        public DBInfo GetUserInfo()
        {
            return Dal.GetCurrentInfo();
        }
        public bool CheckUserInfo(DBInfo db)
        {
            return Dal.CheckUserInfo(db);
        }
        public void SetUserInfo(DBInfo db)
        {
            this.db = db;
        }

        public List<string> GetAllDB()
        {
            return Dal.GetAllDB();
        }


        public List<string> GetAllTables()
        {
            return Dal.GetAllTables() ;
        }

        public DataTable GetTable(String table)
        {
            return Dal.GetTable(table);
        }
    }
}
