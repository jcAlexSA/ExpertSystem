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
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fuzzy Variables List
        ObservableCollection<FuzzyVariableModel> _fuzzyVariables;

        public ObservableCollection<FuzzyVariableModel> FuzzyVariables
        {
            get
            {
                if (_fuzzyVariables == null)
                    _fuzzyVariables = new ObservableCollection<FuzzyVariableModel>()
                    {
                        new FuzzyVariableModel() { Name = "var01", Type = 0},
                        new FuzzyVariableModel() { Name = "var02", Type = 0 },
                        new FuzzyVariableModel() { Name = "var13", Type = 1 },
                        new FuzzyVariableModel() { Name = "var14", Type = 1 },
                        new FuzzyVariableModel() { Name = "var25", Type = 2 },
                        new FuzzyVariableModel() { Name = "var26", Type = 2 },
                    };

                Console.WriteLine("get");
                return _fuzzyVariables;
            }
            set
            {
                _fuzzyVariables = value;
                OnPropertyChanged("FuzzyVariables");
                Console.WriteLine("property changed");
            }
        }
        #endregion

        #region Rule Blocks List
        ObservableCollection<RuleBlockModel> _ruleBlocks;
        public ObservableCollection<RuleBlockModel> RuleBlocks
        {
            get
            {
                if (_ruleBlocks == null)
                    _ruleBlocks = new ObservableCollection<RuleBlockModel>();
                return _ruleBlocks;
            }
            set
            {
                _ruleBlocks = value;
                OnPropertyChanged("RuleBlocks");
            }
        }
        #endregion

        #region Create Variable Window Command
        RelayCommand _openCreatingVariableWindowCommnad;
        public ICommand OpenCreatingVariableWindowCommand
        {
            get
            {
                if (_openCreatingVariableWindowCommnad == null)
                    _openCreatingVariableWindowCommnad = new RelayCommand(
                        ExecuteOpenCreateVaribleWindowCommand      //open Creation Variable Window
                        , (obj) => { return true; });
                return _openCreatingVariableWindowCommnad;
            }
        }

        private void ExecuteOpenCreateVaribleWindowCommand(object obj)
        {
            View.CreateVariableView createVariableView = new View.CreateVariableView();
            createVariableView.DataContext = new CreateVariableViewModel();
            ((CreateVariableViewModel)createVariableView.DataContext).OnFuzzyVariableCreate += OnFuzzyVariableAdd;
            createVariableView.ShowDialog();
        }

        private void OnFuzzyVariableAdd(FuzzyVariableModel newFuzzyVariable)
        {
            if (FuzzyVariables == null)
                FuzzyVariables = new ObservableCollection<FuzzyVariableModel>();

            if (!FuzzyVariables.Contains(newFuzzyVariable))
            {
                FuzzyVariables.Add(newFuzzyVariable);
                Console.WriteLine("added");
            }

            foreach (var item in _fuzzyVariables)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
        }
        #endregion


        #region Open Window Rule Block Creation
        RelayCommand _openCreatingRuleBlockWindow;
        public ICommand OpenCreatingRuleBlockWindow
        {
            get
            {
                if (_openCreatingRuleBlockWindow == null)
                    _openCreatingRuleBlockWindow = new RelayCommand(
                        ExecuteOpenCreationRuleBlockCommand     //open Creation Rule Block Window
                        , (obj) => { return true; });
                return _openCreatingRuleBlockWindow;
            }
        }

        private void ExecuteOpenCreationRuleBlockCommand(object obj)
        {
            View.RuleBlockView ruleBlockView = new View.RuleBlockView();
            ruleBlockView.DataContext = new CreateRuleBlockViewModel(_fuzzyVariables);
            ((CreateRuleBlockViewModel)ruleBlockView.DataContext).OnSendedVariableAndRuleBlockEvent += OnRuleBlockCreated;
           ruleBlockView.ShowDialog();
        }

        private void OnRuleBlockCreated(RuleBlockModel ruleBlock)
        {
            if (ruleBlock == null)
                return;

            if (_ruleBlocks == null)
                _ruleBlocks = new ObservableCollection<RuleBlockModel>();

            if (!_ruleBlocks.Contains(ruleBlock))
                _ruleBlocks.Add(ruleBlock);

            foreach (var item in _ruleBlocks)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
        }

        #endregion


        #region Mouse Coordinate Manager

        MouseCoordinate _mouseCoordinate;

        RelayCommand _mouseClickedCoordinateCommand;
        public ICommand MouseClickedCoordinateCommand
        {
            get
            {
                if (_mouseClickedCoordinateCommand == null)
                    _mouseClickedCoordinateCommand = new RelayCommand(ExecuteMouseClickedCommand,
                        CanExecuteClickedCommand);
                return _mouseClickedCoordinateCommand;
            }
        }

        private bool CanExecuteClickedCommand(object obj)
        {
            return _mouseClickedCoordinateCommand != null;
        }

        private void ExecuteMouseClickedCommand(object obj)
        {
          //  _mouseCoordinate = new MouseCoordinate();
        }


        #endregion
    }
}
