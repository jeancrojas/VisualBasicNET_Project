using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Profesor:Persona
    {
        private String deAsignatura;

        public Profesor(string deAsignatura,String nombre, String apellidos, int edad):base(nombre, apellidos, edad)
        {
            this.deAsignatura = deAsignatura ?? throw new ArgumentNullException(nameof(deAsignatura));
        }

        public Profesor(string nombre, string apellidos, int edad) : base(nombre, apellidos, edad)
        {

        }

        public override string ToString()
        {
            return "Soy profesor de la asignatura: "+deAsignatura+"\n\nNombre: "+base.Nombre + "\nApellidos: "+base.Apellidos+"\nEdad: "+base.Edad;
        }

        //public Profesor(string deAsignatura) : base()
        //{
        //    this.deAsignatura = deAsignatura ?? throw new ArgumentNullException(nameof(deAsignatura));
        //}


    }
}
