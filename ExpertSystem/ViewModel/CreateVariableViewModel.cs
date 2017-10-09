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
        #region Active Selected Item on TabControl
        int _selectedTabItemIndex = 0;
        public int SelectedTabItemIndex
        {
            get
            {                
                return _selectedTabItemIndex;
            }
            set
            {
                _selectedTabItemIndex = value;
                OnPropertyChanged("SelectedTabItemIndex");
            }
        }
        #endregion

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


        #region Next Button Click
        RelayCommand _nextTabControlItemCommand;
        public ICommand NextTabControlItemCommand
        {
            get
            {
                if (_nextTabControlItemCommand == null)
                    _nextTabControlItemCommand = new RelayCommand(ExecuteNextTabControlCommand,
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
            if (_selectedTabItemIndex == 2)
                CloseWindow();
            else
                SelectedTabItemIndex = ++_selectedTabItemIndex;
        }
        #endregion


        #region Previous Button Click Command
        RelayCommand _previousTabControlItemCommand;
        public ICommand PreviousTabControlItemCommand
        {
            get
            {
                if (_previousTabControlItemCommand == null)
                    _previousTabControlItemCommand = new RelayCommand(ExecutePreviousTabControlCommand, 
                        (obj) => { return _selectedTabItemIndex > 0; });
                return _previousTabControlItemCommand;
            }
        }

        private void ExecutePreviousTabControlCommand(object obj)
        {
            SelectedTabItemIndex = --_selectedTabItemIndex;
        }
        #endregion


        #region Close Command
        RelayCommand _closeWindowCommand;
        public ICommand CloseWindowCommand
        {
            get
            {
                if (_closeWindowCommand == null)
                    _closeWindowCommand = new RelayCommand((obj) => CloseWindow(), (obj) => true);  //always can close window
                return _closeWindowCommand;
            }
        }
        #endregion


        TermModel _currentTerm;
        public TermModel CurrentTerm
        {
            get
            {
                if (_currentTerm == null)
                    _currentTerm = new TermModel();
                return _currentTerm;
            }
            set
            {
                _currentTerm = value;
                OnPropertyChanged("CurrentTerm");
            }
        }


        RelayCommand _addTerm;
        public ICommand AddTermCommand
        {
            get
            {
                if (_addTerm == null)
                    _addTerm = new RelayCommand(ExecuteAddTermCommand, CanExecuteAddTermCommand);
                return _addTerm;
            }
        }


        private bool CanExecuteAddTermCommand(object obj)
        {
            return !string.IsNullOrEmpty(_currentTerm?.NameTerm); //todo another
        }

        private void ExecuteAddTermCommand(object obj)
        {
            _newFuzzyVariable.Terms.Add(_currentTerm);
            CurrentTerm = null;
        }

    }
}
