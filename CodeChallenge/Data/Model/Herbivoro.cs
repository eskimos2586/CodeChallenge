namespace CodeChallenge.Data.Model
{
    public class Herbivoro : Animal
    {
        public decimal Kilos { get; set; }
        public override decimal CalcularAlimentoDiario()
        {
            return (Peso > 0 && Kilos >= 0) ? (Peso * 2) + Kilos : 0;
        }
    }
}
