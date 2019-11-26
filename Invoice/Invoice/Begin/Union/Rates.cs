using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.Union
{
    public class Rates
    {
        public string country { get; set; }
        public string standard_rate { get; set; }
    }
}
