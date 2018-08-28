using DP;
using MySqlProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MySqlProject.ViewModels
{
    class LoginVM :BaseVM
    {
        //login details
        private String server;
        private String username;
        private String password;
        private string sSLMode;
        public string Server { get => server; set { server = value; OnPropertyChanged("Server"); } }
        public string Username { get => username; set { username = value; OnPropertyChanged("Username"); } }
        public string Password { get => password; set { password = value; OnPropertyChanged("Password"); } }
        public string SSLMode { get => sSLMode; set { sSLMode = value; OnPropertyChanged("SSLMode"); } }

        private List<String> sslModes;
        public List<String> SSLModes { get =>sslModes ; set { sslModes = value;OnPropertyChanged("SSLModes"); } }

        //Is the input data valid
        private bool isValid;
        public bool IsValid { get => isValid; set { isValid = value; OnPropertyChanged("IsValid"); } }

        //Is the user successfully logging in
        private bool isLogin;
        public bool IsLogin { get => isLogin; set { isLogin = value; OnPropertyChanged("IsLogin"); } }

        //Command 
        public Command.Command LoginCommand { get ; set ; }

        //Inter ViewModel Communication
        public delegate void Messages();
        public event Messages OnSuccess;

        //The model
        LoginModel model;
        public LoginVM()
        {
            model = new LoginModel();
            SSLModes = new List<string> { "None" ,"Required", "Preferred" };
            SSLMode = SSLModes[0];
            IsValid = true;
            IsLogin = false;
            LoginCommand = new Command.Command(Login);
        }

        //The login command. 
        public void Login()
        {
            DBInfo db = new DBInfo();
            db.Username = Username;
            db.Password = Password;
            db.Server = Server;
            db.SslMode = SSLMode;
            if(model.Login(db))
            {
                //change window and pass parameters
                OnSuccess();
                IsLogin = true;
            }
            else
            {
                IsLogin = false;
            }
        }
    }
}
