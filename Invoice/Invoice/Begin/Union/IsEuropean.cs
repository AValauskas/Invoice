using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Begin.People;

namespace Invoice.Begin.Union
{
    public class IsEuropean: IIsEuropeanUnion
    {
        public bool IsEurope(string country) {

            //calculate calculate
            //this is just for a logic for unit testting
            return true;
        }
    }
}
