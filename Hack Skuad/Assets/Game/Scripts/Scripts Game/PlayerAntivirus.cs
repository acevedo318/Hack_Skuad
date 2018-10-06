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

    // Use this for initialization
    void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
        
	}

    public void TirarDado()
    {
        if (puedeTirarDado)
        {
            StartCoroutine(dado.RodarDado());
        }
    }

}
