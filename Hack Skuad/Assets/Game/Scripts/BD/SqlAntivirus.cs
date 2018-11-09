using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqlAntivirus : MonoBehaviour {

    int idAntivirus { get; set; } 
    int puntosResto { get; set; }
    int capturaString { get; set; }
    int capturaDouble { get; set; }
    int capturaInteger { get; set; }
    int capturaBoolean { get; set; }

    public SqlAntivirus(int idAntivirus, int puntosResto, int capturaString, int capturaDouble, int capturaInteger, int capturaBoolean)
    {
        this.idAntivirus = idAntivirus;
        this.puntosResto = puntosResto;
        this.capturaString = capturaString;
        this.capturaDouble = capturaDouble;
        this.capturaInteger = capturaInteger;
        this.capturaBoolean = capturaBoolean;
    }
}
