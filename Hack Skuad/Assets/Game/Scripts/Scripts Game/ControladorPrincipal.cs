using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPrincipal : MonoBehaviour
{

    //Variable de tipo GameObject para poder inicializar el panel de inicio de juego
    [SerializeField]
    private GameObject panelInicioJuego;

    //Variable de tipo GameObject para poder inicializar el panel de ubicación de jugador antivirus
    [SerializeField]
    private GameObject panelUbicacionAntivirus;

    //Variable de tipo script ControladorCarta para poder inicializar el controlador y así poder utilizar sus métodos internos
    [SerializeField]
    private ControladorCarta controladorCarta;

    //Variable de tipo script PlayerAntivirus para poder inicializar el script asociado al jugador antivirus
    [SerializeField]
    private PlayerAntivirus playerAntivirus;

    // Variable de tipo bool para reconocer si un panel está activo o no
    private bool esActivo;

    // Variable inicial de tiempo transcurrido
    private int tiempo = 0;


    [SerializeField]
    Player[] listaJugadores;

    [SerializeField]
    List<Player> agregadasTemporales, noAgregadasTemporales;

    [SerializeField]
    List<Player> jugadas;

    // Use this for initialization
    void Start()
    {
        esActivo = true;
        ActivarPanel(panelInicioJuego);
        TurnoJugadores();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0).Equals(true))
        {
            esActivo = false;
            ActivarPanel(panelInicioJuego);

        }

        if (panelInicioJuego.activeSelf == false)
        {
            controladorCarta.MoverTodasCartas();
            tiempo++;
            if (tiempo == 220)
            {
                esActivo = true;
                ActivarPanel(panelUbicacionAntivirus);
            }
        }

        if (panelUbicacionAntivirus == false)
        {

        }

    }

    // Método al cual se le envía un parametro de tipo gameobject para así poder activarlo
    void ActivarPanel(GameObject panel)
    {
        panel.SetActive(esActivo);
    }

    // Método que ubica al jugador antivirus en su respectiva fila y columna, a este método se le pasan 2 parametros,
    // El valor de la fila y la columna, y luego procede a llevar al antivirus hasta la posición indicada´.
    public IEnumerator Ubicar(int fila, int columna)
    {
        do
        {
            playerAntivirus.UbicarAntivirus(fila, columna); // Invoca al método UbicarAntivirus de la clase playerAntivirus
            yield return new WaitForSeconds(0.0001f); // Este método se realiza cada cierto tiempo
        } while (!playerAntivirus.ubicacionCorrecta); // El método se realizará hasta que la variable ubicacionCorrecta de la clase antivirus sea "true"
        playerAntivirus.InvocarDadosPosicionamiento(); // Y al final, cuando el antivirus esté ubicado correctamente, se procede a invocar sus dados      
    }

    // Método que se realiza para invocar la corutina de ubicar al antivirus en una determinada fila y columna
    internal void SetUbicar(int fila, int columna)
    {
        StartCoroutine(Ubicar(fila, columna));
    }

    public IEnumerator EjecutarJugadaAntivirus()
    {
        int i = 0;
        int opcion = 0;
        do
        {
            yield return new WaitForSeconds(2f);
            Debug.Log(playerAntivirus.tomarMovimientos()[i]);
            opcion = playerAntivirus.tomarMovimientos()[i];
            playerAntivirus.MoverVirus(opcion);
            i++;
            playerAntivirus.ubicacionCorrecta2 = false;
        } while (i != playerAntivirus.tomarMovimientos().Count);    
    }

    public void Ejecutar() {
        StartCoroutine(EjecutarJugadaAntivirus());
    }

    public void TurnoJugadores()
    {
        int posicionInicial = 0;
        int posicionFinal = listaJugadores.Length-1;
        jugadas = new List<Player>();
        noAgregadasTemporales = new List<Player>();
        agregadasTemporales = new List<Player>();

        for (int k = 0; k < 8; k++)
        {
            if (k == 4)
            {
                posicionInicial = 0;
            }
            print("Turno: " +k);
            noAgregadasTemporales = new List<Player>();
            agregadasTemporales = new List<Player>();
            for (int j = posicionInicial; j < posicionFinal; j++)
            {
                agregadasTemporales.Add(listaJugadores[j]);
                agregadasTemporales.Add(listaJugadores[listaJugadores.Length - 1]);
            }

            for (int i = 0; i < posicionInicial; i++)
            {

                noAgregadasTemporales.Add(listaJugadores[i]);
                noAgregadasTemporales.Add(listaJugadores[listaJugadores.Length - 1]);
            }

            foreach (var item in agregadasTemporales)
            {
                jugadas.Add(item);
            }

            foreach (var item in noAgregadasTemporales)
            {
                jugadas.Add(item);
            }

            posicionInicial++;
        }

        foreach (var item in jugadas)
        {
            print(item.gameObject.name);
        }
        

    }



}
