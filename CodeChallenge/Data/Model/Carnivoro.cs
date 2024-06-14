namespace CodeChallenge.Data.Model
{
    public class Carnivoro : CarnivoroReptil
    {
        public override decimal CalcularAlimentoDiario()
        {
            return (Peso > 0 && Porcentaje > 0) ? Peso * Porcentaje : 0;
        }
    }
}
