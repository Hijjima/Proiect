using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine("\n=== MENIU PRINCIPAL ===");
                Console.WriteLine("1. Adauga masina");
                Console.WriteLine("2. Afiseaza masini");
                Console.WriteLine("3. Adauga client");
                Console.WriteLine("4. Afiseaza clienti");
                Console.WriteLine("5. Cauta masina dupa marca");
                Console.WriteLine("6. Cauta masini dupa culoare");
                Console.WriteLine("7. Cauta masini cu o optiune specifica");
                Console.WriteLine("8. Modifica masina");
                Console.WriteLine("9. Modifica client");
                Console.WriteLine("10. Sterge masina");
                Console.WriteLine("11. Sterge client");
                Console.WriteLine("0. Iesire");
                Console.Write("Alege o optiune: ");

                optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Masina m = CitireMasina();
                        admin.AddMasina(m);
                        Console.WriteLine("Masina adaugata cu succes!");
                        break;

                    case "2":
                        AfisareMasini(admin.GetMasini());
                        break;

                    case "3":
                        Client c = CitireClient();
                        admin.AddClient(c);
                        Console.WriteLine("Client adaugat cu succes!");
                        break;

                    case "4":
                        AfisareClienti(admin.GetClienti());
                        break;

                    case "5":
                        Console.Write("Introduceti marca cautata: ");
                        string marca = Console.ReadLine();
                        var masina = admin.CautaMasinaDupaMarca(marca);
                        if (masina != null)
                            Console.WriteLine(masina.Info());
                        else
                            Console.WriteLine("Nu exista masina cu aceasta marca.");
                        break;

                    case "6":
                        Console.WriteLine("Alege culoarea:");
                        Console.WriteLine("1. Rosu");
                        Console.WriteLine("2. Alb");
                        Console.WriteLine("3. Negru");
                        Console.WriteLine("4. Albastru");
                        Console.WriteLine("5. Gri");
                        Console.Write("Optiune: ");
                        string culoareInput = Console.ReadLine();

                        CuloareMasina culoareCautata = (CuloareMasina)(int.Parse(culoareInput) - 1);
                        var masiniDupaCuloare = admin.CautaMasiniDupaCuloare(culoareCautata);

                        if (masiniDupaCuloare.Count > 0)
                            AfisareMasini(masiniDupaCuloare);
                        else
                            Console.WriteLine("Nu exista masini de aceasta culoare.");
                        break;

                    case "7":
                        Console.WriteLine("Alege optiunea:");
                        Console.WriteLine("1. Aer conditionat");
                        Console.WriteLine("2. Navigatie");
                        Console.WriteLine("3. Cutie automata");
                        Console.WriteLine("4. Scaune incalzite");
                        Console.WriteLine("5. 4x4");
                        Console.WriteLine("6. Senzori parcare");
                        Console.Write("Optiune: ");
                        string optiuneInput = Console.ReadLine();

                        OptiuniMasina optiuneCautata = OptiuniMasina.None;
                        switch (optiuneInput)
                        {
                            case "1": optiuneCautata = OptiuniMasina.AerConditionat; break;
                            case "2": optiuneCautata = OptiuniMasina.Navigatie; break;
                            case "3": optiuneCautata = OptiuniMasina.CutieAutomata; break;
                            case "4": optiuneCautata = OptiuniMasina.ScauneIncazite; break;
                            case "5": optiuneCautata = OptiuniMasina.Tractiune4x4; break;
                            case "6": optiuneCautata = OptiuniMasina.SenzoriParcare; break;
                        }

                        var masiniCuOptiune = admin.CautaMasiniCuOptiune(optiuneCautata);

                        if (masiniCuOptiune.Count > 0)
                            AfisareMasini(masiniCuOptiune);
                        else
                            Console.WriteLine("Nu exista masini cu aceasta optiune.");
                        break;

                    case "8":
                        ModificaMasina(admin);
                        break;

                    case "9":
                        ModificaClient(admin);
                        break;

                    case "10":
                        StergeMasina(admin);
                        break;

                    case "11":
                        StergeClient(admin);
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

            Console.WriteLine("\nAlege culoarea:");
            Console.WriteLine("1. Rosu");
            Console.WriteLine("2. Alb");
            Console.WriteLine("3. Negru");
            Console.WriteLine("4. Albastru");
            Console.WriteLine("5. Gri");
            Console.Write("Optiune: ");

            CuloareMasina culoare = CuloareMasina.Alb;
            string culoareOpt = Console.ReadLine();
            switch (culoareOpt)
            {
                case "1": culoare = CuloareMasina.Rosu; break;
                case "2": culoare = CuloareMasina.Alb; break;
                case "3": culoare = CuloareMasina.Negru; break;
                case "4": culoare = CuloareMasina.Albastru; break;
                case "5": culoare = CuloareMasina.Gri; break;
            }

            Console.WriteLine("\nAlege optiunile (introdu numerele separate prin virgula):");
            Console.WriteLine("1. Aer conditionat");
            Console.WriteLine("2. Navigatie");
            Console.WriteLine("3. Cutie automata");
            Console.WriteLine("4. Scaune incalzite");
            Console.WriteLine("5. 4x4");
            Console.WriteLine("6. Senzori parcare");
            Console.WriteLine("Exemplu: 1,3,6");
            Console.Write("Optiuni: ");

            OptiuniMasina optiuni = OptiuniMasina.None;
            string optiuniInput = Console.ReadLine();
            string[] optiuniSelectate = optiuniInput.Split(',');

            foreach (string opt in optiuniSelectate)
            {
                switch (opt.Trim())
                {
                    case "1": optiuni |= OptiuniMasina.AerConditionat; break;
                    case "2": optiuni |= OptiuniMasina.Navigatie; break;
                    case "3": optiuni |= OptiuniMasina.CutieAutomata; break;
                    case "4": optiuni |= OptiuniMasina.ScauneIncazite; break;
                    case "5": optiuni |= OptiuniMasina.Tractiune4x4; break;
                    case "6": optiuni |= OptiuniMasina.SenzoriParcare; break;
                }
            }

            return new Masina(0, marca, model, culoare, optiuni);
        }

        static Client CitireClient()
        {
            Console.Write("Nume: ");
            string nume = Console.ReadLine();

            Console.Write("Prenume: ");
            string prenume = Console.ReadLine();

            Console.Write("CNP: ");
            string cnp = Console.ReadLine();

            return new Client(nume, prenume, cnp);
        }

        static void AfisareMasini(List<Masina> masini)
        {
            if (masini.Count == 0)
            {
                Console.WriteLine("Nu exista masini inregistrate.");
                return;
            }

            Console.WriteLine("\n=== LISTA MASINI ===");
            foreach (var m in masini)
            {
                Console.WriteLine(m.Info());
            }
        }

        static void AfisareClienti(List<Client> clienti)
        {
            if (clienti.Count == 0)
            {
                Console.WriteLine("Nu exista clienti inregistrati.");
                return;
            }

            Console.WriteLine("\n=== LISTA CLIENTI ===");
            foreach (var c in clienti)
            {
                Console.WriteLine(c.Info());
            }
        }

        static void ModificaMasina(AdministrareFirma admin)
        {
            Console.Write("Introduceti ID-ul masinii de modificat: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalid!");
                return;
            }

            var masinaExistenta = admin.GetMasinaById(id);
            if (masinaExistenta == null)
            {
                Console.WriteLine("Masina nu exista!");
                return;
            }

            Console.WriteLine("Introduceti noile date:");
            Masina masinaNoua = CitireMasina();

            if (admin.ModificaMasina(id, masinaNoua))
                Console.WriteLine("Masina modificata cu succes!");
            else
                Console.WriteLine("Eroare la modificare!");
        }

        static void ModificaClient(AdministrareFirma admin)
        {
            Console.Write("Introduceti CNP-ul clientului de modificat: ");
            string cnp = Console.ReadLine();

            var clientExistent = admin.GetClientByCnp(cnp);
            if (clientExistent == null)
            {
                Console.WriteLine("Clientul nu exista!");
                return;
            }

            Console.WriteLine("Introduceti noile date:");
            Client clientNou = CitireClient();

            if (admin.ModificaClient(cnp, clientNou))
                Console.WriteLine("Client modificat cu succes!");
            else
                Console.WriteLine("Eroare la modificare!");
        }

        static void StergeMasina(AdministrareFirma admin)
        {
            Console.Write("Introduceti ID-ul masinii de sters: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalid!");
                return;
            }

            if (admin.StergeMasina(id))
                Console.WriteLine("Masina stearsa cu succes!");
            else
                Console.WriteLine("Masina nu exista!");
        }

        static void StergeClient(AdministrareFirma admin)
        {
            Console.Write("Introduceti CNP-ul clientului de sters: ");
            string cnp = Console.ReadLine();

            if (admin.StergeClient(cnp))
                Console.WriteLine("Client sters cu succes!");
            else
                Console.WriteLine("Clientul nu exista!");
        }
    }
}