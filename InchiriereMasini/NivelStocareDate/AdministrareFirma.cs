using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareFirma
    {
        private const string NUME_FISIER_MASINI = "masini.txt";
        private const string NUME_FISIER_CLIENTI = "clienti.txt";

        private List<Masina> masini;
        private List<Client> clienti;

        public AdministrareFirma()
        {
            masini = new List<Masina>();
            clienti = new List<Client>();

            IncarcaMasini();
            IncarcaClienti();
        }

        private void SalveazaMasini()
        {
            using (StreamWriter sw = new StreamWriter(NUME_FISIER_MASINI, false))
            {
                foreach (var masina in masini)
                {
                    sw.WriteLine(masina.ConversieLaSirPentruFisier());
                }
            }
        }

        private void SalveazaClienti()
        {
            using (StreamWriter sw = new StreamWriter(NUME_FISIER_CLIENTI, false))
            {
                foreach (var client in clienti)
                {
                    sw.WriteLine(client.ConversieLaSirPentruFisier());
                }
            }
        }

        private void IncarcaMasini()
        {
            if (!File.Exists(NUME_FISIER_MASINI))
                return;

            using (StreamReader sr = new StreamReader(NUME_FISIER_MASINI))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    masini.Add(new Masina(linie));
                }
            }
        }

        private void IncarcaClienti()
        {
            if (!File.Exists(NUME_FISIER_CLIENTI))
                return;

            using (StreamReader sr = new StreamReader(NUME_FISIER_CLIENTI))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    clienti.Add(new Client(linie));
                }
            }
        }

        public void AddMasina(Masina m)
        {
            m.IdMasina = GetNextIdMasina();
            masini.Add(m);
            SalveazaMasini();
        }

        public List<Masina> GetMasini()
        {
            return masini;
        }

        public Masina GetMasinaById(int id)
        {
            return masini.FirstOrDefault(m => m.IdMasina == id);
        }

        public bool ModificaMasina(int id, Masina masinaNoua)
        {
            var masina = masini.FirstOrDefault(m => m.IdMasina == id);
            if (masina == null)
                return false;

            masina.Marca = masinaNoua.Marca;
            masina.Model = masinaNoua.Model;
            masina.Culoare = masinaNoua.Culoare;
            masina.Optiuni = masinaNoua.Optiuni;

            SalveazaMasini();
            return true;
        }

        public bool StergeMasina(int id)
        {
            var masina = masini.FirstOrDefault(m => m.IdMasina == id);
            if (masina == null)
                return false;

            masini.Remove(masina);
            SalveazaMasini();
            return true;
        }

        public void AddClient(Client c)
        {
            clienti.Add(c);
            SalveazaClienti();
        }

        public List<Client> GetClienti()
        {
            return clienti;
        }

        public Client GetClientByCnp(string cnp)
        {
            return clienti.FirstOrDefault(c => c.CNP == cnp);
        }

        public bool ModificaClient(string cnp, Client clientNou)
        {
            var client = clienti.FirstOrDefault(c => c.CNP == cnp);
            if (client == null)
                return false;

            client.Nume = clientNou.Nume;
            client.Prenume = clientNou.Prenume;

            SalveazaClienti();
            return true;
        }

        public bool StergeClient(string cnp)
        {
            var client = clienti.FirstOrDefault(c => c.CNP == cnp);
            if (client == null)
                return false;

            clienti.Remove(client);
            SalveazaClienti();
            return true;
        }

        private int GetNextIdMasina()
        {
            if (masini.Count == 0)
                return 1;
            return masini.Max(m => m.IdMasina) + 1;
        }

        public Masina CautaMasinaDupaMarca(string marca)
        {
            return masini.FirstOrDefault(m => m.Marca.Equals(marca, StringComparison.OrdinalIgnoreCase));
        }

        public List<Masina> CautaMasiniDupaCuloare(CuloareMasina culoare)
        {
            return masini.Where(m => m.Culoare == culoare).ToList();
        }

        public List<Masina> CautaMasiniCuOptiune(OptiuniMasina optiune)
        {
            return masini.Where(m => m.Optiuni.HasFlag(optiune)).ToList();
        }

        public List<Masina> CautaMasiniDisponibile()
        {
            return masini.Where(m => m.Disponibila).ToList();
        }
    }
}