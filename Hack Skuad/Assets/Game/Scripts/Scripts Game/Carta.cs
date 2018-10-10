using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta: MonoBehaviour
{
    // Variable de tipo enum, que simula que tipo de carta se va a asignar
    [SerializeField]
    tipoCarta tipoDeCarta;

    // Inicialización de las variables de tipo enum
    // integer
    // string
    // double
    // bool
    // Con esto se busca hacer que cada carta tenga un tipo diferente
    private enum tipoCarta { Integer, String, Double, Bool }

}
