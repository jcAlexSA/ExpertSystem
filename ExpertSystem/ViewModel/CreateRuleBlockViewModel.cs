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
    public class CreateRuleBlockViewModel : ViewModelBase
    {
        public delegate void SendedVariablesAndRuleBlock(RuleBlockModel ruleBlock);

        public event SendedVariablesAndRuleBlock OnSendedVariableAndRuleBlockEvent;


        public CreateRuleBlockViewModel()
        {

        }

        public CreateRuleBlockViewModel(ObservableCollection<FuzzyVariableModel> sendedFuzzyVariables)
        {
            _sendedFuzzyVariables = sendedFuzzyVariables;
        }

        public CreateRuleBlockViewModel(ObservableCollection<FuzzyVariableModel> sendedFuzzyVariables, RuleBlockModel ruleBlock)
        {
            _sendedFuzzyVariables = sendedFuzzyVariables;
            _ruleBlock = ruleBlock;
        }

        #region Sended Fuzzy Variable
        private ObservableCollection<FuzzyVariableModel> _sendedFuzzyVariables;
        public ObservableCollection<FuzzyVariableModel> SendedFuzzyVariables
        {
            get
            {
                if (_sendedFuzzyVariables == null)
                    _sendedFuzzyVariables = new ObservableCollection<FuzzyVariableModel>();
                return _sendedFuzzyVariables;
            }
            set
            {
                _sendedFuzzyVariables = value;
                OnPropertyChanged("SendedFuzzyVariables");
            }
        }
        #endregion

        #region Current Rule Block
        private RuleBlockModel _ruleBlock;

        public RuleBlockModel RuleBlock
        {
            get
            {
                if (_ruleBlock == null)
                    _ruleBlock = new RuleBlockModel();
                return _ruleBlock;
            }
            set
            {
                _ruleBlock = value;
                OnPropertyChanged("RuleBlock");
            }
        }
        #endregion


        #region Add Rule Block
        RelayCommand _addRuleBlockCommand;
        public ICommand AddRuleBlockCommand
        {
            get
            {
                if (_addRuleBlockCommand == null)
                    _addRuleBlockCommand = new RelayCommand(ExecuteCreateRuleBlockCommand, CanExecuteCreateRuleBlockCommand);
                return _addRuleBlockCommand;
            }
        }

        private bool CanExecuteCreateRuleBlockCommand(object obj)
        {
            return _ruleBlock != null && !string.IsNullOrEmpty(_ruleBlock.Name);
        }

        private void ExecuteCreateRuleBlockCommand(object obj)
        {
            if(OnSendedVariableAndRuleBlockEvent != null)
                OnSendedVariableAndRuleBlockEvent(_ruleBlock);

            CloseWindow();
        }
        #endregion


        #region Close Window Command
        RelayCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand((obj) => CloseWindow(), (obj) => true );
                return _closeCommand;
            }
        }
        #endregion
    }
}
