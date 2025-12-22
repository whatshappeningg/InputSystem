# InputSystem
## Introducción  
La finalidad de este proyecto es utilizar y entender el funcionamiento de **Input Manager** en Unity. Para esto se le ha pedido a ChatGPT lo siguiente:  
> Genera un ejercicio para unity, que utilice el input system de este, ya sea con ratón o con teclado. Acabamos de hacer un cubo que se mueve con una cámara en tercera persona al hombro, hemos hecho una rotacion de la camara alrededor del player y movimiento con inputs. Credos ejercicios sencillos, nuevos y originales, que solo impliquen input system y movimiento mediante transform.

Como resultado se obtuvieron **5 ejercicios**. ([Link](https://chatgpt.com/share/694929f8-b468-8011-9acc-5a90ee50ba7a) a la conversación).  

## Ejercicios  
### Ejercicio 1 - El cubo nerviosos  
El cubo se mueve por el espacio de manera normal al pulsar las teclas de movimiento (``WASD`` o las flechas). Cuando ``Shift`` izquierdo se mantiene pulsado, el cubo incrementará su velocidad gradualemnte y empezará a oscilar de arriba a abajo. Cuando se deja de pulsar ``Shift`` vuelve a su comportamiento normal.  
### Ejercicio 2 - Orbitar o avanzar  
El cubo se mueve por el espacio de manera normal al pulsar las teclas de movimiento. Cuando la ``Q`` se mantiene pulsada el cubo quedará inmóvil, lo que se moverá será la cámara. Con las indicaciones de movimiento verticales la cámara se alejará o acercará del cubo y con las horizontales rotará en torno a él. Cuando se deja de pulsar ``Q`` se habilita de nuevo el movimiento del cubo, con la cámara estática.  
### Ejercicio 3 - El cubo teleoperado
El cubo se mueve por el espacio de manera normal al pulsar las teclas de movimiento, solo que, en vez de avanzar X unidades hacia la dirección indicada, solo avanzará 1 unidad cada vez que se indique una dirección de movimiento. La tecla ``R`` resetea la posición del cubo, devolviéndolo a su posición de origen.  
### Ejercico 4 - La cámara mandona  
El cubo se mueve por el espacio de manera normal al pulsar las teclas de movimiento. Tanto la cámara como el cubo enfocarán al ratón, girando suavemente para seguirlo y moviéndose en la dirección indicada.  
### Ejercicio 5 - Simón dice  
Se indicará una tecla de movimiento (``WASD``) a seguir. Si se pulsa la tecla correcta el cubo avanzará 1 unidad hacia esta dirección y se iluminará en verde por un instante. Si se pulsa la tecla incorrecta el cubo volverá a su posición de origen y se iluminará en rojo por un instante.  

## Funcionamiento  
Al iniciar el programa no habrá ningún ejercicio activado. Es preciso pulsar las teclas numéricas (``1`` - ``5``) para seleccionar el ejercicio. Se puede cambiar de ejercicio en cualquier momento, pero se recomienda tener en cuenta que las posiciones no se resetean al cambiar de ejercicio, es decir, si por ejemplo la cámara está en cierta posición y se pulsa otra tecla numérica, la cámara seguirá en esta posición, pudiendo afectar al funcionamiento del ejercicio.
