using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;

public class Acces : MonoBehaviour
{
    public string conn;

    private Conexion conexion;

    // Use this for initialization
    void Start()
    {
        conexion = FindObjectOfType<Conexion>();
        

    }

    public void Llamado(SqlVirus virus)
    {
        try
        {
            conexion.OpenDB("URI=file:" + Application.dataPath + "/DB/JuegoDeMesa.db");
            
            conexion.InsertarDatosVirus(virus.puntosString, virus.puntosDouble, virus.puntosInteger, virus.puntosBoolean);
            
            conexion.SelectDataVirus();
            conexion.CloseDB();
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }


}
