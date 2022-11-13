using AppDev.ViewModels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppDev.Commands
{
    public class UpdateViewCommand : ICommand
    {

        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
      
            
            if (parameter.ToString() == "Employee")
            {
                viewModel.SelectedViewModel = new EmployeeViewModel();
            }
            else if (parameter.ToString() == "Todos")
            {
                viewModel.SelectedViewModel = new TodosViewModel();
            }
        }
    }
}
