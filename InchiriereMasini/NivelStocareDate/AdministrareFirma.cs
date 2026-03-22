using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareFirma
    {
        private List<Masina> masini;
        private List<Client> clienti;
        private List<Inchiriere> inchirieri;

        public AdministrareFirma()
        {
            masini = new List<Masina>();
            clienti = new List<Client>();
            inchirieri = new List<Inchiriere>();
        }

        public void AddMasina(Masina m)
        {
            m.IdMasina = GetNextIdMasina();
            masini.Add(m);
        }

        public List<Masina> GetMasini()
        {
            return masini;
        }

        public void AddClient(Client c)
        {
            clienti.Add(c);
        }

        public List<Client> GetClienti()
        {
            return clienti;
        }

        public void AddInchiriere(Inchiriere i)
        {
            i.Masina.Disponibila = false;
            inchirieri.Add(i);
        }

        public List<Inchiriere> GetInchirieri()
        {
            return inchirieri;
        }

        private int GetNextIdMasina()
        {
            if (masini.Count == 0)
                return 1;

            return masini.Last().IdMasina + 1;
        }
        public Masina? CautaMasinaDupaMarca(string marca)
        {
            return masini.FirstOrDefault(m => m.Marca == marca);
        }
    }
}
