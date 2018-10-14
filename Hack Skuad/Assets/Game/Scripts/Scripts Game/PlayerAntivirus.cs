using UnityEngine;
using System.Collections;

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

    // Variable de tipo SpriteRenderer para poder cambiar los colores del sprite del jugador Antivirus
    private SpriteRenderer spriteRendererAntiV;

    // Variables de tipo color, para la creación de 2 colores, 1 con transparencia total y otro normal
    private Color colorTransparente;
    private Color colorNormal;

    // Use this for initialization
    void Start()
    {
        spriteRendererAntiV = this.GetComponent<SpriteRenderer>(); // Se obtiene el componente Spriterenderer del player Antivirus
        colorTransparente = new Color(255, 255, 255, 0); // Se crea el color transparente
        colorNormal = new Color(255, 255, 255); // Se crea el color normal
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
}
