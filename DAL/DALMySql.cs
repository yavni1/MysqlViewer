using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using DP;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALMySql : IDAL
    {
        MySqlConnection mySql;
        DBInfo info;
        public DALMySql()
        {
            mySql = new MySqlConnection();
        }

        public DBInfo GetCurrentInfo()
        {
            return this.info;
        }

        /// <summary>
        /// Change the DB we are currently in (Don't forget to set this first)
        /// </summary>
        /// <param name="db">Info of the db</param>
        public void ChangeDataBaseInfo(DBInfo db)
        {
            mySql.ConnectionString = "server="+db.Server+";" +
                                        "uid="+db.Username+";" +
                                        "pwd=" + db.Password + ";" +
                                        "database=" + db.Db + ";"+
                                        "SslMode="+db.SslMode+";";
        }

        /// <summary>
        /// Checks for user info, Sets the info the the connection string
        /// and connect to the MYSQL DB
        /// </summary>
        /// <param name="db">Info of the Mysql DB</param>
        /// <returns>true if the info are correct</returns>
        public bool CheckUserInfo(DBInfo db)
        {
            mySql.ConnectionString = "server=" + db.Server + ";" +
                                       "uid=" +db.Username + ";" +
                                       "Pwd=" + db.Password + ";" +
                                       "SslMode=" + db.SslMode + ";";
            try
            {
                mySql.Open();
            }
            catch (MySqlException ex)
            {
                //Invalid login details
                if (ex.Number == 1045|| ex.Number == 0)
                {
                    return false;
                }
                throw ex;
            }
            info = db;
            mySql.Close();
            return true;
        }

        /// <summary>
        /// Connects to the Mysql and retrives all dbs's name inside
        /// </summary>
        /// <returns>List of the names</returns>
        public List<string> GetAllDB()
        {
            List<String> result = new List<string>();
            mySql.Open();
            DataTable tables = mySql.GetSchema("Databases");
            foreach (DataRow item in tables.Rows)
            {
                result.Add((String)item[1]);
            }
            mySql.Close();
            return result;
        }

        /// <summary>
        /// Connects to the Mysql and retrives all tables's name inside the db
        /// </summary>
        /// <returns>List of tables's name</returns>
        public List<string> GetAllTables()
        {
            List<String> result = new List<string>();
            mySql.Open();
            DataTable tables = mySql.GetSchema("Tables");
            foreach (DataRow item in tables.Rows)
            {
                result.Add((String)item[2]);
            }
            mySql.Close();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">Table's name</param>
        /// <returns>The content of the table</returns>
        public DataTable GetTable(string table)
        {
            if (table == null)
                return null;
            DataTable result = new DataTable();
            String sqlCmd = "select * from " + table;
            //Just in case the connection is already open
            DALMySqlOpen();
          
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(sqlCmd, mySql);
            adapter.Fill(result);
            mySql.Close();
            return result;
        }

        void DALMySqlOpen()
        {
            if(mySql.State == ConnectionState.Closed)
            {
                mySql.Open();
            }
            else
            {
                mySql.Close();
                mySql.Open();
            }
        }
    }
}
