using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Invoice.Begin.People;

namespace InvoiceTests
{
    public partial class Component1 : Component
    {
        public Provider VATPAYER()
        {
            var provider = new Provider(new Country("LT", 21), new Company("Company"));
            return provider;
        }

        public Component1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
