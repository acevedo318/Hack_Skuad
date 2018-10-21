﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DadoAntivirus : MonoBehaviour
{    
    public Sprite[] ladosDado;

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
        this.imagenDado.sprite = ladosDado[i];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Método que cambia la imagen del boton, segun el jugador antivirus desee
    public void CambiarLadoDado()
    {
        i++;
        if (i <= 3)
        {
            this.imagenDado.sprite = ladosDado[i];
        }
        else if (i == 4)
        {
            i = 0;
            this.imagenDado.sprite = ladosDado[i];
        }

    }
}
