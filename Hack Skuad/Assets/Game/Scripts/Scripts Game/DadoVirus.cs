using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DadoVirus : MonoBehaviour {

    [SerializeField]
    private TMP_Dropdown posicionY,posicionX;
    

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

}
