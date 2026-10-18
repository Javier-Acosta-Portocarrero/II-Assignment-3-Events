
# Interfaces inteligentes - Práctica 4 - Eventos

Autor: Javier Acosta Portocarrero

En esta práctica he aprendido a utilizar el patrón observador en Unity mediante delegados y eventos, permitiendo que diferentes objetos reaccionen a determinadas acciones. También he trabajado con colisiones físicas, movimiento mediante Rigidbody, teletransporte, orientación de personajes y sistemas de puntuación e interfaz.

## Ejercicio 1

En este primer ejercicio creé una escena con cinco esferas, tres rojas de tipo 1 y dos verdes de tipo 2, además de un cubo y un cilindro. El objetivo era conseguir que, cuando el cubo colisionara con el cilindro, las esferas reaccionaran de manera diferente según su grupo.

Para implementarlo utilicé el patrón observador, haciendo que el cilindro lanzara un evento mediante `OnCollisionEnter` al que las esferas estaban suscritas. Las de tipo 1 se dirigen hacia una esfera verde seleccionada, mientras que las de tipo 2 se mueven hacia el cilindro. Para el movimiento utilicé la velocidad de los Rigidbody y Tags para identificar los diferentes objetos.

![Ejercicio 1](./gifs-readme/ejercicio1.gif)

## Ejercicio 2

En este ejercicio sustituí los objetos geométricos del ejercicio anterior por prefabs de humanoides, manteniendo el funcionamiento de los eventos y el movimiento de los diferentes grupos. También sustituí el cubo original por un prefab para representar al jugador.

Durante la configuración tuve algunos problemas con las físicas, ya que los personajes atravesaban el suelo o no se movían correctamente. Para solucionarlo, añadí los componentes Rigidbody y Collider al GameObject principal de los prefabs y ajusté los Colliders a sus dimensiones. También bloqueé las rotaciones de los ejes X y Z para evitar que los personajes volcaran al moverse.

Por último, creé materiales para aplicar las texturas a los personajes y mantuve las animaciones originales incluidas en los prefabs, que se reproducen desde el componente Animator.

![Ejercicio 2](./gifs-readme/ejercicio2.gif)

## Ejercicio 3

En este ejercicio amplié la escena anterior añadiendo dos tipos de escudos y nuevas mecánicas de movimiento para los humanoides. Para ello, utilicé dos eventos diferentes que se activan cuando el jugador colisiona con un humanoide de tipo 1 o de tipo 2.

Cuando colisiona con uno de tipo 2, los humanoides del grupo 1 se desplazan hacia un escudo seleccionado previamente mediante un Transform público. En cambio, cuando colisiona con uno de tipo 1, se dirigen hacia los escudos de tipo 2, seleccionando el más cercano mediante `Vector3.Distance`.

También implementé que los humanoides cambien de color al colisionar con un escudo de tipo 2. Para ello tuve que acceder a los Renderer de los objetos hijos de los prefabs, ya que sus Meshes no estaban directamente en el objeto principal.

![Ejercicio 3](./gifs-readme/ejercicio3.gif)

## Ejercicio 4

En este ejercicio implementé una mecánica que se activa cuando el jugador se aproxima a un objeto de referencia. Para ello, añadí un cilindro y utilicé `Vector3.Distance` para comprobar la distancia entre este y el jugador, lanzando un evento cuando se encuentra suficientemente cerca.

Al recibir el evento, los humanoides del grupo 1 se teletransportan hacia un escudo seleccionado previamente, mientras que los del grupo 2 se orientan hacia un segundo cilindro que añadí a la escena, utilizando el método `LookAt`.

Inicialmente, los tres humanoides aparecían en el mismo punto al teletransportarse, provocando que se superpusieran. Para solucionarlo, modifiqué el atributo `teleportOffset` desde el Inspector, asignando los valores -2, 0 y 2 al eje X de los diferentes personajes.

![Ejercicio 4](./gifs-readme/ejercicio4.gif)

