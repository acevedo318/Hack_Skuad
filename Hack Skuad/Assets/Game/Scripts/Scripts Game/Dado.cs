using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dado : MonoBehaviour
{

    [SerializeField]
    private Sprite[] ladosDado;

    [SerializeField]
    private SpriteRenderer rend;

    [SerializeField]
    private Button botonUbicarVirus;

    int ladoDadoRandom;

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
    void Start()
    {
        rend.sprite = ladosDado[0];
    }


    public IEnumerator RodarDado()
    {
        ladoDadoRandom = 0;
        ladoDadoRandom = Random.Range(0, 9);
        rend.sprite = ladosDado[ladoDadoRandom];
        yield return new WaitForSeconds(0.05f);
    }
    /// <summary>
    /// Solo los virus tiran dados
    /// </summary>
    //public void TirarDados()
    //{
    //    StartCoroutine(RodarDado());
    //}

    /// <summary>
    /// opciones para Dado PlayerAntivirus    /// </summary>

    private enum OpcionesAntivirus { Ninguno, Arriba, Abajo, Derecha, Izquierda }
    /*
    public opcionesAntivirus opcionesAntivirus
    {
        get { return this.opcionesAntivirus; }
        set { this.nombre = value; }
    }
    */

}
