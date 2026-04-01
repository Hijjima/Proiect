namespace LibrarieModele
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = '|';

        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }

        public Client()
        {
            Nume = string.Empty;
            Prenume = string.Empty;
            CNP = string.Empty;
        }

        public Client(string nume, string prenume, string cnp)
        {
            Nume = nume;
            Prenume = prenume;
            CNP = cnp;
        }

        public Client(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            Nume = dateFisier[0];
            Prenume = dateFisier[1];
            CNP = dateFisier[2];
        }

        public string ConversieLaSirPentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}",
                SEPARATOR_PRINCIPAL_FISIER,
                Nume ?? "NECUNOSCUT",
                Prenume ?? "NECUNOSCUT",
                CNP ?? "NECUNOSCUT");
        }

        public string Info()
        {
            return $"{Nume} {Prenume} | CNP: {CNP}";
        }
    }
}