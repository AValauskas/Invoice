using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApp2.Model
{
    public class InvoiceW : IInvoice
    {
        public InvoiceW() { }
        public double VATcalculatorIndividual(Individual client, Provider provider, double price)
        {
            double PVM = 0;
            //Kai paslaugø tiekëjas nëra PVM mokëtojas
            if (provider.VATPayer == false)
            {
                PVM = 0;
            }
            //Paslaugø tiekëjas yra PVM mokëtojas
            else
            {   //Klientas gyvena uþ europos sàjungos ribø
                if (client.europeanUnion == false)
                {
                    PVM = 0;
                }
                //Klientas gyvena europos sàjungos ribose
                else
                {
                    //Klientas nëra PVM mokëtojas
                    if (client.PVMPayer == false)
                    {
                        //Klientas gyvena skirtingoje ðalyje nei paslaugø tiekëjas
                        if (client.country != provider.country)
                        {
                            PVM = price * provider.countryVAT / 100;
                        }
                    }
                    //Klientas PVM mokëtojas
                    else
                    { //Klientas gyvena skirtingoje ðalyje nei paslaugø tiekëjas
                        if (client.country != provider.country)
                        {
                            PVM = 0;
                        }

                    }
                }
                //Tiekëjas ir uþsakovas gyvena toje paèioje ðalyje
                if (client.country == provider.country)
                {
                    PVM = price * client.countryVAT / 100;

                }
            }
            return PVM;
        }
        public double VATcalculatorCompany(Company client, Provider provider, double price)
        {
            double PVM = 0;
            //Kai paslaugø tiekëjas nëra PVM mokëtojas
            if (provider.VATPayer == false)
            {
                PVM = 0;
            }
            //Paslaugø tiekëjas yra PVM mokëtojas
            else
            {   //Klientas gyvena uþ europos sàjungos ribø
                if (client.europeanUnion == false)
                {
                    PVM = 0;
                }
                //Klientas gyvena europos sàjungos ribose
                else
                {
                    //Klientas nëra PVM mokëtojas
                    if (client.PVMPayer == false)
                    {
                        //Klientas gyvena skirtingoje ðalyje nei paslaugø tiekëjas
                        if (client.country != provider.country)
                        {
                            PVM = price * provider.countryVAT / 100;
                        }
                    }
                    //Klientas PVM mokëtojas
                    else
                    { //Klientas gyvena skirtingoje ðalyje nei paslaugø tiekëjas
                        if (client.country != provider.country)
                        {
                            PVM = 0;
                        }

                    }
                }
                //Tiekëjas ir uþsakovas gyvena toje paèioje ðalyje
                if (client.country == provider.country)
                {
                    PVM = price * client.countryVAT / 100;

                }
            }
            return PVM;
        }
    }
	




}
