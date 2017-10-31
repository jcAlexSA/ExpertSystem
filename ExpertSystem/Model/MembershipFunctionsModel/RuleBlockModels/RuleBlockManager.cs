using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model.MembershipFunctionsModel.RuleBlockModels
{
    public class RuleBlockManager
    {
        /// <summary>
        /// Method remove variables from one ObservableCollection<> and 
        ///             Add them into another ObservableCollection<> 
        /// </summary>
        /// <param name="variablesFromMove"></param>
        /// <param name="variablesWhereMove"></param>
        /// <param name="variablesWhatMove"></param>
        public void MoveVariablesFromOneCollectionToAnother(
            ObservableCollection<FuzzyVariableModel> variablesFromMove,
            ObservableCollection<FuzzyVariableModel> variablesWhereMove,
            List<FuzzyVariableModel> variablesWhatMove)
        {
            if (variablesFromMove == null || variablesWhereMove == null || variablesWhatMove?.Count == 0)
                return;

            if (!variablesFromMove.Contains(variablesWhatMove.First())) //if collection doesn't contain variables that need to remove
                return;

            foreach (var variable in variablesWhatMove)
            {
                variablesFromMove.Remove(variable);
                variablesWhereMove.Add(variable);
            }
        }
    }
}
