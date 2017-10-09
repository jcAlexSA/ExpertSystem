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
    public class CreateRuleBlockViewModel : ViewModelBase
    {
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

        #region Add rule block
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
            //TODO
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
