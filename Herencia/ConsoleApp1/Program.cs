using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona jean = new Profesor("Informatica", "Lucas", "Colgate", 30);
            //Console.WriteLine(jean);
            Debug.WriteLine(jean);
            
        }
    }
}
