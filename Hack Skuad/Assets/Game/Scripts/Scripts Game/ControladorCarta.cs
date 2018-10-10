using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControladorCarta : MonoBehaviour
{

    // Arreglo(vector) que contiene el listado de las 40 cartas presentes en el juego
    [SerializeField]
    private GameObject[] listaCartas;

    // Variables de tipo ContenedorArray, para iniciar los 4 vectores que poseen todos los puntos de camino de cada carril de juego
    public ContenedorArray camino1;
    public ContenedorArray camino2;
    public ContenedorArray camino3;
    public ContenedorArray camino4;

    //Variable para definir la velocidad de movimiento de cada carta al momento de barajarse
    private float velocidadMovCarta = 2f;

    void Start()
    {
        MezclarCartas();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("MoverTodasCartas", 2);
    }

    // Método para barajar o mezclar todas las 40 cartas dentro del vector de cartas "listaCartas"
    public void MezclarCartas()
    {
        var cantidadCartas = listaCartas.Length; // Se toma la cantidad de cartas del vector en una variable.
        System.Random random = new System.Random();
        for (int i = 0; i < listaCartas.Length; i++)
        {
            var j = random.Next(0, i); // Se lanza un ramdon entre los valores 0 y el numero que tenga la variable i
            var temp = listaCartas[i]; // Se guarda en una variable temporal la carta en la posición i
            listaCartas[i] = listaCartas[j]; // En la posición i se le asigna la carta que contiene la posicion j generada
            listaCartas[j] = temp; // Y en la posición j generada se le asigna lo que estaba guardado en la variable temp
        }

    }

    // Método para movilizar todas las cartas a sus respectivas posiciones despues de haber realizado la mezcla en el vector "listaCartas"
    public void MoverTodasCartas()
    {       
        int Cont = 0;
        for (int i = 0; i < 10; i++)
        {
            // Cada carta se ordena en forma vertical en los 4 vectores que simulan los carriles de juego
            listaCartas[Cont].transform.position = Vector2.MoveTowards(listaCartas[Cont].transform.position, camino1.listaPuntosDeCamino[i].transform.position, (Time.deltaTime * velocidadMovCarta));
            Cont++;
            listaCartas[Cont].transform.position = Vector2.MoveTowards(listaCartas[Cont].transform.position, camino2.listaPuntosDeCamino[i].transform.position, (Time.deltaTime * velocidadMovCarta));
            Cont++;
            listaCartas[Cont].transform.position = Vector2.MoveTowards(listaCartas[Cont].transform.position, camino3.listaPuntosDeCamino[i].transform.position, (Time.deltaTime * velocidadMovCarta));
            Cont++;
            listaCartas[Cont].transform.position = Vector2.MoveTowards(listaCartas[Cont].transform.position, camino4.listaPuntosDeCamino[i].transform.position, (Time.deltaTime * velocidadMovCarta));
            Cont++;

        }
    }


}
