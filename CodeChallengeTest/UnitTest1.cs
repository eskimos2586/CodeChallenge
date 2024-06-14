using System;
using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Data;
using CodeChallenge.Data.Model;
using NUnit.Framework;

namespace CodeChallengeTest
{
    public class Tests
    {
        private List<Animal> _animales;
        private ZoologicoServicio _zoologicoServicio;

        [SetUp]
        public void Setup()
        {
            _animales = new List<Animal>();
            _zoologicoServicio = new ZoologicoServicio();
        }

        [Test]
        public void CalcularAlimentoDiarioSinAnimales()
        {
            var result = _animales.Sum(a => a.CalcularAlimentoDiario());
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void CalcularAlimentoMensualSinAnimales()
        {
            var result = _animales.Sum(a => a.CalcularAlimentoMensual());
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void CalcularAlimentoDiarioSoloCarnivoros()
        {
            _animales.AddRange(MockFactoryCarnivoros());
            var result = _animales.Sum(a => a.CalcularAlimentoDiario());
            Assert.AreEqual(result, 22.5);
        }

        [Test]
        public void CalcularAlimentoMensualSoloCarnivoros()
        {
            _animales.AddRange(MockFactoryCarnivoros());
            var result = _animales.Sum(a => a.CalcularAlimentoMensual());
            var esperado = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) == 30 ? 675 : 697.5;
            Assert.AreEqual(result, esperado);
        }

        [Test]
        public void CalcularAlimentoDiarioSoloHerviboros()
        {
            _animales.AddRange(MockFactoryHerivboros());
            var result = _animales.Sum(a => a.CalcularAlimentoDiario());
            Assert.AreEqual(result, 185);
        }

        [Test]
        public void CalcularAlimentoMensualSoloHerviboros()
        {
            _animales.AddRange(MockFactoryHerivboros());
            var result = _animales.Sum(a => a.CalcularAlimentoMensual());
            var esperado = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) == 30 ? 5550 : 5735;
            Assert.AreEqual(result, esperado);
        }

        [Test]
        public void CalcularAlimentoDiarioSoloReptiles()
        {
            _animales.AddRange(MockFactoryReptiles());
            var result = _animales.Sum(a => a.CalcularAlimentoDiario());
            Assert.AreEqual(result, 8.1);
        }

        [Test]
        public void CalcularAlimentoMensualSoloReptiles()
        {
            _animales.AddRange(MockFactoryReptiles());
            var result = _animales.Sum(a => a.CalcularAlimentoMensual());
            Assert.AreEqual(result, 172);
        }

        [Test]
        public void CalcularAlimentoDiarioTodos()
        {
            _animales.AddRange(MockFactoryTodos());
            var result = _animales.Sum(a => a.CalcularAlimentoDiario());
            Assert.AreEqual(result, 215.6);
        }

        [Test]
        public void CalcularAlimentoMensualTodos()
        {
            _animales.AddRange(MockFactoryTodos());
            var result = _animales.Sum(a => a.CalcularAlimentoMensual());
            var esperado = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) == 30 ? 6397 : 6604.5;
            Assert.AreEqual(result, esperado);
        }

        [Test]
        public void AgregarNuevoAnimal()
        {
            var nuevoAnimal = new Carnivoro
            {
                Peso = 150,
                Porcentaje = 0.1M,
                FechaIngreso = DateTime.Today.AddMonths(-1)
            };

            _zoologicoServicio.AgregarAnimal(nuevoAnimal);

            var animales = _zoologicoServicio.ObtenerAnimales();
            Assert.AreEqual(1, animales.Count);
            Assert.AreEqual(nuevoAnimal, animales.FirstOrDefault());
        }

        [Test]
        public void VerificarLimiteAlimentoMensual()
        {
            // supera el límite de 1500 kg
            var animal1 = new Herbivoro
            {
                Peso = 1000,
                Kilos = 20,
                FechaIngreso = DateTime.Today.AddMonths(-1)
            };
            // no supera el límite de 1500 kg
            var animal2 = new Herbivoro
            {
                Peso = 10,
                Kilos = 5,
                FechaIngreso = DateTime.Today.AddMonths(-1)
            };

            var superaLimite1 = _zoologicoServicio.SuperaLimiteAlimentoMensual(animal1);
            var superaLimite2 = _zoologicoServicio.SuperaLimiteAlimentoMensual(animal2);

            Assert.IsTrue(superaLimite1);  // Supera el límite
            Assert.IsFalse(superaLimite2); // No supera el límite
        }

        [Test]
        public void CalcularConsumoMensualCarneYHierbas()
        {
            var animales = MockFactoryTodos();
            foreach (var animal in animales)
            {
                _zoologicoServicio.AgregarAnimal(animal);
            }

            var consumoCarne = _zoologicoServicio.CalcularConsumoMensualCarne();
            var consumoHierbas = _zoologicoServicio.CalcularConsumoMensualHierbas();

            var esperadoConsumoCarne = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) == 30 ? 761 : 783.5; 
            var esperadoConsumoHierbas = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) == 30 ? 5636 : 5821;

            Assert.AreEqual(esperadoConsumoCarne, consumoCarne);
            Assert.AreEqual(esperadoConsumoHierbas, consumoHierbas);
        }


        #region Mock Factory
        private List<Animal> MockFactoryCarnivoros()
        {
            return new List<Animal>() {
                new Carnivoro{
                    Peso = 100,
                    Porcentaje = 0.05M,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Carnivoro{
                    Peso = 80,
                    Porcentaje = 0.1M,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Carnivoro{
                    Peso = 95,
                    Porcentaje = 0.1M,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                }
            };
        }

        private List<Animal> MockFactoryHerivboros()
        {
            return new List<Animal>() {
                new Herbivoro{
                    Peso = 30,
                    Kilos = 10,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Herbivoro{
                    Peso = 50,
                    Kilos = 15,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                }
            };
        }

        private List<Animal> MockFactoryReptiles()
        {
            return new List<Animal>()
            {
                new Reptil{
                    Peso = 35,
                    Porcentaje = 0.5M,
                    DiasCambioPiel = 8,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Reptil{
                    Peso = 49,
                    Porcentaje = 0.8M, 
                    DiasCambioPiel = 5,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                }
            };
        }

        private List<Animal> MockFactoryTodos()
        {
            return new List<Animal>() {
                new Carnivoro{
                    Peso = 100,
                    Porcentaje = 0.05M,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Carnivoro{
                    Peso = 80,
                    Porcentaje = 0.1M,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Carnivoro{
                    Peso = 95,
                    Porcentaje = 0.1M,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Herbivoro{
                    Peso = 30,
                    Kilos = 10,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Herbivoro{
                    Peso = 50,
                    Kilos = 15,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Reptil{
                    Peso = 35,
                    Porcentaje = 0.5M,
                    DiasCambioPiel = 8,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                },
                new Reptil{
                    Peso = 49,
                    Porcentaje = 0.8M,
                    DiasCambioPiel = 5,
                    FechaIngreso = DateTime.Today.AddMonths(-1)
                }
            };
        }
        #endregion
    }
}