using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlProject.ViewModels
{
    class NavigationVM:BaseVM
    {
        private BaseVM selectedViewModel;
        public NavigationVM()
        {
            SelectedViewModel = new LoginVM();
            ((LoginVM)SelectedViewModel).OnSuccess += new LoginVM.Messages(SwitchVM); 
        }
       
        public BaseVM SelectedViewModel { get=> selectedViewModel; set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); } }

        public void SwitchVM()
        {
            SelectedViewModel = new DataPresenterVM();
        }
    }
}
