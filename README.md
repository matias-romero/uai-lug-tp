# uai-lug-tp
Este proyecto fue presentado para el final de la materia **T109 22 - LENGUAJES DE ÚLTIMA GENERACIÓN** de la carrera Ing. en Sistemas Informáticos de la Universidad Abierta Interamericana.

__Chinchón__

Para preparar el entorno de pruebas:
1) Ejecutar el ScriptCompleto.sql (por defecto creará una base llamada ChinchonSql)
Esto incluye dos usuarios de prueba:
User: Red		Password: 123
User: Blue		Password: 123

2) Debe configurar el archivo ChinchonWinForms.exe.config, editando la línea que dice 
connectionString="aqui va el connectionString de donde puso la base" (ej. connectionString="Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ChinchonSql; Integrated Security=SSPI")

3) Ejecutamos el programa principal ChinchonWinForms.exe, vamos al menú y elegimos "Partida -> Nueva... " (o bien Ctrl+N)
Nos preguntará el puntaje límite al que se jugará la partida y cargamos los jugadores que vayamos a usar.

Al tocar "Unirse..." pregunta si ya tiene credenciales (Login) o bien desea registrar uno nuevo (Registrar)

Por ejemplo podemos poner un límite a 10 para que sea más rapido y usamos los dos jugadores precargadas

Al poner al menos dos jugadores podremos comenzar

4) Una vez que comienza la partida veremos un tablero por cada jugador registrado. El fondo verde indica a quien es el que tiene el turno

5) En mi turno puedo:
Debo tomar una carta primero:
-Tomar carta desde el mazo (arrastrando desde el mazo a cualquiera en mi mano)
-Tomar carta desde el monton si hay alguna (arrastrando desde el montón a cualquiera en mi mano)

Una vez que tomé una carta puedo:
-Descartar una carta de mi mano al montón (arrastrando esa carta al montón)
-(Despues de jugar al menos un turno cada uno) Descartar una carta a la cruz roja que es el acto de cerrar

Durante todo mi turno puedo:
-Ordernar cartas en mi misma mano (arrastrando y soltando entre ellas)

6) Ronda de cierre / Presentar combinaciones
Una vez que algun jugador cierra la ronda se muestra una ventana por cada jugador indicando que quiere hacer con cada carta en mano
Las opciones disponibles son:
-Chinchon (escalera de 7 cartas)
-Escalera (mas de 3 consecutivas del mismo palo)
-Pie (3 o más del mismo número y diferente palo)

En caso de tener algún comodín tocando botón derecho sobre el mismo le puede asignar el valor que quiera.
Luego por cada combinación armada voy arrastrando las cartas desde la mano hacia la combinación y observo que el fondo se pone Rojo (Invalida) o Verde (Valida)

Una vez que tengo todas las combinaciones validas, hago click en "Confirmar" y con eso termino mi turno.

7) Una vez que todos los jugadores presentaron sus combinaciones se realiza el calculo de puntos y se determina al ganador.
En caso de que mas de uno no supere el límite impuesto por la partida, se seguirán jugando tantas rondas como sea necesario.

Nota: Para ver las estadísticas de cada jugador, puedo tocar el nombre del mismo al lado de cada mano en mi tablero
