using ExpertSystem.Model;
using MVVM_Sample.Infrastructure;
using MVVM_Sample.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ExpertSystem.ViewModel
{
    public class RuleBlockDialogViewModel : ViewModelBase
    {
        public delegate void SendedVariablesAndRuleBlock(RuleBlockModel ruleBlock);

        public event SendedVariablesAndRuleBlock OnSendedVariableAndRuleBlockEvent;

        #region Constructors
        public RuleBlockDialogViewModel() : this(null, null) { }

        public RuleBlockDialogViewModel(ObservableCollection<FuzzyVariableModel> sendedVariables) : this(sendedVariables, null) { }

        public RuleBlockDialogViewModel(ObservableCollection<FuzzyVariableModel> sendedFuzzyVariables, RuleBlockModel ruleBlock)
        {
            _sendedFuzzyVariables = sendedFuzzyVariables;
            _ruleBlock = ruleBlock;
        }
        #endregion


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
            if (OnSendedVariableAndRuleBlockEvent != null)
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
                    _closeCommand = new RelayCommand((obj) => CloseWindow(), (obj) => true);
                return _closeCommand;
            }
        }
        #endregion


        #region Pass Selected Item To Input Variables Command
        RelayCommand _toInputListCommand;
        public ICommand ToInputListCommand
        {
            get
            {
                if (_toInputListCommand == null)
                    _toInputListCommand = new RelayCommand(ExecuteTransferSentVariableToInputListVariables,
                        CanTransferSentVariablesToInputOrOutputList);
                return _toInputListCommand;
            }
        }

        /// <summary>
        /// Check if Sent variables list is not null and some item has selected
        /// </summary>
        /// <param name="obj">list box in that user select item</param>
        /// <returns>true if sent variables not null and at least one item has selected</returns>
        private bool CanTransferSentVariablesToInputOrOutputList(object obj)
        {
            return _sendedFuzzyVariables?.Count > 0;
        }

        private void ExecuteTransferSentVariableToInputListVariables(object obj)
        {
            if (obj == null)
                return;

            SendDataFromOneCollectionToSecond(_sendedFuzzyVariables, _ruleBlock.InputVariables, obj);
        }
        #endregion

        #region Pass Selected Item To Output Variables Command
        RelayCommand _toOutputListCommand;
        public ICommand ToOutputListCommand
        {
            get
            {
                if (_toOutputListCommand == null)
                    _toOutputListCommand = new RelayCommand(ExecuteTransferSentVariableToOutputListVariables,
                        CanTransferSentVariablesToInputOrOutputList);
                return _toOutputListCommand;
            }
        }

        private void ExecuteTransferSentVariableToOutputListVariables(object obj)
        {
            if (obj == null)
                return;
            
            SendDataFromOneCollectionToSecond(_sendedFuzzyVariables, _ruleBlock.OutputVatiables, obj);
        }
        #endregion

        /// <summary>
        /// Send from received Variables Collection Selected variables to Output OR Input ObservablesCollection<> in current RuleBlock
        /// </summary>
        /// <param name="fromVariables">collection, from which should to delete variables</param>
        /// <param name="whereVariables">collection, where should move variables</param>
        /// <typeparamref name="SelectedItemsCollection"/><param name="selectedVariables">collection of selected variables.</param>
        private void SendDataFromOneCollectionToSecond(ObservableCollection<FuzzyVariableModel> fromVariables,
            ObservableCollection<FuzzyVariableModel> whereVariables, object selectedVariables)
        {
            List<FuzzyVariableModel> whatVariablesMove = new List<FuzzyVariableModel>();
            foreach (var item in (System.Collections.IList)selectedVariables)   //get selected variables from selectedItemsCollection
            {
                whatVariablesMove.Add((FuzzyVariableModel)item);
            }

            (new Model.MembershipFunctionsModel.RuleBlockModels.RuleBlockManager()).
                MoveVariablesFromOneCollectionToAnother(fromVariables, whereVariables, whatVariablesMove);          //move variables
        }


        #region Remove Input or Output Fuzzy Variable From Current Rule Block
        RelayCommand _removeVariableFromRuleBlockCommand;
        public ICommand RemoveVartiableFromRuleBlockCommand
        {
            get
            {
                if (_removeVariableFromRuleBlockCommand == null)
                    _removeVariableFromRuleBlockCommand = new RelayCommand(
                        ExecuteRemoveVariableFromRuleBlock,
                        CanExecuteRemoveVariableFromRuleBlock);
                return _removeVariableFromRuleBlockCommand;
            }
        }


        private bool CanExecuteRemoveVariableFromRuleBlock(object obj)
        {
            return _ruleBlock.InputVariables?.Count() > 0 || _ruleBlock.OutputVatiables?.Count() > 0; //TODO LOGIC
        }

        private void ExecuteRemoveVariableFromRuleBlock(object obj)
        {
            if (obj == null)
                return;
            
            System.Windows.Controls.ListBox listBox = new System.Windows.Controls.ListBox();
            var objects = (object[])obj;
            //searching listBox, in that was selected items
            foreach (var item in objects)
            {
                if ((item as System.Windows.Controls.ListBox).SelectedItems.Count > 0)
                {
                    listBox = item as System.Windows.Controls.ListBox;//only one ListBox can be with SelectedItems, so here needn't collection of ListBoxes
                    break;
                }
            }

            if (listBox.SelectedItems.Count == 0)   //if there are not selected items - return
                return;
            
            List<FuzzyVariableModel> selectedVariables = new List<FuzzyVariableModel>();
            foreach (var item in listBox.SelectedItems)
            {
                selectedVariables.Add((FuzzyVariableModel)item);
            }
            
            Model.MembershipFunctionsModel.RuleBlockModels.RuleBlockManager rbManager = 
                new Model.MembershipFunctionsModel.RuleBlockModels.RuleBlockManager();

            rbManager.MoveVariablesFromOneCollectionToAnother(
                _ruleBlock.InputVariables, _sendedFuzzyVariables, selectedVariables);

            rbManager.MoveVariablesFromOneCollectionToAnother(
                _ruleBlock.OutputVatiables, _sendedFuzzyVariables, selectedVariables);
        }

        #endregion
    }
}
