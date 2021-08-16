using System;


namespace TrabalhadoresPorContrato.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }//Atributo data para o contrato
        public double ValuePerHour { get; set; }//Atributo valor por hora (que sera calculado no metodo)
        public int Hours {get; set; } //Atributo de horas

        //Construtor padrão de inicialização (obrigatorio)
        public HourContract()
        {
        }
        //construtora dos Atributos
        public HourContract(DateTime date, double valuePerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }
        //Metodo para calcular valor total 
        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }
    }
}
