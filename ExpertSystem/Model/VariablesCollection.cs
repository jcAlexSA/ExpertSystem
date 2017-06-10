using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model
{
    public static class VariablesCollection
    {
        private static ObservableCollection<FuzzyVariable> _fuzzyVariablesCollection;

        public static ObservableCollection<FuzzyVariable> AllVariables
        {
            get
            {
                if (_fuzzyVariablesCollection == null)
                    _fuzzyVariablesCollection = new ObservableCollection<FuzzyVariable>();

                return _fuzzyVariablesCollection;
            }
        }


    }
}
