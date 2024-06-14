# Desafío Tecnico

## Requerimientos

* La aplicación permite agregar nuevos animales y mostrar un mensaje exitoso. En caso de que se supere el límite mensual de 1500 Kg. se muestra un mensaje de error, y el animal no se agrega.
* La aplicación permite listar los animales y sus propiedades, como así también su consumo mensual discriminando carnes y hierbas.
* La aplicacíon permite ver el total de consumo mensual discriminando carnes y hierbas.

## Modelado de clases

Se optó por crear una estructura de clases utilizando la herencia, lo que permite definir clases hijas que implementen sus propios métodos (polimorfismo) para calcular la alimentación diaria y mensual. Esto también permite una separación de responsabilidades, ya que cada clase hija se encarga de su propio cálculo.

Este enfoque permite:

* Evitar la repetición: Todo el código compartido por las diferentes especies animales está en las clases "padre".
* Mantener el código flexible y extensible: Se pueden agregar otras especies animales sin afectar la implementación actual.
* Reutilizar el código: Los métodos comunes se definen una vez y se aplican en objetos de las clases derivadas.

## Vistas

Se tuvo que modificar la vista "Nuevo Animal" para poder usar el esquema de clases. Como la clase "Animal" es abstracta, se creó una clase "AnimalViewModel" para poder ser usada como modelo en la vista. Además se creó un método ObtenerAnimalPorTipo() que permite obtener el objeto concreto de acuerdo al tipo de animal seleccionado. Este método podría ser reemplazado por una fábrica de objetos concretos, pero considero que el desarrollo no es relevante para los fines del desafío.

## Tests Unitarios

Se corrigieron los tests existentes para que los calculos se realicen correctamente. Además se agregaron tests para probar el cálculo de alimentación de los reptiles y los requerimientos del desafío.

## Notas

* La aplicación asigna como fecha de ingreso la fecha actual, cada vez que se agrega un nuevo animal.
* El cálculo de consumo mensual tiene en cuenta la fecha de ingreso del animal, por lo tanto, si el animal ingresa el día 10 de un mes de 30 días sólo se cuentan los 20 días restantes.
* En el cálculo de alimentación, se asume que los reptiles consumen igual cantidad de carnes y hiervas.
* En el cálculo de alimentación, se asume que los reptiles acaban de terminar el período de cambio de piel; por lo tanto se alimentan desde el primer día del cálculo hasta el próximo cambio de piel (si aplica).
* Los test de consumo mensual se realizan "a mes completo", por eso la fecha de ingreso de los animales es de un mes hacia atrás. No se contempla si el mes en curso es Febrero (28 o 29 días).
