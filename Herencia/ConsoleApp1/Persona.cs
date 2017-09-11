using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Persona
    {
        private int _id;
        private String _nombre;
        private String _apellidos;
        private int _edad;

        public Persona(string nombre, string apellidos, int edad)
        {
            _nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
            _edad = edad;
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public int Edad { get => _edad; set => _edad = value; }
        public int Id {
            get {
                return _id;
            }
            set {
                _id = value;
            }
        }


        public override string ToString()
        {
            return "Mi nombre es: "+_nombre+" con apellidos: "+_apellidos+" con edad: "+_edad;
        }
    }
}