## Ejercicio 5

En este ejercicio implementé un sistema de recolección de escudos que permite al jugador aumentar su puntuación. Los escudos de tipo 1 suman 5 puntos y los de tipo 2 suman 10 puntos.

Para ello, creé el script `FifthExerciseShieldCollector`, que utiliza `OnCollisionEnter` para detectar las colisiones y `CompareTag` para identificar el tipo de escudo. Cuando el jugador recoge uno, se incrementa la puntuación correspondiente, se muestra su valor actualizado por consola y se elimina el escudo de la escena mediante `Destroy`.

También añadí un método `GetScore` para poder consultar la puntuación desde otros scripts en los siguientes ejercicios.

![Ejercicio 5](./gifs-readme/ejercicio5.gif)

## Ejercicio 6

En este ejercicio añadí una interfaz que permite visualizar la puntuación del jugador directamente en pantalla, en lugar de mostrarla únicamente por consola.

Para ello, creé un Canvas con un componente Legacy Text y utilicé el script `SixthExerciseScoreUI` para actualizar su contenido. Este obtiene la puntuación almacenada en `FifthExerciseShieldCollector` mediante el método `GetScore`, mostrando el valor correspondiente en cada momento.

También configuré el Rect Transform para situar el texto en la esquina superior izquierda, utilizando los Anchors y una posición de (120, -40). Finalmente, establecí un tamaño de fuente de 25 y un color verde claro para que la puntuación destacara sobre el escenario.

![Ejercicio 6](./gifs-readme/ejercicio6.gif)

## Ejercicio 7

En este ejercicio amplié el sistema de puntuación anterior añadiendo una mecánica de recompensas, de manera que el jugador obtiene una nueva recompensa por cada 100 puntos conseguidos.

Para implementarlo, creé el script `SeventhExerciseRewardUI`, que accede al componente `FifthExerciseShieldCollector` del jugador mediante `GetComponent`. A partir de la puntuación obtenida, calculo el número de recompensas utilizando una división entera entre 100 y compruebo si se ha conseguido una nueva.

Además, añadí un segundo texto al Canvas para mostrar las recompensas acumuladas, manteniendo también el texto de puntuación del ejercicio anterior.

![Ejercicio 7](./gifs-readme/ejercicio8.gif)


\(perdí el vídeo de este ejercicio sin tener la escena del ejercicio 8)

## Ejercicio 8

En este ejercicio amplié la escena de los ejercicios anteriores para crear un entorno más completo y con una ambientación acorde al prototipo.

Para ello, añadí montañas y colinas alrededor de la zona de juego, además de aplicar diferentes texturas de césped y roca para mejorar el aspecto del escenario. También incorporé elementos decorativos de madera y distribuí los escudos por diferentes zonas.

En esta escena mantuve los prefabs de humanoides de los distintos grupos y reutilicé las mecánicas de recolección, puntuación y recompensas de los ejercicios anteriores. De esta manera conseguí integrar las funcionalidades desarrolladas en un escenario más elaborado.

![Ejercicio 8](./gifs-readme/ejercicio8.gif)

## Ejercicio 9

En este último ejercicio adapté la mecánica del ejercicio 3 para que el jugador se comportara como un objeto físico, en lugar de utilizar un Rigidbody cinemático.

Para ello, modifiqué la configuración del Rigidbody del prefab del jugador, desactivando `Is Kinematic` y activando la gravedad. También cambié el sistema de movimiento para utilizar `Rigidbody.linearVelocity` en lugar de `MovePosition`, conservando la velocidad vertical para permitir que la gravedad siguiera actuando.

Se reutilizaron los eventos y las colisiones del ejercicio 3, de forma que los humanoides siguen reaccionando dependiendo del grupo con el que colisiona el jugador y cambian de color al chocar contra los escudos físicos de tipo 2. También configuré las restricciones de rotación para evitar que el jugador volcara durante el movimiento.

![Ejercicio 9](./gifs-readme/ejercicio9.gif)