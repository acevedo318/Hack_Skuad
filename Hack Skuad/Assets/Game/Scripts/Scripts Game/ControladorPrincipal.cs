using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPrincipal : MonoBehaviour {

    [SerializeField]
    private GameObject panelInicioJuego;

    [SerializeField]
    private GameObject panelUbicacionAntivirus;

    [SerializeField]
    private ControladorCarta controladorCarta;

    [SerializeField]
    private PlayerAntivirus playerAntivirus;


    private bool esActivo;

    private int tiempo = 0;



    // Use this for initialization
    void Start ()
    {
        esActivo = true;
        ActivarPanel(panelInicioJuego);
        
    }
	
	// Update is called once per frame
	void Update ()
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

    void ActivarPanel(GameObject panel)
    {
        panel.SetActive(esActivo);
    }

    
    public IEnumerator Ubicar(int fila, int columna)
    {
        do
        {
            playerAntivirus.UbicarAntivirus(fila, columna);
            yield return new WaitForSeconds(0.001f);
        } while (!playerAntivirus.ubicacionCorrecta);
        playerAntivirus.InvocarDadosPosicionamiento();
    }
    
    internal void SetUbicar(int fila, int columna)
    {
        StartCoroutine(Ubicar(fila, columna));

    }
}
