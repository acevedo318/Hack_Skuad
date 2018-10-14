using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dado : MonoBehaviour
{

    [SerializeField]
    private Sprite[] ladosDado;

    [SerializeField]
    private SpriteRenderer rendFila;

    [SerializeField]
    private SpriteRenderer rendColumna;

    [SerializeField]
    private TextMeshProUGUI textoUbicacionColumna;

    [SerializeField]
    private TextMeshProUGUI textoUbicacionFila;

    [SerializeField]
    private GameObject panelUbicacionAntivirus;

    private PlayerAntivirus antivirus;

    private ControladorPrincipal control;

    int resultadoModuloFila;
    public int ladoDadoRandomFila;
    public int ladoDadoRandomColumna;


    // Use this for initialization
    void Start()
    {
        rendFila.sprite = ladosDado[0];
        rendColumna.sprite = ladosDado[0];
        ladoDadoRandomFila = 0;
        ladoDadoRandomColumna = 0;
        antivirus = GameObject.FindObjectOfType<PlayerAntivirus>().GetComponent<PlayerAntivirus>();
        control = GameObject.FindObjectOfType<ControladorPrincipal>().GetComponent<ControladorPrincipal>();
    }

    public IEnumerator RodarDadoFila()
    {
        for (int i = 0; i < 10; i++)
        {
            ladoDadoRandomFila = Random.Range(0, 4);
            rendFila.sprite = ladosDado[ladoDadoRandomFila];
            yield return new WaitForSeconds(0.1f);
        }
        setTextoFila();
        StartCoroutine(RodarDadoColumna());
        yield return new WaitForSeconds(3f);
        panelUbicacionAntivirus.SetActive(false);
        control.SetUbicar(ladoDadoRandomFila, ladoDadoRandomColumna);   
    }

    public IEnumerator RodarDadoColumna()
    {
        for (int i = 0; i < 10; i++)
        {
            ladoDadoRandomColumna = Random.Range(0, 9);
            rendColumna.sprite = ladosDado[ladoDadoRandomColumna];
            yield return new WaitForSeconds(0.1f);
        }
        setTextoColumna();
    }

    public void setTextoFila()
    {
        textoUbicacionFila.text = "Fila: " + (ladoDadoRandomFila+1);
    }

    public void setTextoColumna()
    {
        textoUbicacionColumna.text = "Columna: " + (ladoDadoRandomColumna+1);
    }

    
}

