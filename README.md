# Alife 2018-01
#### Author: Manuel Embus

IEn este repositorio encontrará el proyecto final de la asignatura [Vida Artificial](http://dis.unal.edu.co/profesores/jgomezpe/courses/alife/index.html), dirigida por [Jonathan Gomez Perdomo](http://dis.unal.edu.co/~jgomezpe/) en la [Universidad Nacional de Colombia](http://unal.edu.co/).

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
* [**5 - Transformaciones Afines**](#Tr)
* [**6 - Movimiento de Boids**](#what-is-a-fractal)
* [**7 - Turing Morph**](#what-is-a-fractal)
* [**8 - Código Genético**](#what-is-a-fractal)
* [**9 - Evolución**](#what-is-a-fractal)



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

### Fractal dimension
Fractals in generall have non integer dimension, for example, using the Koch curve we could demostrate that:
* A line has only one dimension:

* A square has only two dimensions:
* A cube has only three dimensions:

## Code Description:
