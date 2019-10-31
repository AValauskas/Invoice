using System;
using InvoiceApp2.Model;

namespace InvoiceApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double PVM;
            bool clientTyp = false;
            bool clientVATT = false;
            bool clientEUNion = false;
            var provider = new Provider("UAB tiekėjas", "Lithuania", 21, "Kaunas", "326461131313", true);


            Console.WriteLine("whether the customer is an individual? True/False");
            string clientType = Console.ReadLine();
            clientType.ToLower();
            if (clientType == "false" || clientType == "true")
            {
                clientTyp = bool.Parse(clientType);

                Console.WriteLine("Client are VAT payer? True/False");
                string clientVAT = Console.ReadLine();

                clientVAT.ToLower();
                if (clientVAT == "false" || clientVAT == "true")
                {
                    clientVATT = bool.Parse(clientVAT);
                    Console.WriteLine("Client is from EU? True/False");
                    string clientEU = Console.ReadLine();

                    clientEU.ToLower();
                    if (clientEU == "false" || clientEU == "true")
                    {
                        clientEUNion = bool.Parse(clientEU);
                        Console.WriteLine("Write your Price");

                        double price = double.Parse(Console.ReadLine());
                        InvoiceW inv = new InvoiceW();

                        if (clientTyp)
                        {
                            var client = new Individual("356566", "individual", "JA klientas", "Spain", 30, "Pašilės 37", clientEUNion, clientVATT);
                            PVM = inv.VATcalculatorIndividual(client, provider, price);
                            Console.WriteLine("---------------INVOICE---------------");
                            Console.WriteLine("Provider                       Client");
                            Console.WriteLine("{0}               {1}     ", provider.name, client.name);
                            Console.WriteLine("{0}               {1}     ", provider.providerCode, client.clientCode);
                            Console.WriteLine("Price: {0} ", price);
                            Console.WriteLine("PVM {0}", PVM);
                        }
                        else
                        {
                            var client = new Company("356566", "Company", "JA klientas", "Spain", 30, "Pašilės 37", clientEUNion, clientVATT);
                            PVM = inv.VATcalculatorCompany(client, provider, price);
                            Console.WriteLine("---------------INVOICE---------------");
                            Console.WriteLine("Provider                       Client");
                            Console.WriteLine("{0}               {1}     ", provider.name, client.name);
                            Console.WriteLine("{0}               {1}     ", provider.providerCode, client.clientCode);
                            Console.WriteLine("PVM {0}", PVM);
                            Console.WriteLine("Price: {0} ", price+PVM);
                        }
                    }
                    else
                    {

                        Console.WriteLine("Client EU wasn't given bool type");
                    }

                    
                }
                else
                {

                    Console.WriteLine("VAT Payer wasn't given bool type");
                }
               
            }
            else
            {

                Console.WriteLine("Client type wasn't given bool type");
            }
        }    
    }
}
