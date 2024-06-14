using CodeChallenge.Data.Enums;

namespace CodeChallenge.Data.ViewModel
{
    public class AnimalViewModel
    {
        public TipoAnimal? Tipo { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string LugarOrigen { get; set; }
        public decimal Peso { get; set; }
        public int DiasCambioPiel { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Kilos { get; set; }
    }
}
