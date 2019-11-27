using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Country
    {
        private string code { get; set; }
       
        public Country(string name)
        {
            this.code = name;
            if (name == null)
            { throw new BussinessException("Given Country name is null"); }
        }

        public string Code
        {
           get { return this.code; }
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Country);
        }

        public bool Equals(Country anotherCountry)
        {
            if (Object.ReferenceEquals(anotherCountry, null))
            {
                return false;
            }

            return (this.code == anotherCountry.Code);
        }
        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        public static bool operator == (Country lhs, Country rhs)
        {

            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Country lhs, Country rhs)
        {
            return !(lhs == rhs);
        }
    }
}
