using System;
using System.Collections.Generic;

namespace CalculadoraSalarios
{
    // Clase abstracta Empleado
    public abstract class Empleado
    {
        public string Nombre { get; set; }
        public bool MetaAlcanzada { get; set; }

        // Método abstracto para calcular el salario
        public abstract double CalcularSalario();
    }

    // Clase DocentePorHora
    public class DocentePorHora : Empleado
    {
        public int HorasTrabajadas { get; set; }
        private const double TarifaPorHora = 800;

        // Implementación del cálculo del salario
        public override double CalcularSalario()
        {
            return HorasTrabajadas * TarifaPorHora;
        }
    }

    // Clase DocenteContratoFijo
    public class DocenteContratoFijo : Empleado
    {
        public double SalarioBase { get; set; }

        // Implementación del cálculo del salario con bonificación
        public override double CalcularSalario()
        {
            if (MetaAlcanzada)
            {
                return SalarioBase;
            }
            else
            {
                return SalarioBase / 2; // Paga la mitad si no alcanza la meta
            }
        }
    }

    // Clase EmpleadoAdministrativo
    public class EmpleadoAdministrativo : Empleado
    {
        public double SalarioBase { get; set; }

        // Implementación del cálculo del salario con bonificación
        public override double CalcularSalario()
        {
            if (MetaAlcanzada)
            {
                return SalarioBase;
            }
            else
            {
                return SalarioBase / 2; // Paga la mitad si no alcanza la meta
            }
        }
    }

    // Clase Program con el método Main
    class calculoSalario
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>();
            string opcion;

            do
            {
                Console.WriteLine("Seleccione el tipo de empleado: ");
                Console.WriteLine("1. Docente por hora");
                Console.WriteLine("2. Docente de contrato fijo");
                Console.WriteLine("3. Empleado administrativo");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        DocentePorHora docenteHora = new DocentePorHora();
                        Console.Write("Ingrese el nombre del docente: ");
                        docenteHora.Nombre = Console.ReadLine();
                        Console.Write("Ingrese las horas trabajadas: ");
                        docenteHora.HorasTrabajadas = int.Parse(Console.ReadLine());
                        empleados.Add(docenteHora);
                        break;

                    case "2":
                        Console.Clear();
                        DocenteContratoFijo docenteFijo = new DocenteContratoFijo();
                        Console.Write("Ingrese el nombre del docente: ");
                        docenteFijo.Nombre = Console.ReadLine();
                        Console.Write("Ingrese el salario base: ");
                        docenteFijo.SalarioBase = double.Parse(Console.ReadLine());
                        Console.Write("¿Alcanzó la meta? (si/no): ");
                        docenteFijo.MetaAlcanzada = Console.ReadLine().ToLower() == "si";
                        empleados.Add(docenteFijo);
                        break;

                    case "3":
                        Console.Clear();
                        EmpleadoAdministrativo administrativo = new EmpleadoAdministrativo();
                        Console.Write("Ingrese el nombre del empleado: ");
                        administrativo.Nombre = Console.ReadLine();
                        Console.Write("Ingrese el salario base: ");
                        administrativo.SalarioBase = double.Parse(Console.ReadLine());
                        Console.Write("¿Alcanzó la meta? (si/no): ");
                        administrativo.MetaAlcanzada = Console.ReadLine().ToLower() == "si";
                        empleados.Add(administrativo);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("¿Desea ingresar otro empleado? (si/no): ");
                opcion = Console.ReadLine();
                Console.Clear();

            } while (opcion.ToLower() == "si");

            // Mostrar los salarios calculados
            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine($"Empleado: {empleado.Nombre}, Salario: {empleado.CalcularSalario():C}");
           
            }
        }
    }
}
