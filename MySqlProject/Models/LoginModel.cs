using BL;
using DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MySqlProject.Models
{
    class LoginModel
    {
        IBL bl;
        public LoginModel()
        {
            bl = new BL.BL();   
        }

        /// <summary>
        /// Log into database server and check if can,
        /// if not return false (and error)
        /// 
        /// </summary>
        /// <param name="db">The database server's info</param>
        /// <returns>True - for correct login
        /// , or false for error</returns>
        public bool Login(DBInfo db)
        {
            try {
                if (db.Username != null && db.Server != null)
                    return bl.CheckUserInfo(db);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        
    }
}
