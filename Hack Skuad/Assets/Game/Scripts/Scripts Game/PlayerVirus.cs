using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// La clase del jugador Virus
/// </summary>
public class PlayerVirus : MonoBehaviour
{
	[SerializeField]
	private Player player;
    [SerializeField]
    private GameObject[] dados;
    /// <summary>
    /// Gameobjec que contiene los caminos
    /// </summary>
    [SerializeField]
    private GameObject caminos;

    [SerializeField]
    private DadoVirus dadoVirus;

    private int posicionY,posicionX;
    

	// Use this for initialization
	void Start ()
	{
        
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

    /// <summary>
    /// 
    /// </summary>
    public void Ubicar()
    {
        posicionX = dadoVirus.PosicionX;
        posicionY = dadoVirus.PosicionY;

        GameObject caminoY = caminos.transform.GetChild(posicionY).gameObject;
        GameObject caminoX = caminoY.GetComponent<ContenedorArray>().listaPuntosDeCamino[posicionX];
        
        Vector2 ubicacion = new Vector2(caminoX.transform.position.x, caminoX.transform.position.y);

        transform.position = ubicacion;

    }
   
}

