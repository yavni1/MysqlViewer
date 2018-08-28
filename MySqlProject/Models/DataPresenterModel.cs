using BL;
using DP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlProject.Models
{
    class DataPresenterModel
    {
        IBL bl;
        DBInfo db;
        public DataPresenterModel()
        {
            bl = new BL.BL();
            db = bl.GetUserInfo();
        }
        public DBInfo GetDBInfo()
        {
            return db;
        }

        public void SetUserInfo(DBInfo db)
        {
            this.db = db;
            bl.SetUserInfo(db);
        }
        public void SetDatabase(String db)
        {
            this.db.Db = db;
            bl.ChangeDatabase(this.db);
        }

        public List<String> GetAllTables()
        {
             return bl.GetAllTables();
        }

        public List<String> GetAllDB()
        {
            return bl.GetAllDB();
        }

        public DataTable GetTable(String table)
        {
            return bl.GetTable(table);
        }
    }
}
