namespace LibrarieModele
{
    public class Inchiriere
    {
        public Masina Masina { get; set; }
        public Client Client { get; set; }
        public string DataStart { get; set; }
        public string DataFinal { get; set; }

        public string Info()
        {
            return $"{Masina.Info()} | {Client.Info()} | {DataStart} - {DataFinal}";
        }
    }
}