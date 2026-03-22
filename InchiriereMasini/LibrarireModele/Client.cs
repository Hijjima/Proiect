using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Client
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }

        public Client()
        {
            Nume = string.Empty;
            Prenume = string.Empty;
            CNP = string.Empty;
        }

        public string Info()
        {
            return $"{Nume} {Prenume} | CNP: {CNP}";
        }
    }
}
