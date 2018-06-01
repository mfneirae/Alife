# Alife 2018-01
#### Author: Manuel Embus

[![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/youtube.PNG?alt=media&token=7a9106ae-4615-4708-b8f7-e93efc6e61b1)](https://www.youtube.com/watch?v=eit-tyV-eZc)

En este repositorio encontrará el proyecto final de la asignatura [Vida Artificial](http://dis.unal.edu.co/profesores/jgomezpe/courses/alife/index.html), dirigida por [Jonathan Gomez Perdomo](http://dis.unal.edu.co/~jgomezpe/) en la [Universidad Nacional de Colombia](http://unal.edu.co/).

**INFORMACIÓN IMPORTANTE:**

Para utilizar este repositorio es necesario tener instalado [Unity](https://unity3d.com/es) en su equipo, para ello ejecute el siguiente comando en linux:
```
sudo apt install ubuntu-unity-desktop
```

## Tabla de contenido
* [**1 - Lindenmayer Systems**](#lindenmayer-systems)
* [**2 - Predador**](#predador)
* [**3 - Presa**](#presa)
* [**4 - Comida**](#comida)
* [**5 - Transformaciones Afines**](#transformaciones-afines)
* [**6 - Comportamiento de Boids**](#comportamiento-de-boids)
* [**7 - Turing Morph**](#turing-morph)
* [**8 - Código Genético y Reproducción**](#código-genético-y-reproducción)



### Lindenmayer Systems
Como base para elaborar el código que genera los árboles en el proyecto se utilizó el documento: ["*The Algorithmic Beauty of Plants*"](http://algorithmicbotany.org/papers/abop/abop.pdf), se generó código capás de reconocer reglas de tipo:
```
F = F-F+F+FF-F-F+X
```
Además, se generó el código para graficar figuras de tipo *phillotaxis* con el modelo planar utilizando ángulos de 137.5°. Los resultados se muestran a continuación:

![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/Phylo.PNG?alt=media&token=fa53d15c-d383-4a57-96f3-6b3a9b9dd13c)

### Predador
Se creó un depredador cuya especie se denominaron: los Osun, debido al nombre del orisha [Osun](https://cubayoruba.blogspot.com/2007/01/osun.html) de la religión Yoruba, como dato curioso:

```
Durante los ritos de santería la figura de Osun,
deidad del panteón Yoruba, debe cologarse encima
de un ropero, o donde no corra peligro de caer o
volcarse. Si a pesar de todas las precausiones
Osun se cae, hay inmintente peligro de muerte
rondando a su dueño.
```

![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/osun.PNG?alt=media&token=5911b36b-57f3-4ee0-a726-56c3a88a5399)

### Presa
Como presas, se creó la especie de los Oko, debido al nombre del orisha [Oke](https://cubayoruba.blogspot.com/2007/01/oke.html) de la religión Yoruba, como dato curioso:

```
Oko es la deidad de la agricultura en la cultura
Yoruba, simboliza la fertilidad, la  firmeza de
la madre tierra, la curación y los misterios del
Olofin.
```
![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/Oka.PNG?alt=media&token=38387e06-04d8-401b-a23c-ecba670139be)

### Comida
La comida se distribuye al rededor de los L-systems por estaciones, lo que implica que no todos los árboles generan comida en un mismo periodo de tiempo, lo que genera comportamientos emergentes como migracione.

![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/food.PNG?alt=media&token=d499685f-54b2-44e6-a29e-529d66c615b5)

### Transformaciones Afines
Se utilizaron transformaciones no lineales tipo ojo de pescado, cuyos parámetros son, para la primera generación, seleccionados de forma aleatoria, y luego, a través de un promedio entre las características de los padres.

![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/Transform.PNG?alt=media&token=f7b3b518-6834-455b-b4ea-61659899c646)

### Comportamiento de boids
Las [reglas](https://www.red3d.com/cwr/boids/) usadas para el comportamiento de boids corresponden a:

* No estar demasiado cerca a otro Oka.
* Moverse en direcciones similares promediadas a las de los Oka que lo rodean.
* Alinearse con los Oka que lo rodean.
* Si sus niveles de hambre llegan a un 50% debe dirigirse a la comida más cercana sin importar si sale del enjambre.
* Si un depredador se acerca a su rango de visión debe huír, siempre y cuando su nivel de hambre no llegue a niveles críticos, en este caso se dirigirá directo a la comida más cercana sin importar si se acerca al depredador.
* Si tiene niveles de comida suficientes debe buscar a la pareja que más se asemeje a si mismo para reproducirse.

![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/boid.PNG?alt=media&token=b15a551c-5d78-461a-a0a1-c95ac5eacf00)
## Turing Morph
El modelo utilizado en el proyecto se centró en lo planteado en [Turing Patterns](http://www.degeneratestate.org/posts/2017/May/05/turing-patterns/), por lo que se usó reacción difusión para generar las pieles de cada uno de los individuos en cada generación.

![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/Turing.PNG?alt=media&token=aa106cf0-d2c4-4f01-bf13-a1188e57877f)

## Código Genético y Reproducción
Cada individuo cuenta con un código genético de cuarenta carateres distribuidos de la siguiente forma:

![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/gen.PNG?alt=media&token=d02b208f-dfe0-4ef5-bda6-2ef462c4f837)

La pareja con la cual se reproducirá dependerá de que cumpla con una semejanza de por lo menos el 60%. Por cara pareja de padres, se crea una pareja de hijos a través del [crossover](https://la.mathworks.com/help/gads/how-the-genetic-algorithm-works.html), luego quedan inhabilitados para reproducirse nuevamente, sin embargo, según su vida máxima y metabolismo podrán perdurar durante una o más generaciones.

![alt text](https://firebasestorage.googleapis.com/v0/b/personalwp-8822c.appspot.com/o/Reproduction.PNG?alt=media&token=26790f77-9397-43ef-943d-18b7edb964f1)
