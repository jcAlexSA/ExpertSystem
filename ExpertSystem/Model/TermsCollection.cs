using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem.Model
{
    public static class TermsCollection
    {
        private static ObservableCollection<Term> _termsCollection;


        public static ObservableCollection<Term> TermCollection
        {
            get
            {
                if (_termsCollection == null)
                    _termsCollection = new ObservableCollection<Term>();

                return _termsCollection;
            }
        }
    }
}
