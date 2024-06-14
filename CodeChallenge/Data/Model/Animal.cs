using System;

namespace CodeChallenge.Data.Model
{
    public abstract class Animal
    {
        public DateTime FechaIngreso { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string LugarOrigen { get; set; }
        public decimal Peso { get; set; }

        public abstract decimal CalcularAlimentoDiario();
        public virtual decimal CalcularAlimentoMensual()
        {
            return CalcularDiasEnElMes() * CalcularAlimentoDiario();
        }

        public int CalcularDiasEnElMes()
        {
            DateTime hoy = DateTime.Today;
            int result = DateTime.DaysInMonth(hoy.Year, hoy.Month);

            if (FechaIngreso.Year == hoy.Year && FechaIngreso.Month == hoy.Month)
            {
                result -= FechaIngreso.Day; // Se asume que el día de ingreso el animal no se alimenta.
            }

            return result;
        }
    }
}