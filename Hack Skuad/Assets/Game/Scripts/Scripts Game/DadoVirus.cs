using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DadoVirus : MonoBehaviour {

    [SerializeField]
    private TMP_Dropdown posicionY,posicionX;
    [SerializeField]
    private TMP_Dropdown posicionSum,posicionValorCond;//Valores de las condiciones
    [SerializeField]
    private TMP_Dropdown posicionCondicional, posicionSumCond;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int PosicionY
    {
        get
        {
            return int.Parse(this.posicionY.options[this.posicionY.value].text);
        }

    }

    public int PosicionX
    {
        get
        {
            return int.Parse(this.posicionX.options[this.posicionX.value].text);
        }

    }

    /// <summary>
    /// Condicion Mientras valores < > 
    /// </summary>
    public string Condicion
    {
        get
        {
            return this.posicionCondicional.options[this.posicionCondicional.value].text;
        }
        
    }

    public int ValorCondicion
    {
        get
        {
            return int.Parse(this.posicionValorCond.options[this.posicionValorCond.value].text);
        }

    }

    public int ValorASumar
    {
        get
        {
            if (CondicionSuma == "+")
            {
                return int.Parse(this.posicionSum.options[this.posicionSum.value].text);
            }
            else{
                return -int.Parse(this.posicionSum.options[this.posicionSum.value].text);
            }
            
        }

    }

    /// <summary>
    /// Condicion que hara el mientras valores + -
    /// </summary>
    private string CondicionSuma
    {
        get
        {
            return this.posicionSumCond.options[this.posicionSumCond.value].text;
        }

    }

}
