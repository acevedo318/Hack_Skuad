using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta: MonoBehaviour
{
    // Variable de tipo enum, que simula que tipo de carta se va a asignar
    [SerializeField]
    tipoCarta tipoDeCarta;

	/// <sumary>
	/// Inicialización de las variables de tipo "enum"
	/// Integer
	/// String
	/// Double
	/// Bool
	/// para que cada carta tenga un tipo de variable diferente
	/// </sumary>
    private enum tipoCarta { Integer, String, Double, Bool }

}
