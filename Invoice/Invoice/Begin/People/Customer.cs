using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Customer : Person
    {
        private string name;
        private bool doesdoesIndividualAction;
        public Customer(Country country, Company company) : base(country, company)
        {
            this.doesdoesIndividualAction = false;
        }

        public Customer(string name, Country country, bool doesIndividualAction) : base(country)
        {
            this.doesdoesIndividualAction = doesIndividualAction;
            this.name = name;
        }
        public Customer() { }

        public bool GetIfIndividualAction() 
        { 
        return doesdoesIndividualAction;
        }
        public string GetName() {
            return this.name;
        }
    }
}
