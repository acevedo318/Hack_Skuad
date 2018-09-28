using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dado {

    /// <summary>
    /// Dado para PlayerAntivirus
    /// </summary>
    [SerializeField]
    OpcionesAntivirus opcionesAntivirus;
    /// <summary>
    /// Dado para PlayerVirus
    /// </summary>
    [SerializeField]
    private byte virus = 0; //

	// Use this for initialization
	void Start () {
        
        Debug.Log("");
	}
	
    /// <summary>
    /// Solo los virus tiran dados
    /// </summary>
    public void TirarDados()
    {

    }

    /// <summary>
    /// opciones para Dado PlayerAntivirus
    /// </summary>
    private enum OpcionesAntivirus { Ninguno, Arriba, Abajo, Derecha, Izquierda }
    /*
    public opcionesAntivirus opcionesAntivirus
    {
        get { return this.opcionesAntivirus; }
        set { this.nombre = value; }
    }
    */

}
