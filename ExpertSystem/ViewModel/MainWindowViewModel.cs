using ExpertSystem.Model;
using ExpertSystem.View;
using MVVM_Sample.Infrastructure;
using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExpertSystem.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        FuzzyVariable _fuzzyVariable;

        public FuzzyVariable FuzzyVariable
        {
            get
            {
                if (_fuzzyVariable == null) Console.WriteLine("null");
                else Console.WriteLine("valu : " + (byte) _fuzzyVariable.Type);
                Console.WriteLine("get value of variable");

                if (_fuzzyVariable == null)
                    _fuzzyVariable = new FuzzyVariable();
                return _fuzzyVariable;
            }
            set
            {
                Console.WriteLine("value variable changed");
                _fuzzyVariable = value;
                OnPropertyChanged("FuzzyVariable");
            }
        }
        

        #region Create variable window 


        RelayCommand _createNewVariable;
        public ICommand CreateVariable
        {
            get
            {
                if (_createNewVariable == null)
                    _createNewVariable = new 
                        RelayCommand(ExecuteCreateVariableCommand, (args)=>{return true;});
                return _createNewVariable;
            }
        }

        private void ExecuteCreateVariableCommand(object obj)
        {
            CreateVariableView crtVarWin = new CreateVariableView();
            crtVarWin.ShowDialog();
        }

        RelayCommand _mbf_DefinitionWindowOpenCommand;
        public ICommand MBF_DefinitionWindowOpenCommand
        {
            get{
                if (_mbf_DefinitionWindowOpenCommand == null)
                    _mbf_DefinitionWindowOpenCommand = new RelayCommand(ExecuteMBF_Def_WinOpen, CanExecuteMBF_Def_WinOpen);
                return _mbf_DefinitionWindowOpenCommand;
            }
        }

        private bool CanExecuteMBF_Def_WinOpen(object obj)
        {
            Console.WriteLine("name: {0}; type: {1} ", _fuzzyVariable.Name, _fuzzyVariable.Type);
            if (string.IsNullOrEmpty(_fuzzyVariable.Name) || string.IsNullOrEmpty(_fuzzyVariable.Type.ToString()))
                return false;
            return true; 
        }

        private void ExecuteMBF_Def_WinOpen(object obj)
        {
            Console.WriteLine(FuzzyVariable.Name + " " + FuzzyVariable.Type.ToString());
            (obj as Window).Close();
           
            MBD_Definition mbfDefWin = new MBD_Definition();
            mbfDefWin.ShowDialog();
        }

        #endregion
               

        #region MBF_def window

        RelayCommand _openCommentVarWinow;
        public ICommand CommentorVariableWindowOpen
        {
            get { 
                Console.WriteLine("get open comment var window");
                if (_openCommentVarWinow == null)
                    _openCommentVarWinow = new RelayCommand(ExecuteOpenVarWidowCommand, CanExecuteOpenCommentorVarVariableWindow);
                
                return _openCommentVarWinow;
            }
        }

        private bool CanExecuteOpenCommentorVarVariableWindow(object obj)
        {
            return true;        //  TODO RETURN ALLOW OFS CAN EXECUTE
        }

        private void ExecuteOpenVarWidowCommand(object obj)
        {
            (obj as Window).Close();
            CommentorVariableWindow cvw = new CommentorVariableWindow();
            cvw.ShowDialog();
        }

        #endregion


        #region Comment variable Window

        RelayCommand _finishCreateVariable;
        public ICommand FinishCreateVariable
        {
            get 
            {
                if (_finishCreateVariable == null)
                    _finishCreateVariable = new RelayCommand(ExecuteFinishCreateVariable, (atg) => { return true; });
                return _finishCreateVariable; ;
            }
        }

        private void ExecuteFinishCreateVariable(object obj)
        {
            (obj as Window).Close();
            //TODO finilize of creation variable
        }


        #endregion 

        RelayCommand _openPreviousWindow;
        public ICommand ReopenPreviousWindow
        {
            get
            {
                Console.WriteLine("reopen");
                if (_openPreviousWindow == null)
                    _openPreviousWindow = new RelayCommand(ExecuteOpenPreviousCreateVarWindow, (arg) => { return true; });
                return _openPreviousWindow;
            }
        }

        private void ExecuteOpenPreviousCreateVarWindow(object obj)
        {
            if (obj is MBD_Definition)
            {
                (obj as Window).Close();
                (new CreateVariableView()).ShowDialog();
            }
            else if (obj is CommentorVariableWindow)
            {
                (obj as Window).Close();
                (new MBD_Definition()).ShowDialog();
            }
        }


        RelayCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                Console.WriteLine("get close command");
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(ExecuteCloseCommand, (args) => { return true; });
                }
                return _closeCommand;
            }
        }

        private void ExecuteCloseCommand(object obj)
        {
            (obj as Window).Close();
            Console.WriteLine("execute close command");
        }


        #region Rule Block Wizard

        RelayCommand _openRuleBlockWizard;
        public ICommand OpenRuleBlockWizard
        {
            get
            {
                if (_openRuleBlockWizard == null)
                    _openRuleBlockWizard = new RelayCommand(ExecuteOpenRuleBlockWizard, (args) => { return true; });
                return _openRuleBlockWizard;
            }
        }

        private void ExecuteOpenRuleBlockWizard(object obj)
        {
            new RuleBlockWizard().ShowDialog();
        }

        #endregion

    }
}
