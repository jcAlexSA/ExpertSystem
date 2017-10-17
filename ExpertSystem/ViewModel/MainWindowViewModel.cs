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
        ObservableCollection<FuzzyVariableModel> _fuzzyVariables;

        public ObservableCollection<FuzzyVariableModel> FuzzyVariables
        {
            get
            {
                if (_fuzzyVariables == null)
                    _fuzzyVariables = new ObservableCollection<FuzzyVariableModel>();
                return _fuzzyVariables;
            }
            set
            {
                _fuzzyVariables = value;
                OnPropertyChanged("FuzzyVariables");
            }
        }

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

        #region Create Variable Window Command
        RelayCommand _openCreatingVariableWindowCommnad;
        public ICommand OpenCreatingVariableWindowCommand
        {
            get
            {
                if (_openCreatingVariableWindowCommnad == null)
                    _openCreatingVariableWindowCommnad = new RelayCommand(
                        (obj) => OpenWindow(new View.CreateVariableView())      //open Creation Variable Window
                        , (obj) => { return true; });
                return _openCreatingVariableWindowCommnad;
            }
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
                        (obj) => OpenWindow(new View.RuleBlockView())     //open Creation Rule Block Window
                        , (obj) => { return true; });
                return _openCreatingRuleBlockWindow;
            }
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
