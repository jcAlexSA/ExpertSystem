﻿using System;
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

        public string NameTerm
        {
            get { return _nameTerm; }
            set { _nameTerm = value; }
        }

        private object _valueTerm;
        public object ValueTerm
        {
            get { return _valueTerm; }
            set { _valueTerm = value; }
        }
    }
}