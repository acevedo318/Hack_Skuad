using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControladorCarta : MonoBehaviour
{


    [SerializeField]
    private Transform[] listaCartas;

    public ContenedorArray camino1;
    public ContenedorArray camino2;
    public ContenedorArray camino3;
    public ContenedorArray camino4;

    Carta carta;

    private float moveSpeed = 2f;


    void Start()
    {
        MezclarCartas();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MezclarCartas()
    {
        var cantidadCartas = listaCartas.Length;
        System.Random random = new System.Random();
        for (int i = 0; i < listaCartas.Length; i++)
        {
            var j = random.Next(0, i);
            var temp = listaCartas[i];
            listaCartas[i] = listaCartas[j];
            listaCartas[j] = temp;
        }
    }

    public void MoverCartas()
    {
        System.Random rd = new System.Random();
        for (int i = 0; i < listaCartas.Length; i++)
        {
            int randomCamino = rd.Next(0, 3);
            int randomPuntoCamino = rd.Next(0, 9);
            switch (randomCamino)
            {
                case 0:
                    listaCartas[i].transform.position = Vector2.MoveTowards(carta.transform.position, camino1.listaPuntosDeCamino[randomPuntoCamino].transform.position, Time.deltaTime * moveSpeed);
                    break;

                case 1:
                    listaCartas[i].transform.position = Vector2.MoveTowards(carta.transform.position, camino2.listaPuntosDeCamino[randomPuntoCamino].transform.position, Time.deltaTime * moveSpeed);
                    break;

                case 2:
                    listaCartas[i].transform.position = Vector2.MoveTowards(carta.transform.position, camino3.listaPuntosDeCamino[randomPuntoCamino].transform.position, Time.deltaTime * moveSpeed);
                    break;

                case 3:
                    listaCartas[i].transform.position = Vector2.MoveTowards(carta.transform.position, camino4.listaPuntosDeCamino[randomPuntoCamino].transform.position, Time.deltaTime * moveSpeed);
                    break;

            }
        }
    }


}
