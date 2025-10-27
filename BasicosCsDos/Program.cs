using System;
using OperacionUno;
using OperacionDos;
using OperacionTres;
using OperacionCuatro;
using OperacionCinco;
using OperacionSeis;
using OperacionSiete;
using OperacionOcho;
using OperacionNueve;

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

/*Ejercicio 4: Delegados con Diferentes Métodos
Agrega un método Dividir. Usa el delegado para llamar a todos los métodos, pero
maneja el caso de la división por cero.
*/
namespace OperacionCuatro
{
    internal class OperacionCuatroProgram
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
            return a * b;
        }

        static int Dividir(int a, int b)
        {
            if (b == 0)
                return int.MaxValue;
            return a / b;
        }

        public static void Ejecutar()
        {
            Operacion op = Sumar;
            op += Restar;
            op += Multiplicar;
            op += Dividir;

            foreach (Operacion metodo in op.GetInvocationList())
            {
                Console.WriteLine(metodo(5, 2));
            }
        }
    }
}

/*Ejercicio 5: Delegados y Retornos
Crea un método que reciba un delegado y dos enteros, y llame al delegado, imprimiendo
el resultado. Utiliza este método con los métodos Sumar, Restar, y Multiplicar.*/
namespace OperacionCinco
{
    internal class OperacionCincoProgram
    {
        public delegate int Operacion(int a, int b);

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
            return a * b;
        }

        public static void EjecutarOperacion(Operacion operacion, int a, int b)
        {
            int resultado = operacion(a, b);
            Console.WriteLine(resultado);
        }

        public static void Ejecutar()
        {
            EjecutarOperacion(Sumar, 5, 2);
            EjecutarOperacion(Restar, 5, 2);
            EjecutarOperacion(Multiplicar, 5, 2);
        }
    }
}

/*Ejercicio 6: Delegados y Nombres
Crea un delegado llamado Operar que acepte dos enteros y devuelva un entero. Define
tres métodos: Suma, Resta y Multiplicacion. Asigna estos métodos a un delegado y usa
un bucle para llamar a cada uno, imprimiendo el nombre del método junto con el
resultado.*/
namespace OperacionSeis
{
    internal class OperacionSeisProgram
    {
        public delegate int Operar(int a, int b);

        static int Suma(int a, int b)
        {
            return a + b;
        }

        static int Resta(int a, int b)
        {
            return a - b;
        }

        static int Multiplicacion(int a, int b)
        {
            return a * b;
        }

        public static void Ejecutar()
        {
            Operar operaciones = Suma;
            operaciones += Resta;
            operaciones += Multiplicacion;

            int a = 8;
            int b = 3;

            foreach (Operar operacion in operaciones.GetInvocationList())
            {
                Console.WriteLine(operacion(a, b));
            }
        }
    }
}

/*Ejercicio 7: Delegados y Arrays
Modifica el ejercicio anterior para que los métodos reciban un array de enteros y
devuelvan la suma de todos los elementos y en el caso del método Multiplicar, devuelva
la multiplicación de todos los elementos del array. Se descarta para este ejercicio el
método Restar. Usa el delegado para llamar a cada método, imprimiendo el resultado.*/
namespace OperacionSiete
{
    internal class OperacionSieteProgram
    {
        public delegate int Operar(int[] numeros);

        static int Suma(int[] numeros)
        {
            int suma = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                suma += numeros[i];
            }
            return suma;
        }

        static int Multiplicar(int[] numeros)
        {
            int resultado = 1;
            for (int i = 0; i < numeros.Length; i++)
            {
                resultado *= numeros[i];
            }
            return resultado;
        }

        public static void Ejecutar()
        {
            int[] misNumeros = { 2, 3, 4 };

            Operar operaciones = Suma;
            operaciones += Multiplicar;

            foreach (Operar operacion in operaciones.GetInvocationList())
            {
                Console.WriteLine(operacion(misNumeros));
            }
        }
    }
}

/*Ejercicio 8: Delegados y Retornos Condicionales
Crea un delegado llamado Transformar que acepte un entero y devuelva un entero.
Define tres métodos: Doblar, Triplicar y Cuadrado. Asigna estos métodos a un delegado
y usa un bucle para transformar un número dado y mostrar el resultado de cada método.*/
namespace OperacionOcho
{
    internal class OperacionOchoProgram
    {
        public delegate int Transformar(int numero);

        static int Doblar(int n)
        {
            return n * 2;
        }

        static int Triplicar(int n)
        {
            return n * 3;
        }

        static int Cuadrado(int n)
        {
            return n * n;
        }

        public static void Ejecutar()
        {
            Transformar operaciones = Doblar;
            operaciones += Triplicar;
            operaciones += Cuadrado;

            int miNumero = 5;

            foreach (Transformar metodo in operaciones.GetInvocationList())
            {
                Console.WriteLine(metodo(miNumero));
            }
        }
    }
}

/*Ejercicio 9: Delegados y Funciones de Callback 
Crea un delegado llamado OperacionCallback que acepte dos enteros y devuelva un 
entero. Define un método llamado EjecutarOperacion que acepte un delegado y dos
enteros, realice la operación usando el delegado y devuelva el resultado. Luego, 
implementa los métodos Suma, Resta y Multiplicar y usa EjecutarOperacion para 
ejecutar cada uno de ellos.*/
namespace OperacionNueve
{
    internal class OperacionNueveProgram
    {
        public delegate int OperacionCallback(int a, int b);

        public static int EjecutarOperacion(OperacionCallback operacion, int x, int y)
        {
            return operacion(x, y);
        }

        static int Suma(int a, int b)
        {
            return a + b;
        }

        static int Resta(int a, int b)
        {
            return a - b;
        }

        static int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public static void Ejecutar()
        {
            int a = 6, b = 3;

            int resultadoSuma = EjecutarOperacion(Suma, a, b);
            int resultadoResta = EjecutarOperacion(Resta, a, b);
            int resultadoMultiplicar = EjecutarOperacion(Multiplicar, a, b);

            Console.WriteLine(resultadoSuma);
            Console.WriteLine(resultadoResta);
            Console.WriteLine(resultadoMultiplicar);
        }
    }
}

/*Ejercicio 10: Delegados y Manejo de Errores
Crea un delegado llamado Calculo que acepte un número y devuelva un número. Define
métodos para calcular la raíz cuadrada y el logaritmo de un número. Implementa un
método que acepte un delegado y un número, y maneje posibles excepciones que
puedan surgir (como la raíz cuadrada de un número negativo). Imprime el resultado o
un mensaje de error.*/


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

            Console.WriteLine("Ejercicio cuatro");
            OperacionCuatroProgram.Ejecutar();
            Console.WriteLine();

            Console.WriteLine("Ejercicio cinco");
            OperacionCincoProgram.Ejecutar();
            Console.WriteLine();

            Console.WriteLine("Ejercicio seis");
            OperacionSeisProgram.Ejecutar();
            Console.WriteLine();

            Console.WriteLine("Ejercicio siete");
            OperacionSieteProgram.Ejecutar();
            Console.WriteLine();

            Console.WriteLine("Ejercicio ocho");
            OperacionOchoProgram.Ejecutar();
            Console.WriteLine();

            Console.WriteLine("Ejercicio nueve");
            OperacionNueveProgram.Ejecutar();
            Console.WriteLine();
        }
    }
}