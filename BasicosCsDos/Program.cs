using System;
using OperacionUno;
using OperacionDos;
using OperacionTres;

/*Ejercicio 1: Delegado Básico
Declara un delegado llamado Operacion que acepte dos enteros y devuelva un entero. 
Luego, crea un método llamado Sumar que sume dos números y lo llame desde el Main.*/
namespace OperacionUno
{
    internal class OperacionUnoProgram
    {
        delegate int Operacion(int a,  int b);

        static int Sumar(int a, int b)
        {
            return a + b;
        }

        public static void Ejecutar()
        {
            Operacion op = Sumar;

            Console.WriteLine(op(5, 2));
        }
    }
}

/*Ejercicio 2: Múltiples Métodos
Añade un segundo método llamado Restar que reste dos números. Asigna ambos 
métodos al delegado y llama a cada uno desde el Main.*/
namespace OperacionDos
{
    internal class OperacionDosProgram
    {
        delegate int Operacion(int a, int b);

        static int Sumar(int a, int b)
        {
            return a + b;
        }

        static int Restar(int a, int b)
        {
            return a - b;
        }

        public static void Ejecutar()
        {
            Operacion op = Sumar;
            op += Restar;

            foreach (Operacion metodo in op.GetInvocationList())
            {
                Console.WriteLine(metodo(5, 2));
            }
        }
    }
}

/*Ejercicio 3: Uso de Multicast Delegates
Crea un tercer método llamado Multiplicar. Asigna los tres métodos al mismo delegado 
y llama a todos en el Main.*/
namespace OperacionTres
{
    internal class OperacionTresProgram
    {
        delegate int Operacion(int a, int b);

        static int Sumar(int a, int b)
        {
            return a + b;
        }

        static int Restar(int a, int b)
        {
            return a - b;
        }

        static int Multiplicar(int a, int b)
        {
            return (a * b);
        }

        public static void Ejecutar()
        {
            Operacion op = Sumar;
            op += Restar;
            op += Multiplicar;

            foreach (Operacion metodo in op.GetInvocationList())
            {
                Console.WriteLine(metodo(5, 2));
            }
        }
    }
}

namespace BasicosCsDos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio uno");
            OperacionUnoProgram.Ejecutar();
            Console.WriteLine();

            Console.WriteLine("Ejercicio dos");
            OperacionDosProgram.Ejecutar();
            Console.WriteLine();

            Console.WriteLine("Ejercicio tres");
            OperacionTresProgram.Ejecutar();
            Console.WriteLine();
        }
    }
}
