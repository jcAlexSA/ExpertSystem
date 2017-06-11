using ExpertSystem.Model.MMBF_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExpertSystem.Model
{
    public class Term
    {
        private string _nameTerm;
        private TriangleFunction _function; 

        public string NameTerm
        {
            get { return _nameTerm; }
            set { _nameTerm = value; }
        }

        public TriangleFunction Function
        {
            get { return _function; }
            set { _function = value; }
        }
        public override string ToString()
        {
            return string.Format("Term:{0}; Type Function:{1}; Low:{2}; Mid{3}; High:{4}", 
                NameTerm, Function.Name, Function.Low, Function.Mid, Function.High);
        }
        
    }        
}
