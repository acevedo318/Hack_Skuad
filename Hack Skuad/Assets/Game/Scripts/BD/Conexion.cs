using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System;

/// <summary>
/// Conexion a la base de datos 
/// </summary>
public class Conexion : MonoBehaviour
{
    private string connectionstring;

    // Use this for initialization
    void Start()
    {
        connectionstring = @"Data Source=USER;Initial Catalog=DbHackSquad;User ID=barragan;Integrated Security=True;";

       SqlConnection dbConnection = new SqlConnection(connectionstring);

        try
        {
            dbConnection.Open();
            Debug.Log("Connected to database.");
        }
        catch (SqlException exception)
        {
            Debug.LogWarning("Se perdio la conexion");
            Debug.LogWarning(exception.ToString());
        }
        //  conn.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
