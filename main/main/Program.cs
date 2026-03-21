using System;
using System.Collections.Generic;

// ===== MASINA =====
class Masina
{
    public string marca;
    public string model;
    public bool disponibila;

    public void Citire()
    {
        Console.Write("Marca: ");
        marca = Console.ReadLine();

        Console.Write("Model: ");
        model = Console.ReadLine();

        disponibila = true;
    }

    public void Afisare()
    {
        Console.WriteLine(marca + " " + model + " | Disponibila: " + disponibila);
    }
}

// ===== CLIENT =====
class Client
{
    public string nume;
    public string prenume;
    public string cnp;

    public void Citire()
    {
        Console.Write("Nume: ");
        nume = Console.ReadLine();

        Console.Write("Prenume: ");
        prenume = Console.ReadLine();

        Console.Write("CNP: ");
        cnp = Console.ReadLine();
    }

    public void Afisare()
    {
        Console.WriteLine(nume + " " + prenume + " | CNP: " + cnp);
    }
}

// ===== INCHIRIERE =====
class Inchiriere
{
    public Masina masina;
    public Client client;
    public string dataStart;
    public string dataFinal;

    public void Afisare()
    {
        Console.WriteLine("\n--- Inchiriere ---");
        masina.Afisare();
        client.Afisare();
        Console.WriteLine("Perioada: " + dataStart + " - " + dataFinal);
    }
}

// ===== FIRMA =====
class FirmaInchirieri
{
    public List<Masina> masini = new List<Masina>();
    public List<Client> clienti = new List<Client>();
    public List<Inchiriere> inchirieri = new List<Inchiriere>();

    public void AdaugaMasina()
    {
        Masina m = new Masina();
        m.Citire();
        masini.Add(m);
    }

    public void AfiseazaMasini()
    {
        foreach (var m in masini)
            m.Afisare();
    }

    public void CautaMasina()
    {
        Console.Write("Marca cautata: ");
        string marca = Console.ReadLine();

        foreach (var m in masini)
            if (m.marca == marca)
                m.Afisare();
    }

    public void AdaugaClient()
    {
        Client c = new Client();
        c.Citire();
        clienti.Add(c);
    }

    public void AfiseazaClienti()
    {
        foreach (var c in clienti)
            c.Afisare();
    }

    // 🔹 inchiriere simpla
    public void InchiriazaMasina()
    {
        if (masini.Count == 0 || clienti.Count == 0)
        {
            Console.WriteLine("Nu exista masini sau clienti.");
            return;
        }

        Console.WriteLine("Alege masina (index):");
        for (int i = 0; i < masini.Count; i++)
        {
            Console.Write(i + ": ");
            masini[i].Afisare();
        }

        int indexMasina = int.Parse(Console.ReadLine());

        Console.WriteLine("Alege client (index):");
        for (int i = 0; i < clienti.Count; i++)
        {
            Console.Write(i + ": ");
            clienti[i].Afisare();
        }

        int indexClient = int.Parse(Console.ReadLine());

        Inchiriere inc = new Inchiriere();
        inc.masina = masini[indexMasina];
        inc.client = clienti[indexClient];

        Console.Write("Data start: ");
        inc.dataStart = Console.ReadLine();

        Console.Write("Data final: ");
        inc.dataFinal = Console.ReadLine();

        masini[indexMasina].disponibila = false;

        inchirieri.Add(inc);
    }

    public void AfiseazaInchirieri()
    {
        foreach (var i in inchirieri)
            i.Afisare();
    }
}

// ===== MAIN =====
class Program
{
    static void Main()
    {
        FirmaInchirieri firma = new FirmaInchirieri();
        int opt;

        do
        {
            Console.WriteLine("\n--- MENIU ---");
            Console.WriteLine("1. Adauga masina");
            Console.WriteLine("2. Afiseaza masini");
            Console.WriteLine("3. Cauta masina");
            Console.WriteLine("4. Adauga client");
            Console.WriteLine("5. Afiseaza clienti");
            Console.WriteLine("6. Inchiriaza masina");
            Console.WriteLine("7. Afiseaza inchirieri");
            Console.WriteLine("0. Iesire");

            Console.Write("Optiune: ");
            opt = int.Parse(Console.ReadLine());

            switch (opt)
            {
                case 1: firma.AdaugaMasina(); break;
                case 2: firma.AfiseazaMasini(); break;
                case 3: firma.CautaMasina(); break;
                case 4: firma.AdaugaClient(); break;
                case 5: firma.AfiseazaClienti(); break;
                case 6: firma.InchiriazaMasina(); break;
                case 7: firma.AfiseazaInchirieri(); break;
            }

        } while (opt != 0);
    }
}