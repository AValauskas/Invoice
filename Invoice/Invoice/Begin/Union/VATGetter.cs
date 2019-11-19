using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Begin.People;

namespace Invoice.Begin.Union
{
    public class VATGetter : IVatGetter
    {
        public int GetVAT(Provider person)
        {
            throw new NotImplementedException();
        }

        public int GetVAT(Customer person)
        {
            throw new NotImplementedException();
        }
    }
}
