using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP
{
    public class DBInfo
    {
        private String username;
        private String password;
        private String db;
        private String server;
        private String sslMode;

        public string Password { get => password; set => password = value; }
        public string Db { get => db; set => db = value; }
        public string Server { get => server; set => server = value; }
        public string Username { get => username; set => username = value; }
        public string SslMode { get => sslMode; set => sslMode = value; }
    }
}
