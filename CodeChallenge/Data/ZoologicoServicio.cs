using CodeChallenge.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Data
{
    public class ZoologicoServicio
    {
        private const decimal LIMITE_MENSUAL_ALIMENTO = 1500;

        private List<Animal> _animales;

        public ZoologicoServicio()
        {
            _animales = new List<Animal>();
        }

        public void AgregarAnimal(Animal animal)
        {
            _animales.Add(animal);
        }

        public bool SuperaLimiteAlimentoMensual(Animal animal)
        {
            return (animal.CalcularAlimentoMensual() + CalcularConsumoMensual()) > LIMITE_MENSUAL_ALIMENTO;
        }

        public decimal CalcularConsumoMensual()
        {
            return _animales.Sum(a => a.CalcularAlimentoMensual());
        }

        public decimal CalcularConsumoCarne(Animal animal)
        {
            if (animal is Carnivoro)
            {
                return animal.CalcularAlimentoMensual();
            }
            else if (animal is Reptil)
            {
                // Se asume que los reptiles consumen la mitad del total en carne
                return animal.CalcularAlimentoMensual() / 2;
            }
            else
            {
                return 0;
            }
        }

        public decimal CalcularConsumoHierbas(Animal animal)
        {
            if (animal is Herbivoro)
            {
                return animal.CalcularAlimentoMensual();
            }
            else if (animal is Reptil)
            {
                // Se asume que los reptiles consumen la mitad del total en hierbas
                return animal.CalcularAlimentoMensual() / 2;
            }
            else
            {
                return 0;
            }
        }

        public decimal CalcularConsumoMensualTotal()
        {
            return _animales.Sum(a => a.CalcularAlimentoMensual());
        }

        public decimal CalcularConsumoMensualCarne()
        {
            // Se asume que los reptiles consumen la mitad del total en carne
            return _animales.Sum(a => a is Carnivoro || a is Reptil ? a.CalcularAlimentoMensual() / (a is Reptil ? 2 : 1) : 0);
        }

        public decimal CalcularConsumoMensualHierbas()
        {
            // Se asume que los reptiles consumen la mitad del total en hierbas
            return _animales.Sum(a => a is Herbivoro || a is Reptil ? a.CalcularAlimentoMensual() / (a is Reptil ? 2 : 1) : 0);
        }

        public List<Animal> ObtenerAnimales()
        {
            return _animales;
        }

    }
}
