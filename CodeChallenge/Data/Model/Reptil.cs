using System;

namespace CodeChallenge.Data.Model
{
    public class Reptil : CarnivoroReptil
    {
        private const int DIAS_AYUNO = 3;
        public int DiasCambioPiel { get; set; }
        public override decimal CalcularAlimentoDiario()
        {
            return (Peso > 0 && Porcentaje > 0) ? (Peso * Porcentaje) / 7 : 0;
        }

        public override decimal CalcularAlimentoMensual()
        {
            int diasEnElMes = CalcularDiasEnElMes();
            int duracionCiclo = DiasCambioPiel + DIAS_AYUNO;
            int ciclosCompletos = diasEnElMes / duracionCiclo;
            int diasRestantes = diasEnElMes % duracionCiclo;

            int diasComidaCompleta = ciclosCompletos * DiasCambioPiel;
            int diasComidaRestante = Math.Min(diasRestantes, DiasCambioPiel);

            int diasComiendoTotal = diasComidaCompleta + diasComidaRestante;

            return diasComiendoTotal * CalcularAlimentoDiario();
        }
    }
}
