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
            //Kai paslaug� tiek�jas n�ra PVM mok�tojas
            if (provider.VATPayer == false)
            {
                PVM = 0;
            }
            //Paslaug� tiek�jas yra PVM mok�tojas
            else
            {   //Klientas gyvena u� europos s�jungos rib�
                if (client.europeanUnion == false)
                {
                    PVM = 0;
                }
                //Klientas gyvena europos s�jungos ribose
                else
                {
                    //Klientas n�ra PVM mok�tojas
                    if (client.PVMPayer == false)
                    {
                        //Klientas gyvena skirtingoje �alyje nei paslaug� tiek�jas
                        if (client.country != provider.country)
                        {
                            PVM = price * provider.countryVAT / 100;
                        }
                    }
                    //Klientas PVM mok�tojas
                    else
                    { //Klientas gyvena skirtingoje �alyje nei paslaug� tiek�jas
                        if (client.country != provider.country)
                        {
                            PVM = 0;
                        }

                    }
                }
                //Tiek�jas ir u�sakovas gyvena toje pa�ioje �alyje
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
            //Kai paslaug� tiek�jas n�ra PVM mok�tojas
            if (provider.VATPayer == false)
            {
                PVM = 0;
            }
            //Paslaug� tiek�jas yra PVM mok�tojas
            else
            {   //Klientas gyvena u� europos s�jungos rib�
                if (client.europeanUnion == false)
                {
                    PVM = 0;
                }
                //Klientas gyvena europos s�jungos ribose
                else
                {
                    //Klientas n�ra PVM mok�tojas
                    if (client.PVMPayer == false)
                    {
                        //Klientas gyvena skirtingoje �alyje nei paslaug� tiek�jas
                        if (client.country != provider.country)
                        {
                            PVM = price * provider.countryVAT / 100;
                        }
                    }
                    //Klientas PVM mok�tojas
                    else
                    { //Klientas gyvena skirtingoje �alyje nei paslaug� tiek�jas
                        if (client.country != provider.country)
                        {
                            PVM = 0;
                        }

                    }
                }
                //Tiek�jas ir u�sakovas gyvena toje pa�ioje �alyje
                if (client.country == provider.country)
                {
                    PVM = price * client.countryVAT / 100;

                }
            }
            return PVM;
        }
    }
	




}
