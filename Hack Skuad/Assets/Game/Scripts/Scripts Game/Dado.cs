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


    private ControladorPrincipal control;

    int resultadoModuloFila;
    public int ladoDadoRandomFila;
    public int ladoDadoRandomColumna;
    public AudioSource RodarDado;


    // Use this for initialization
    void Start()
    {
        rendFila.sprite = ladosDado[0]; // Se inicializa el render del dado fila con la posición 0 en el vector de sprites
        rendColumna.sprite = ladosDado[0]; // Se inicializa el render del dado columna con la posición 0 en el vector de sprites
        ladoDadoRandomFila = 0; // Se inicializa la variable en 0
        ladoDadoRandomColumna = 0; // Se inicializa la variable en 0
        control = GameObject.FindObjectOfType<ControladorPrincipal>().GetComponent<ControladorPrincipal>(); // Se llama al controlador principal con la funcion find y se obtiene su componente script
    }

    // Método para poner a rodar el dado que contiene el número que corresponde a la fila donde estará ubicado inicialmente el jugador antivirus
    public IEnumerator RodarDadoFila()
    {
        for (int i = 0; i < 10; i++) // For utilizado para que la animación de cambio de sprite se realice 10 veces
        {
            ladoDadoRandomFila = Random.Range(0, 4); // Se obtiene un randon en 0 y 4
            rendFila.sprite = ladosDado[ladoDadoRandomFila]; // Al vector sprite render se le asigna el número generado, para que muestre en pantalla esa imagen
            yield return new WaitForSeconds(0.1f); // Lo anterior debe ser realizado cada 0.1 segundos
            RodarDado.Play(); //Se reproduce el sonido del dado
        }
        setTextoFila(); // al terminar la animación se setea el texto de fila, con el valor generado aleatoriamente
        StartCoroutine(RodarDadoColumna()); // Y se da paso a la otra corutina del siguiente dado
        yield return new WaitForSeconds(3f); // Con una espera de 3 segundos
        panelUbicacionAntivirus.SetActive(false); // Al terminar de realizar las animaciones y los seteos de los valores en fila y columna, se desactiva el panel
        control.SetUbicar(ladoDadoRandomFila, ladoDadoRandomColumna); // Y los valores generados aleatoriamente se le envían a la función setUbicar de la clase ControladorPrincipal
    }

    // Método para poner a rodar el dado que contiene el número que corresponde a la columna donde estará ubicado inicialmente el jugador antivirus
    public IEnumerator RodarDadoColumna()
    {
        for (int i = 0; i < 10; i++)
        {
            ladoDadoRandomColumna = Random.Range(0, 9);
            rendColumna.sprite = ladosDado[ladoDadoRandomColumna];
            yield return new WaitForSeconds(0.1f);
            RodarDado.Play();
        }
        setTextoColumna();
    }

    // Método el cual setea el texto de la fila, y le asigna el valor arrojado por el dado fila
    public void setTextoFila()
    {
        textoUbicacionFila.text = "Fila: " + (ladoDadoRandomFila+1);
    }

    // Método el cual setea el texto de la columna, y le asigna el valor arrojado por el dado columna
    public void setTextoColumna()
    {
        textoUbicacionColumna.text = "Columna: " + (ladoDadoRandomColumna+1);
    }

    
}

