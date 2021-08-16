using System;
using System.Globalization;
using TrabalhadoresPorContrato.Entities;
using TrabalhadoresPorContrato.Entities.Enums;

namespace TrabalhadoresPorContrato
{
    class Program
    {
        static void Main(string[] args)
        {
            //Imprimindo na tela e recebendo os dados do trabalhador e do departamento
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter work date: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary:  ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //instanciando os objetos Department e Worker
            Department dept = new Department(deptName);//inclui a variavel digitada pelo usuario (deptName) no objeto dept da classe "Department"
            Worker worker = new Worker(name, level, baseSalary, dept);//como parametro as variaveis digitadas pelo usuario no objeto worker

            Console.Write("How many contracts to this worker?: ");
            int n = int.Parse(Console.ReadLine()); // guarda o valor digitado pelo usuario na variavel n

            for (int i = 1; i <= n; i++) //for do valor digitado pelo usuario para saber quantas passagens pelo for contrato ira ocorrer
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY) ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Durations (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);

                //Adicionando os contratos paa o trabalhador

                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + " : " + worker.Income(year, month)); 

        }
    }
}
