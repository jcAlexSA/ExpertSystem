using MVVM_Sample.Infrastructure;
using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpertSystem.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        RelayCommand _openCreatingVariableWindowCommnad;
        public ICommand OpenCreatingVariableWindowCommand
        {
            get
            {
                if (_openCreatingVariableWindowCommnad == null)
                    _openCreatingVariableWindowCommnad = new RelayCommand(
                        ExecuteOpenCreateVariableWindowCommand
                        , CanExecuteOpenCreateVariableWindowCommand);
                return _openCreatingVariableWindowCommnad;
            }
        }

        private bool CanExecuteOpenCreateVariableWindowCommand(object obj)
        {
            return true;
        }

        private void ExecuteOpenCreateVariableWindowCommand(object obj)
        {
            View.CreateVariableView createVarWindow = new View.CreateVariableView();
            createVarWindow.Owner = App.Current.MainWindow;
            createVarWindow.ShowDialog();
        }
    }
}
