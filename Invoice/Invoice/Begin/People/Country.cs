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

        public string Name
        {
           get { return this.name; }
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

            return (this.name == anotherCountry.Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
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
