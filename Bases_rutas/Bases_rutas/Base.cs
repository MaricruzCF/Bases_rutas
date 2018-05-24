using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_rutas
{
    class Base
    {
        // Referencia al siguiente elemento de la lista
        public Base Siguiente { get; set; }


        // Atributos de la case
        private string _nombre;
        public string Nombre { get { return _nombre; } }

        private int _duracion;
        public int Duracion { get { return _duracion; } }

        // Constructor
        public Base(string nombre, int duracion)
        {
            _nombre = nombre;
            _duracion = duracion;
        }

        public override string ToString()
        {
            return "Nombre: " + Nombre + System.Environment.NewLine +
            "Duracion: " + Duracion + System.Environment.NewLine;
        }
    }
}
