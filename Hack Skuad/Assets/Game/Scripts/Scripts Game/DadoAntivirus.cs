using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DadoAntivirus : MonoBehaviour
{

    [SerializeField]
    private Sprite[] ladosDado;

    [SerializeField]
    private Image imagenDado;

    int i;

    // Use this for initialization
    void Start ()
    {
        i = 0;
        //imagenDado = GameObject.Find("DadoFlechaAntivirus").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CambiarLadoDado()
    {
        i++;
        while (i <= 3) 
        {
            imagenDado.sprite = ladosDado[i];          
        }
        if (i == 4) i = 0;

    }
}
