using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Masina
    {
        public int IdMasina { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public bool Disponibila { get; set; }

        public Masina()
        {
            Marca = string.Empty;
            Model = string.Empty;
            Disponibila = true;
        }

        public Masina(int id, string marca, string model)
        {
            IdMasina = id;
            Marca = marca;
            Model = model;
            Disponibila = true;
        }

        public string Info()
        {
            return $"Id:{IdMasina} {Marca} {Model} Disponibila:{Disponibila}";
        }
    }
}