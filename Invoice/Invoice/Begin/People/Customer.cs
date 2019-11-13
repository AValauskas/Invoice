using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Customer : Person
    {
        private bool doesdoesIndividualAction;
        public Customer(string name, Country country, Company company) : base(name, country, company)
        {
            this.doesdoesIndividualAction = false;
        }

        public Customer(string name, Country country, bool doesIndividualAction) : base(name, country)
        {
            this.doesdoesIndividualAction = doesIndividualAction;
        }
        //public Customer() { }

        public bool GetIfIndividualAction() 
        { 
        return doesdoesIndividualAction;
        }
    }
}
