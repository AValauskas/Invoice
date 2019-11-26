using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Country
    {
        private string name { get; set; }
       
        public Country(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Country country = (Country)obj;
                return (this.name == country.name);
            }
        }
    }
}
