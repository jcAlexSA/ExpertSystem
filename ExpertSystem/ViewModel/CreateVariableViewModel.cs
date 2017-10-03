using ExpertSystem.Model;
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
    public class CreateVariableViewModel : ViewModelBase
    {
        FuzzyVariableModel _newFuzzyVariable;
        public FuzzyVariableModel NewFuzzyVariable
        {
            get
            {
                if (_newFuzzyVariable == null)
                    _newFuzzyVariable = new FuzzyVariableModel();
                return _newFuzzyVariable;
            }
            set
            {
                _newFuzzyVariable = value;
                OnPropertyChanged("NewFuzzyVariable");
            }
        }

        RelayCommand _nextTabControlItemCommand;
        public ICommand NextTabControlItemCommand
        {
            get
            {
                if (_nextTabControlItemCommand == null)
                    _nextTabControlItemCommand = new RelayCommand(
                        ExecuteNextTabControlCommand,
                        CanExecuteNextTabControlCommand);
                return _nextTabControlItemCommand;
            }
        }

        private bool CanExecuteNextTabControlCommand(object obj)
        {
            return _newFuzzyVariable != null && !string.IsNullOrEmpty(_newFuzzyVariable.Name) && _newFuzzyVariable.Type >= 0;
        }

        private void ExecuteNextTabControlCommand(object obj)
        {
            
        }
    }
}
