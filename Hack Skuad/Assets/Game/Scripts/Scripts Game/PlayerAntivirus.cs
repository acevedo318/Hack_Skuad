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
    private Dado dado;
    bool puedeTirarDado = true;

    // Variables de tipo ContenedorArray que simulan los caminos por donde se va a mover el player Antivirus
    public ContenedorArray camino1;
    public ContenedorArray camino2;
    public ContenedorArray camino3;
    public ContenedorArray camino4;

    // Velocidad de movimiento del player Antivirus
    private float velocidadMovimiento = 2f;

    // Variable booleana para validar que la ubicacion del player Antivirus, sea correcta en el mundo del juego
    private bool ubicacionCorrecta;

    // Variable de tipo SpriteRenderer para poder cambiar los colores del sprite del jugador Antivirus
    private SpriteRenderer spriteRendererAntiV;

    // Variables de tipo color, para la creación de 2 colores, 1 con transparencia total y otro normal
    private Color colorTransparente;
    private Color colorNormal;

    // Use this for initialization
    void Start ()
	{
        spriteRendererAntiV = this.GetComponent<SpriteRenderer>(); // Se obtiene el componente Spriterenderer del player Antivirus
        colorTransparente = new Color(255, 255, 255, 0); // Se crea el color transparente
        colorNormal = new Color(255, 255, 255); // Se crea el color normal
        ubicacionCorrecta = false; // Se inicializa la posición del Antivirus como false

	}
	
	// Update is called once per frame
	void Update ()
	{
        //if (ubicacionCorrecta==false) {
        //    UbicarAntivirus();
        //}
        
	}

    public void TirarDado()
    {
        if (puedeTirarDado)
        {
            StartCoroutine(dado.RodarDado());
        }
    }

    // Método que realiza la ubicación inicial del player Antivirus, en cualquiera de los 4 carriles de juego
    // Pasándole como parametros los valores de la fila y la columna que deben ser arrojados por el dado
    public void UbicarAntivirus(int fila, int columna)
    {
        switch (fila)
        {
            case 0:
                spriteRendererAntiV.color = colorTransparente; // El color del sprite se vuelve transparente al iniciar el movimiento
                this.transform.position = Vector2.MoveTowards(transform.position, camino1.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 0
                if (this.transform.position == camino1.listaPuntosDeCamino[columna].transform.position) // Se evalúa que la posición a la que se dirigío es correcta
                {
                    spriteRendererAntiV.color = colorNormal; // Se le asigna de nuevo el color normal, para que se vea la imagen del player Antivirus
                    ubicacionCorrecta = true;
                }
                break;
            case 1:
                spriteRendererAntiV.color = colorTransparente;
                this.transform.position = Vector2.MoveTowards(transform.position, camino2.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 1
                if (this.transform.position == camino2.listaPuntosDeCamino[columna].transform.position)
                {
                    spriteRendererAntiV.color = colorNormal;
                    ubicacionCorrecta = true;
                }
                break;
            case 2:
                spriteRendererAntiV.color = colorTransparente;
                this.transform.position = Vector2.MoveTowards(transform.position, camino3.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 2
                if (this.transform.position == camino3.listaPuntosDeCamino[columna].transform.position)
                {
                    spriteRendererAntiV.color = colorNormal;
                    ubicacionCorrecta = true;
                }
                break;
            case 3:
                spriteRendererAntiV.color = colorTransparente;
                this.transform.position = Vector2.MoveTowards(transform.position, camino4.listaPuntosDeCamino[columna].transform.position, Time.deltaTime * velocidadMovimiento); // Se le dice al player antivirus en que posicion ubicarse en la fila 3
                if (this.transform.position == camino1.listaPuntosDeCamino[columna].transform.position)
                {
                    spriteRendererAntiV.color = colorNormal;
                    ubicacionCorrecta = true;
                }
                break;
        }      
    }
}
