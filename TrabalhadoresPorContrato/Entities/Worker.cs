using System.Collections.Generic;
using TrabalhadoresPorContrato.Entities.Enums;

namespace TrabalhadoresPorContrato.Entities
{
    class Worker
    {
        public string  Name { get; set; } // Atributo Nome do trabalhador
        public WorkerLevel Level{ get; set; } //Atributo nivel do trabalhador do tipo Enumerador
        public double BaseSalary { get; set; } //Atributo salario base para o trabalhador
        public Department Department { get; set; } //Atributo Departamento do tipo "Classe Departamento" (Classe)
        //*****Classe Worker associando (acessando) o objeto (classe) Departament***********
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();//utiliza-se Lista para vários contratos, instansia-se para não ser NUla
        //*****Classe Worker associando (acessando) o objeto HourContract (classe)**********
        // Construtores
        public Worker() //construtor padrão sem parametros
        {
        }
        //Construtor com todos os parametros, exceto a lista contracts. constutor gerlamente são utilizados com apenas 1 parametro
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)//parametros para utilizar no corpo do construtor 
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Metodos

        //Metodo para adicionar contrato da lista contracts
        public void AddContract (HourContract contract)//contract, parametro para utilizar no corpo do metodo 
        {
            Contracts.Add(contract);
        }
       // Metodo para remover contrato da lista contracts
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        // Metodo para calcular quanto o trabalhador ganhou passando o metodo ano e  mês
        public double Income (int year, int month)
        {
            double sum = BaseSalary; //mesmo que não tenha contrato, o trabalhador vai ganha o salario base, por isso não pode ser = zeo
            foreach (HourContract contract in Contracts) //para cada variavel contract (contrato) do tipo HourContract (Classe) da lista "Contracts"...
            //******** pode-se criar uma variavel para a classe, exemplo "contract" para a classe "HourContract"
            { 
                if (contract.Date.Year == year & contract.Date.Month == month)// Se o ano deste contrato for igual ao ano digitado e idem para mês...
                {
                    sum += contract.TotalValue();// some no ganho total + TotalValue(metodo)
                }
            }
            return sum; //retorne a soma



        }



    }



}
