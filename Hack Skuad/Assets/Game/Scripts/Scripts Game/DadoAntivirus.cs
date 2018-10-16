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

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start ()
    {
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CambiarLadoDado()
    {
        
        Debug.Log("Valor de i: "+i);
        i++;
        if (i <= 3) 
        {           
            this.imagenDado.sprite = ladosDado[i];          
        }
        if (i == 4) i = 0;

    }
}
