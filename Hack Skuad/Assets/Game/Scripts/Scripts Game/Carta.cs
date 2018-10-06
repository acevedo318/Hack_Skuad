using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{

    [SerializeField]
    tipoCarta tipoDeCarta;

    private Vector2 posicionCarta;

    private enum tipoCarta { Integer, String, Double, Bool }

    void Start()
    {
        posicionCarta = this.transform.position;
    }

}
