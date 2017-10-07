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
                        (obj) => OpenWindow(new View.RuleBlockWizardView())     //open Creation Rule Block Window
                        , (obj) => { return true; });
                return _openCreatingRuleBlockWindow;
            }
        }

        #endregion
    }
}
