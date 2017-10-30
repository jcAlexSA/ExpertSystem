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
    public class RuleBlockViewModel : ViewModelBase
    {
        public delegate void SendedVariablesAndRuleBlock(RuleBlockModel ruleBlock);

        public event SendedVariablesAndRuleBlock OnSendedVariableAndRuleBlockEvent;

        #region Constructors
        public RuleBlockViewModel() : this(null, null) { }

        public RuleBlockViewModel(ObservableCollection<FuzzyVariableModel> sendedVariables) : this(sendedVariables, null) { }

        public RuleBlockViewModel(ObservableCollection<FuzzyVariableModel> sendedFuzzyVariables, RuleBlockModel ruleBlock)
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
        /// <returns>true if sent variables not null and at lesst one item has selected</returns>
        private bool CanTransferSentVariablesToInputOrOutputList(object obj)
        {
            //if (obj == null)
            //    return false;

            //var values = (object[])obj;

            //return _sendedFuzzyVariables?.Count > 0 && (int) values[0] != -1 && (bool) values[1];

            return _sendedFuzzyVariables?.Count > 0 && (int)obj != -1;
        }

        private void ExecuteTransferSentVariableToInputListVariables(object obj)
        {
            if (obj == null)
                return;

            SendDataFromOneCollectionToSecond(_sendedFuzzyVariables, _ruleBlock.InputVariables, (int)obj);
            _sendedFuzzyVariables.RemoveAt((int)obj);
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

            SendDataFromOneCollectionToSecond(_sendedFuzzyVariables, _ruleBlock.OutputVatiables, (int)obj);
            _sendedFuzzyVariables.RemoveAt((int)obj);
        }
        #endregion

        private void SendDataFromOneCollectionToSecond(ObservableCollection<FuzzyVariableModel> copyFromVariables,
            ObservableCollection<FuzzyVariableModel> recipientVariables, int indexCopyElement)
        {
            if (indexCopyElement < 0)
                return;

            recipientVariables.Add(copyFromVariables.ElementAt(indexCopyElement));
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

            //TODO method for this
            System.Windows.Controls.ListBox listBox = new System.Windows.Controls.ListBox();
            var objects = (object[])obj;
            foreach (var item in objects)
            {
                if ((item as System.Windows.Controls.ListBox).SelectedItems.Count > 0)
                {
                    listBox = item as System.Windows.Controls.ListBox;//only one ListBox can be with SelectedItems, so here needn't collection of ListBoxes
                    break;
                }
            }

            List<FuzzyVariableModel> variablesToChange;
            if (_ruleBlock.InputVariables.Contains(listBox.SelectedItems[0]))
            {
                variablesToChange = new List<FuzzyVariableModel>(_ruleBlock.InputVariables);
                foreach (var variable in listBox.SelectedItems)
                {
                    variablesToChange.Remove((FuzzyVariableModel)variable);
                }
            }




            //_sendedFuzzyVariables.Concat(variableCollection);



            //TODO change this temporary shit code on more flexible  and do items multiselected
            //List<System.Windows.Controls.ListBox> listBoxes = new List<System.Windows.Controls.ListBox>();
            //var objects = (object[])obj;
            //foreach (var item in objects)
            //{
            //    listBoxes.Add((System.Windows.Controls.ListBox)item);
            //}

            //if (listBoxes[0].SelectedIndex >= 0)
            //{
            //    _sendedFuzzyVariables.Add(_ruleBlock.InputVariables.ElementAt(listBoxes[0].SelectedIndex));
            //    _ruleBlock.InputVariables.RemoveAt(listBoxes[0].SelectedIndex);
            //}
            //else if (listBoxes[1].SelectedIndex >= 0)
            //{
            //    _sendedFuzzyVariables.Add(_ruleBlock.OutputVatiables.ElementAt(listBoxes[1].SelectedIndex));
            //    _ruleBlock.OutputVatiables.RemoveAt(listBoxes[1].SelectedIndex);
            //}
        }
        #endregion
    }
}
