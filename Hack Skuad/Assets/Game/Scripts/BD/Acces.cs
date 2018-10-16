using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Se accede a la base de datos
/// </summary>
public class Acces : MonoBehaviour
{

    public string URIDataBase;

    private Conexion conector;
    /// <summary>
    /// Al iniciar la aplicacion se busca la base de datos con la direccion URI
    /// </summary>
    void Start()
    {
        conector = gameObject.AddComponent<Conexion>();

        conector.OpenDB("URI=file:" + Application.dataPath + "/DB/JuegoDeMesa.db");
        conector.SelectData();
        conector.CloseDB();
    }
}
