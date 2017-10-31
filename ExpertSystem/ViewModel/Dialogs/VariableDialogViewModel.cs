using ExpertSystem.Model;
using MVVM_Sample.Infrastructure;
using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpertSystem.ViewModel
{
    public class VariableDialogViewModel : ViewModelBase
    {
        public delegate void SendNewVariableEventHandler(FuzzyVariableModel newFuzzyVariable);

        public event SendNewVariableEventHandler OnFuzzyVariableCreate;

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

        #region Constructor

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

        #endregion

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
            {
                if (OnFuzzyVariableCreate != null)
                    OnFuzzyVariableCreate(_newFuzzyVariable);

                CloseWindow();
            }
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

        #region Term Manager : add, remove, edit
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

        // Command of adding new term to the fuzzy variable
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
            return !string.IsNullOrEmpty(_currentTerm?.NameTerm); //todo another conditions and check on adding equals terms
        }

        private void ExecuteAddTermCommand(object obj)
        {
            _newFuzzyVariable.Terms.Add(_currentTerm);
            CurrentTerm = null;
        }

        RelayCommand _deleteTerm;
        public ICommand DeleteTermCommand
        {
            get
            {
                if (_deleteTerm == null)
                    _deleteTerm = new RelayCommand(ExecuteDeleteTermCommand, CanExecuteDeleteTermCommand);
                return _deleteTerm;
            }
        }

        private bool CanExecuteDeleteTermCommand(object obj)
        {
            return obj != null; 
        }

        /// <summary>
        /// type cast. create temp list to remove selected element. in empty collection add remain elements
        /// </summary>
        /// <param name="obj">array of selected items (terms)</param>
        private void ExecuteDeleteTermCommand(object obj)
        {
            if (obj == null)
                return;

            //type cast for futher work
            System.Collections.IList selectedItemsCollection = (System.Collections.IList)obj;
            var selectedCollection = selectedItemsCollection.Cast<TermModel>();

            //copy elements 
            List<TermModel> listAfterDelete = _newFuzzyVariable.Terms.ToList();

            //remove selected elements
            foreach (var item in selectedCollection)
                listAfterDelete.Remove(item);

            _newFuzzyVariable.Terms.Clear();
            //copy remain elements back to observing item
            foreach (var item in listAfterDelete)
                _newFuzzyVariable.Terms.Add(item);
        }
        #endregion
    }
}
