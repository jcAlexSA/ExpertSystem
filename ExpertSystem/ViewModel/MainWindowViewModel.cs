using ExpertSystem.Model;
using ExpertSystem.Model.MMBF_Functions;
using ExpertSystem.View;
using MVVM_Sample.Infrastructure;
using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        TriangleFunction _function;
        public TriangleFunction Function
        {
            get
            {
                if (_function == null)
                    _function = new TriangleFunction();
                return _function;
            }
            set
            {
                _function = value;
                OnPropertyChanged("Function");
            }
        }

        Term _term;
        public Term TermProp
        {
            get
            {
                if (_term == null)
                    _term = new Term();
                return _term;
            }
            set
            {
                _term = value;
                OnPropertyChanged("TermProp");
            }
        }

        ObservableCollection<Term> _currentTermsCollection;
        public ObservableCollection<Term> CurrentTermsCollection
        {
            get
            {
                if (_currentTermsCollection == null)
                    _currentTermsCollection = TermsCollection.TermCollection;
                return _currentTermsCollection;
            }
        }

        RelayCommand _addTerm;
        public ICommand AddTerm
        {
            get
            {
                if (_addTerm == null)
                    _addTerm = new RelayCommand(ExecuteAddTerm, CanExecuteAddTerm);
                return _addTerm;
            }
        }

        private bool CanExecuteAddTerm(object obj)
        {
            if (string.IsNullOrEmpty(Function.Name) || string.IsNullOrEmpty(TermProp.NameTerm) || Function.Low > Function.Mid || Function.Mid > Function.High)
            {
                Console.WriteLine("Function.name: " + Function.Name);
                Console.WriteLine("TermProp.NameTerm: " + TermProp.NameTerm);
                Console.WriteLine("Function.Low: " + Function.Low);
                Console.WriteLine("Function.Mid: " + Function.Mid);
                Console.WriteLine("Function.High: " + Function.High);
                return false;
            }
            return true;

        }

        private void ExecuteAddTerm(object obj)
        {
            if (Function.Low > Function.Mid || Function.Mid > Function.High)
            {
                MessageBox.Show("Input error: The parameters of triangle membership function couldn`t has such values! (Low <= Mid <= High)");
                return;
            }
            TermProp.Function = Function;
            if (TermProp.Function == null)
            {
                Console.WriteLine("FUNCTION IS NULL");
                return;
            }
            CurrentTermsCollection.Add(TermProp);
            TermProp = null;
            Function = null;

            Console.WriteLine("terms collection:");
            foreach (var item in CurrentTermsCollection)
            {
                Console.WriteLine(item.NameTerm + " " + item.Function.Name + " " + item.Function.Low + " " + item.Function.Mid + " " + item.Function.High);                
            }
        }




        static FuzzyVariable _fuzzyVariable;
        public FuzzyVariable FuzzyVariable      //текущая переменная
        {
            get
            {
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


        ObservableCollection<FuzzyVariable> _variablesCollection;
        public ObservableCollection<FuzzyVariable> VarCollection
        {
            get
            {
                if (_variablesCollection == null)
                    _variablesCollection = VariablesCollection.AllVariables;
                return _variablesCollection;
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
            if (_fuzzyVariable != null && (string.IsNullOrEmpty(_fuzzyVariable.Name) || string.IsNullOrEmpty(_fuzzyVariable.Type.ToString())))
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
               


       
        #region MBF Definition window           

        RelayCommand _openCommentVarWindow;              
        public ICommand CommentorVariableWindowOpen
        {
            get { 
                Console.WriteLine("get open comment var window");
                if (_openCommentVarWindow == null)
                    _openCommentVarWindow = new RelayCommand(ExecuteOpenCommentVarWidowCommand, CanExecuteOpenCommentorVarWindow);
                
                return _openCommentVarWindow;
            }
        }

        private bool CanExecuteOpenCommentorVarWindow(object obj)
        {
            return true;       
        }

        private void ExecuteOpenCommentVarWidowCommand(object obj)
        {
            FuzzyVariable.Terms = CurrentTermsCollection.ToList();

            Console.WriteLine("int var: " + FuzzyVariable.Name + " such terms: ");
            foreach (var item in FuzzyVariable.Terms)
            {
                Console.WriteLine(" _ " + item.NameTerm);
            }

            (obj as Window).Close();
            CommentorVariableWindow cvw = new CommentorVariableWindow();
            cvw.ShowDialog();
        }

        #endregion





        #region Comment variable Window


        RelayCommand _finishCreateFuzzyVariable;
        public ICommand FinishCreateFuzzyVariable
        {
            get
            {
                if (_finishCreateFuzzyVariable == null)
                    _finishCreateFuzzyVariable = new RelayCommand(ExecuteAddFuzzyVariable, (args) => { return true; });
                return _finishCreateFuzzyVariable;
            }
        }

        private void ExecuteAddFuzzyVariable(object obj)
        {
            (obj as Window).Close();

            VarCollection.Add(FuzzyVariable);
            FuzzyVariable = null;

            //Console.WriteLine("NAME : "+ _curName);

            Console.WriteLine("Current collection : ");
            foreach (var item in VarCollection)
            {
                Console.WriteLine(item.Name + " " + item.Type + " " + item.Comment + " " + item.Min + " " + item.Max);
            }
        }


        #endregion 




        RelayCommand _openPreviousWindow;
        public ICommand ReopenPreviousWindow
        {
            get
            {
                //Console.WriteLine("reopen");
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
               // Console.WriteLine("get close command");
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
           // Console.WriteLine("execute close command");

            _fuzzyVariable = null;
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
