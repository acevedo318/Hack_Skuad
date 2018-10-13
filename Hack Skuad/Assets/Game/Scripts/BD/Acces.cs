using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acces : MonoBehaviour
{

    public string URIDataBase;

    private Conexion conector;

    void Start()
    {
        conector = gameObject.AddComponent<Conexion>();

        conector.OpenDB("URI=file:" + Application.dataPath + "/DB/JuegoDeMesa.db");
        conector.SelectData();
        conector.CloseDB();
    }
}
