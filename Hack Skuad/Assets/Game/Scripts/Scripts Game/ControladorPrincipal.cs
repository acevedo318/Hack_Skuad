﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorPrincipal : MonoBehaviour
{

    //Variable de tipo GameObject para poder inicializar el panel de inicio de juego
    [SerializeField]
    private GameObject panelInicioJuego;

    //Variable de tipo GameObject para poder inicializar el panel de ubicación de jugador antivirus
    [SerializeField]
    private GameObject panelUbicacionAntivirus;

    [SerializeField]
    private GameObject panelJugadaAntivirus, panelJugadaVirus;


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
    Player jugadorActual;

    [SerializeField]
    List<Player> listaJugadores, listaTemporalJugadores;


    [SerializeField]
    List<Player> agregadasTemporales, noAgregadasTemporales;

    [SerializeField]
    List<Player> jugadas;

    [SerializeField]
    GameObject[] textosDeTurnos;

    private bool verificarPrimerTurno { get; set; }

    private GameObject textoActivo;

    bool listaLlena = false;

    int ronda = 8, tiempoProgramacion = 0;

    [SerializeField]
    TextMeshProUGUI textoRonda, textopuntajeGlobal, textoReloj;

    List<Vector3> posicionesIniciales;

    [SerializeField]//@acevedo
    GameObject cartas;


    public List<GameObject> ListaDecartas;

    [SerializeField]
    int puntajeGlobal = 0;

    public bool terminarJugada = false;

    int reloj = 0;

    Coroutine coroutine;

    [SerializeField]
    TextMeshProUGUI textoVictoriaVirus, textoVictoriaAntivirus;

    

    // Use this for initialization
    void Start()
    {
        esActivo = true;
        verificarPrimerTurno = false;
        ActivarPanel(panelInicioJuego);
        TurnoJugadores();
        listaTemporalJugadores = new List<Player>();
        textoRonda.text += ronda;
        this.textopuntajeGlobal = GameObject.Find("PuntajeGlobal").GetComponent<TextMeshProUGUI>();
        ResetearJugadores();
        AgregarTipoCarta();
        ActualizarPuntaje();
        coroutine = StartCoroutine(ActivarReloj());
        StopCoroutine(coroutine);

    }

    public void ActualizarPuntaje()
    {
        this.textopuntajeGlobal.text = "Puntaje Global: " + this.puntajeGlobal;
    }

    /// <summary>
    /// 
    /// </summary>
    void AgregarTipoCarta()
    {
        this.ListaDecartas = new List<GameObject>();

        foreach (Transform hijo in this.cartas.transform)
        {

            ListaDecartas.Add(hijo.gameObject);

        }

    }

    bool[] vectorComprobacionDados = new bool[3];
    //Añado 2
    public void SumarPuntaje()
    {
        puntajeGlobal += 4;
        ActualizarPuntaje();
        if (puntajeGlobal > 64 && vectorComprobacionDados[0]==false) {
            playerAntivirus.AgregarDadosAdicionales();
            vectorComprobacionDados[0] = true;
        }else if (puntajeGlobal > 79 && vectorComprobacionDados[1] == false)
        {
            playerAntivirus.AgregarDadosAdicionales();
            vectorComprobacionDados[1] = true;
        }else if (puntajeGlobal > 89 && vectorComprobacionDados[2] == false)
        {
            playerAntivirus.AgregarDadosAdicionales();
            vectorComprobacionDados[2] = true;
        }
        if (puntajeGlobal > 99)
        {
            FinDeJuego();
        }
    }

    //Retiro 2
    public void QuitarPuntaje()
    {
        puntajeGlobal -= 2;
        ActualizarPuntaje();
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
        yield return new WaitForSeconds(0.5f);
        textosDeTurnos[0].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        textoActivo = textosDeTurnos[0];
        Jugada();
        
    }

    // Método que se realiza para invocar la corutina de ubicar al antivirus en una determinada fila y columna
    internal void SetUbicar(int fila, int columna)
    {
        StartCoroutine(Ubicar(fila, columna));

    }

    public void TurnoJugadores()
    {
        int posicionInicial = 0;
        int posicionFinal = listaJugadores.Count - 1;
        jugadas = new List<Player>();
        noAgregadasTemporales = new List<Player>();
        agregadasTemporales = new List<Player>();

        for (int k = 0; k < 8; k++)
        {
            if (k == 4)
            {
                posicionInicial = 0;
            }
            noAgregadasTemporales = new List<Player>();
            agregadasTemporales = new List<Player>();
            for (int j = posicionInicial; j < posicionFinal; j++)
            {
                agregadasTemporales.Add(listaJugadores[j]);
                agregadasTemporales.Add(listaJugadores[listaJugadores.Count - 1]);
            }

            for (int i = 0; i < posicionInicial; i++)
            {

                noAgregadasTemporales.Add(listaJugadores[i]);
                noAgregadasTemporales.Add(listaJugadores[listaJugadores.Count - 1]);
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
    }

    public void ObtenerJugador()
    {
        if (listaJugadores.Count != 0) {
            jugadorActual = listaJugadores[0];
            listaJugadores.Remove(jugadorActual);
            listaTemporalJugadores.Add(jugadorActual);
        }
        
    }

    public void ObtenerJugada()
    {
        jugadorActual = jugadas[0];
        jugadas.Remove(jugadorActual);
    }

    public void GuardarDatos()
     {
        if (jugadorActual.GetComponent<PlayerVirus>() != null)
        {
            jugadorActual.GetComponent<PlayerVirus>().GuardarJugada();

        }

        else if (jugadorActual.GetComponent<PlayerAntivirus>() != null)
        {
            
         jugadorActual.GetComponent<PlayerAntivirus>().EjecutarGuardar();

        }
    }

    public void RealizarJugada()
    {
        panelJugadaAntivirus.SetActive(false);
        textoActivo.SetActive(false);
        textoActivo = textosDeTurnos[6];
        textoActivo.SetActive(true);
        ObtenerJugada();
        if (jugadorActual.GetComponent<PlayerVirus>() != null)
        {
            jugadorActual.GetComponent<PlayerVirus>().Ubicar();

        }
        else
        {
            jugadorActual.GetComponent<PlayerAntivirus>().EjecutarJugada();
        }
    }

    public void Jugada()
    {
        textoActivo.SetActive(false);
        ObtenerJugador();
        if (jugadorActual.GetComponent<PlayerVirus>() != null)
        {
            panelJugadaVirus.SetActive(true);
            panelJugadaAntivirus.SetActive(false);

        }
        else
        {
            panelJugadaVirus.SetActive(false);
            panelJugadaAntivirus.SetActive(true);


        }
        StopCoroutine(coroutine);
        this.coroutine = StartCoroutine(ActivarReloj());

        switch (jugadorActual.gameObject.name)
        {
            case "JugadorInteger":
                textoActivo = textosDeTurnos[1];
                textoActivo.SetActive(true);
                break;
            case "JugadorString":
                textoActivo = textosDeTurnos[2];
                textoActivo.SetActive(true);
                break;
            case "JugadorBoolean":
                textoActivo = textosDeTurnos[3];
                textoActivo.SetActive(true);
                break;
            case "JugadorDouble":
                textoActivo = textosDeTurnos[4];
                textoActivo.SetActive(true);
                break;
            case "JugadorAntivirus":
                textoActivo = textosDeTurnos[5];
                textoActivo.SetActive(true);
                break;
        }
        if (listaLlena)
        {
            foreach (var item in listaTemporalJugadores)
            {
                listaJugadores.Add(item);
            }
            listaTemporalJugadores.Clear();
            StartCoroutine(EsperaDeJugada());
            listaLlena = false;
        }
        if (listaJugadores.Count == 0)
        {
            listaLlena = true;
                   
        }
        
        
    }

    
    public IEnumerator EsperaDeJugada()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < 8; i++)
        {
            RealizarJugada();           
            yield return new WaitForSeconds(8.6f);
        }
        
        

        textoActivo.SetActive(false);
        yield return new WaitForSeconds(1f);

        if (this.ronda <  1)
        {
            FinDeJuego();
        }

        ronda--;
        textoActivo = textosDeTurnos[0];
        textoActivo.SetActive(true);
        yield return new WaitForSeconds(3f);
        ResetearJugadores();
        
        textoRonda.text = textoRonda.text.Substring(0, textoRonda.text.Length - 2)+ronda;
        Jugada();
    }

    
    public void ResetearJugadores()
    {
        if (!verificarPrimerTurno)
        {
            posicionesIniciales = new List<Vector3>();
            foreach (var item in listaJugadores)
            {
                posicionesIniciales.Add(item.transform.position);

                
            }
            verificarPrimerTurno = true;
        }
        else
        {
            for (int i = 0; i < listaJugadores.Count-1; i++)
            {
                listaJugadores[i].transform.position = posicionesIniciales[i];
            }
        }
        
    }

    public IEnumerator ActivarReloj()
    {
        reloj = 150;
        while (true)
        {
            textoReloj.text = ((int)(reloj / 60)).ToString("00") + ":" + ((int)(reloj % 60)).ToString("00");
            reloj--;
            if (reloj < 1)
            {
                //llamar a funcion
            }
            yield return new WaitForSeconds(1f);
        }

    }

    public Transform[] ObtenerVirus()
    {
        Transform[] transformsVirus = new Transform[listaJugadores.Count-1];

        for (int i = 0; i < listaJugadores.Count-1; i++)
        {
            transformsVirus[i] = listaJugadores[i].transform;
        }

        return transformsVirus;
    }

    public Transform ObtenerAntivirus()
    {
        return listaJugadores[listaJugadores.Count-1].transform;
    }

    public void FinDeJuego()
    {
        StopAllCoroutines();
        cartas.SetActive(false);
        textoActivo.SetActive(false);
        if (ronda < 1)
        {
            
            textoVictoriaAntivirus.gameObject.SetActive(true);
            
        }
        else
        {
            textoVictoriaVirus.gameObject.SetActive(true);
            
        }
    }

}
