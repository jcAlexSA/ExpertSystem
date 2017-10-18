﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model
{
    public class RuleBlockModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private ObservableCollection<FuzzyVariableModel> _inputVariables;

        public ObservableCollection<FuzzyVariableModel> InputVariables
        {
            get { return _inputVariables; }
            set { _inputVariables = value; }
        }

        private ObservableCollection<FuzzyVariableModel> _outputVariables;

        public ObservableCollection<FuzzyVariableModel> OutputVatiables
        {
            get { return _outputVariables; }
            set { _outputVariables = value; }
        }

        
        public RuleBlockModel()
        {

        }

        public RuleBlockModel(string name)
        {
            _name = name;
        }

        public RuleBlockModel(string name, ObservableCollection<FuzzyVariableModel> inputVariables,
            ObservableCollection<FuzzyVariableModel> outputVariables)
        {
            _name = name;
            _inputVariables = inputVariables;
            _outputVariables = outputVariables;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return (obj as RuleBlockModel).Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
