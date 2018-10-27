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

        
        StartCoroutine(MoverCondicional(caminoY));

        print("sum:" + dadoVirus.ValorASumar);
    }

    /// <summary>
    /// Se repetira hasta que se cumpla la condicion
    /// </summary>
    /// <param name="caminoY"></param>
    IEnumerator MoverCondicional(GameObject caminoY)
    {

        for (int i = dadoVirus.PosicionX; i < 10; i++)
        {

            GameObject caminoX = caminoY.GetComponent<ContenedorArray>().listaPuntosDeCamino[i];
            
            StartCoroutine(Mover(caminoX.transform.position));
            yield return new WaitForSeconds(3f);
        }

    }

    /// <summary>
    /// Se movera
    /// </summary>
    /// <param name="direccion"></param>
    /// <returns></returns>
    IEnumerator Mover(Vector2 direccion)
    {

        Vector3 direccion3 = direccion;
        transform.position = direccion3;
        yield return new WaitForSeconds(1f);

    }
   
}

