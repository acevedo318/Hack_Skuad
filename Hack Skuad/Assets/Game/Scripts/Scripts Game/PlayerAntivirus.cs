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

    public ContenedorArray camino1;
    public ContenedorArray camino2;
    public ContenedorArray camino3;
    public ContenedorArray camino4;

    private float velocidadMovimiento = 2f;
    private bool ubicacionCorrecta;

    // Use this for initialization
    void Start ()
	{
        ubicacionCorrecta = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (ubicacionCorrecta==false) {
            UbicarAntivirus();
        }
        
	}

    public void TirarDado()
    {
        if (puedeTirarDado)
        {
            StartCoroutine(dado.RodarDado());
        }
    }

    public void UbicarAntivirus()
    {
        System.Random random = new System.Random();
        int randomCamino = random.Next(0, 3);
        int randomColumna = random.Next(0, 9);
        Debug.Log("Camino: " + randomCamino + ", Columna: " + randomColumna);
        switch (randomCamino)
        {
            case 0:
                this.transform.position = Vector2.MoveTowards(transform.position, camino1.listaPuntosDeCamino[randomColumna].transform.position, Time.deltaTime * velocidadMovimiento);
                if (this.transform.position == camino1.listaPuntosDeCamino[randomColumna].transform.position)
                {
                    ubicacionCorrecta = true;
                }
                break;
            case 1:
                this.transform.position = Vector2.MoveTowards(transform.position, camino2.listaPuntosDeCamino[randomColumna].transform.position, Time.deltaTime * velocidadMovimiento);
                if (this.transform.position == camino2.listaPuntosDeCamino[randomColumna].transform.position)
                {
                    ubicacionCorrecta = true;
                }
                break;
            case 2:
                this.transform.position = Vector2.MoveTowards(transform.position, camino3.listaPuntosDeCamino[randomColumna].transform.position, Time.deltaTime * velocidadMovimiento);
                if (this.transform.position == camino3.listaPuntosDeCamino[randomColumna].transform.position)
                {
                    ubicacionCorrecta = true;
                }
                break;
            case 3:
                this.transform.position = Vector2.MoveTowards(transform.position, camino4.listaPuntosDeCamino[randomColumna].transform.position, Time.deltaTime * velocidadMovimiento);
                if (this.transform.position == camino1.listaPuntosDeCamino[randomColumna].transform.position)
                {
                    ubicacionCorrecta = true;
                }
                break;
        }
        
    }

}
