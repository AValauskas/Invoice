﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Begin.People;

namespace Invoice.Begin.Union
{
    public interface ICountryInfoProvider
    {
        public bool IsInEurope(Country country);
       
    }
}
