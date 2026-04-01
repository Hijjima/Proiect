using System;
using System.Collections.Generic;

namespace LibrarieModele
{
    public enum CuloareMasina
    {
        Rosu,
        Alb,
        Negru,
        Albastru,
        Gri
    }

    [Flags]
    public enum OptiuniMasina
    {
        None = 0,
        AerConditionat = 1,
        Navigatie = 2,
        CutieAutomata = 4,
        ScauneIncazite = 8,
        Tractiune4x4 = 16,
        SenzoriParcare = 32
    }

    public class Masina
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = '|';

        public int IdMasina { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public bool Disponibila { get; set; }
        public CuloareMasina Culoare { get; set; }
        public OptiuniMasina Optiuni { get; set; }

        public Masina()
        {
            Marca = string.Empty;
            Model = string.Empty;
            Disponibila = true;
            Culoare = CuloareMasina.Alb;
            Optiuni = OptiuniMasina.None;
        }

        public Masina(int id, string marca, string model, CuloareMasina culoare, OptiuniMasina optiuni)
        {
            IdMasina = id;
            Marca = marca;
            Model = model;
            Disponibila = true;
            Culoare = culoare;
            Optiuni = optiuni;
        }

        public Masina(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            IdMasina = Convert.ToInt32(dateFisier[0]);
            Marca = dateFisier[1];
            Model = dateFisier[2];
            Disponibila = Convert.ToBoolean(dateFisier[3]);
            Culoare = (CuloareMasina)Convert.ToInt32(dateFisier[4]);
            Optiuni = (OptiuniMasina)Convert.ToInt32(dateFisier[5]);
        }

        public string ConversieLaSirPentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                SEPARATOR_PRINCIPAL_FISIER,
                IdMasina.ToString(),
                Marca ?? "NECUNOSCUT",
                Model ?? "NECUNOSCUT",
                Disponibila.ToString(),
                ((int)Culoare).ToString(),
                ((int)Optiuni).ToString());
        }

        public string Info()
        {
            return $"Id:{IdMasina} {Marca} {Model} | Culoare: {Culoare} | Opțiuni: {OptiuniInfo()} | Disponibila: {(Disponibila ? "Da" : "Nu")}";
        }

        public string OptiuniInfo()
        {
            if (Optiuni == OptiuniMasina.None)
                return "Nici o opțiune";

            List<string> optiuniList = new List<string>();

            if (Optiuni.HasFlag(OptiuniMasina.AerConditionat))
                optiuniList.Add("Aer condiționat");
            if (Optiuni.HasFlag(OptiuniMasina.Navigatie))
                optiuniList.Add("Navigație");
            if (Optiuni.HasFlag(OptiuniMasina.CutieAutomata))
                optiuniList.Add("Cutie automată");
            if (Optiuni.HasFlag(OptiuniMasina.ScauneIncazite))
                optiuniList.Add("Scaune încălzite");
            if (Optiuni.HasFlag(OptiuniMasina.Tractiune4x4))
                optiuniList.Add("4x4");
            if (Optiuni.HasFlag(OptiuniMasina.SenzoriParcare))
                optiuniList.Add("Senzori parcare");

            return string.Join(", ", optiuniList);
        }
    }
}