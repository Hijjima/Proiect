using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarieModele;
using NivelStocareDate;

namespace InchiriereMasini
{
    class Program
    {
        static void Main()
        {
            AdministrareFirma admin = new AdministrareFirma();
            string optiune;

            do
            {
                Console.WriteLine("1. Adauga masina");
                Console.WriteLine("2. Afiseaza masini");
                Console.WriteLine("3. Adauga client");
                Console.WriteLine("4. Afiseaza clienti");
                Console.WriteLine("5. Cauta masina dupa marca");
                Console.WriteLine("0. Iesire");

                optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Masina m = CitireMasina();
                        admin.AddMasina(m);
                        break;

                    case "2":
                        AfisareMasini(admin.GetMasini());
                        break;

                    case "3":
                        Client c = CitireClient();
                        admin.AddClient(c);
                        break;

                    case "4":
                        AfisareClienti(admin.GetClienti());
                        break;
                    case "5":
                        Console.Write("Marca: ");
                        string marca = Console.ReadLine();

                        var masina = admin.CautaMasinaDupaMarca(marca);

                        if (masina != null)
                            Console.WriteLine(masina.Info());
                        else
                            Console.WriteLine("Nu exista masina.");

                        break;
                }

            } while (optiune != "0");
        }

        static Masina CitireMasina()
        {
            Console.Write("Marca: ");
            string marca = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            return new Masina(0, marca, model);
        }

        static Client CitireClient()
        {
            Console.Write("Nume: ");
            string nume = Console.ReadLine();

            Console.Write("Prenume: ");
            string prenume = Console.ReadLine();

            Console.Write("CNP: ");
            string cnp = Console.ReadLine();

            return new Client { Nume = nume, Prenume = prenume, CNP = cnp };
        }

        static void AfisareMasini(List<Masina> masini)
        {
            foreach (var m in masini)
                Console.WriteLine(m.Info());
        }

        static void AfisareClienti(List<Client> clienti)
        {
            foreach (var c in clienti)
                Console.WriteLine(c.Info());
        }
    }
}