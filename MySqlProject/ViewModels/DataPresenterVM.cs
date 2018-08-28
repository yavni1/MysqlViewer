using MySqlProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MySqlProject.ViewModels
{
    class DataPresenterVM : BaseVM
    {
        private List<String> databases;
        private String databaseChoice;

        private String choice;
        private DataTable table;
        private List<String> tables;
        DataPresenterModel model;

        public string Choice { get => choice; set
            { choice = value;
                OnPropertyChanged("Choice");
                UpdateView(); } }
        public DataTable Table { get => table; set { table = value; OnPropertyChanged("Table"); } }
        public List<String> Tables { get => tables; set { tables = value; OnPropertyChanged("Tables"); } }

        public List<string> Databases { get => databases; set { databases = value; OnPropertyChanged("Databases"); } }
        public string DatabaseChoice { get => databaseChoice;
            set {
                databaseChoice = value;
                OnPropertyChanged("DatabaseChoice");
                UpdateTables(); } }

        public DataPresenterVM()
        {
            try
            {

                model = new DataPresenterModel();
                model.SetUserInfo(model.GetDBInfo());
                Databases = model.GetAllDB();
                DatabaseChoice = Databases[1];
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateTables()
        {
            model.SetDatabase(DatabaseChoice);
            Tables = model.GetAllTables();
            Choice = Tables[0];
        }
        public void UpdateView()
        {
            Table = model.GetTable(Choice);
        }

    }
}
