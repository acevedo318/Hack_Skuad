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

    private int posicionY, posicionX;


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public void Ubicar()
    {
        posicionY = int.Parse(player.jugada.Substring(0, 1));

        posicionX = int.Parse(player.jugada.Substring(1, 1));


        GameObject caminoY = caminos.transform.GetChild(posicionY).gameObject;
        GameObject caminoX = caminoY.GetComponent<ContenedorArray>().listaPuntosDeCamino[posicionX];

        Vector2 ubicacion = new Vector2(caminoX.transform.position.x, caminoX.transform.position.y);

        transform.position = ubicacion;


        StartCoroutine(MoverCondicional(caminoY));


    }

    /// <summary>
    /// Se repetira hasta que se cumpla la condicion
    /// </summary>
    /// <param name="caminoY"></param>
    IEnumerator MoverCondicional(GameObject caminoY)
    {

        if (player.jugada[2].ToString() == "<")
        {

            for (int i = posicionX; i < int.Parse(player.jugada.Substring(3,1)) + 1; i += int.Parse(player.jugada.Substring(4)))
            {

                GameObject caminoX = caminoY.GetComponent<ContenedorArray>().listaPuntosDeCamino[i];

                StartCoroutine(Mover(caminoX.transform.position));
                yield return new WaitForSeconds(3f);
            }

        }
        else if(player.jugada[2].ToString() == ">")
        {
            for (int i = posicionX; i > int.Parse(player.jugada.Substring(3, 1)) -1; i += int.Parse(player.jugada.Substring(4)))
            {
                
                GameObject caminoX = caminoY.GetComponent<ContenedorArray>().listaPuntosDeCamino[i];

                StartCoroutine(Mover(caminoX.transform.position));
                yield return new WaitForSeconds(3f);
            }
        } 
        yield return new WaitForSeconds(3f);
        
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

    /// <summary>
    /// string con formato posicionY,posicionX,condicion,valCondicion,(+-)ValorASumar
    /// </summary>
    public void GuardarJugada()
    {
        player.jugada = "";
        player.jugada += dadoVirus.PosicionY;
        player.jugada += dadoVirus.PosicionX;
        player.jugada += dadoVirus.Condicion;
        player.jugada += dadoVirus.ValorCondicion;
        player.jugada += dadoVirus.ValorASumar;
    }
   
}

