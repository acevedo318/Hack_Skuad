using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// La clase del jugador Antivirus
/// </summary>
public class PlayerAntivirus : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Dado dadoColumna, dadoFila;
    bool puedeTirarDado = true;

    // Variables de tipo ContenedorArray que simulan los caminos por donde se va a mover el player Antivirus
    public ContenedorArray camino1;
    public ContenedorArray camino2;
    public ContenedorArray camino3;
    public ContenedorArray camino4;

    // Velocidad de movimiento del player Antivirus
    private float velocidadMovimiento = 2f;

    // Variable booleana para validar que la ubicacion del player Antivirus, sea correcta en el mundo del juego
    public bool ubicacionCorrecta { get; set; }

    [SerializeField]
    private GameObject botonDado;

    List<GameObject> listaBotonDados;
    // Use this for initialization
    void Start()
    {
        ubicacionCorrecta = false; // Se inicializa la posición del Antivirus como false
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void TirarDado()
    {
        if (puedeTirarDado)
        {
            StartCoroutine(dadoFila.RodarDadoFila());

        }
    }


    // Método que realiza la ubicación inicial del player Antivirus, en cualquiera de los 4 carriles de juego
    // Pasándole como parametros los valores de la fila y la columna que deben ser arrojados por el dado
    public void UbicarAntivirus(int fila, int columna)
    {

        switch (fila)
        {
            case 0:

                this.transform.position = Vector2.MoveTowards(transform.position, camino1.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 0
                if (this.transform.position == camino1.listaPuntosDeCamino[columna].transform.position) // Se evalúa que la posición a la que se dirigío es correcta
                {

                    ubicacionCorrecta = true;

                }
                break;
            case 1:

                this.transform.position = Vector2.MoveTowards(transform.position, camino2.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 1

                if (this.transform.position == camino2.listaPuntosDeCamino[columna].transform.position)
                {

                    ubicacionCorrecta = true;

                }
                break;
            case 2:

                this.transform.position = Vector2.MoveTowards(transform.position, camino3.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 2
                if (this.transform.position == camino3.listaPuntosDeCamino[columna].transform.position)
                {

                    ubicacionCorrecta = true;

                }
                break;
            case 3:

                this.transform.position = Vector2.MoveTowards(transform.position, camino4.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 3
                if (this.transform.position == camino1.listaPuntosDeCamino[columna].transform.position)
                {

                    ubicacionCorrecta = true;

                }
                break;
        }

    }

    // Método que realiza la invocación de los dados al momento que el virus está en su posición correcta al momento de iniciar el juego
    public void InvocarDadosPosicionamiento()
    {
        Transform contenedorDados = GameObject.Find("ContenedorDadosAntivirus").GetComponent<Transform>();
        GameObject dadoDefaultAnti;
        listaBotonDados = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            dadoDefaultAnti = Instantiate(botonDado, contenedorDados);
            listaBotonDados.Add(dadoDefaultAnti);
        }
    }

    public enum opciones
    {
        Arriba, Abajo, Derecha, Izquierda
    }
    public void MoverVirus(opciones opcion1, opciones opcion2)
    {

    }
}
