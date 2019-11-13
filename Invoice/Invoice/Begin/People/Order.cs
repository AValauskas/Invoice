using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Order
    {
        private double price;
        public Order(double price)
        {
            this.price = price ;
         }

        public double GetPrice() 
        {
            return this.price;
        }
    }
}
