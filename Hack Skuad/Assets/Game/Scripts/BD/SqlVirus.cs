using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqlVirus : MonoBehaviour {
     
    public int idVirus { get; set; }
    public int puntosString { get; set; }
    public int puntosDouble { get; set; }
    public int puntosInteger { get; set; }
    public int puntosBoolean { get; set; }

    public SqlVirus(int puntosString, int puntosDouble, int puntosInteger, int puntosBoolean)
    {
        this.idVirus = idVirus;
        this.puntosString = puntosString;
        this.puntosDouble = puntosDouble;
        this.puntosInteger = puntosInteger;
        this.puntosBoolean = puntosBoolean;
    }

}
