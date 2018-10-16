using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

/// <summary>
/// Conexion a la base de datos 
/// </summary>
public class Conexion : MonoBehaviour
{

    private SqliteConnection conexion;
    private SqliteCommand command;
    private SqliteDataReader reader;

    private string query;
    /// <summary>
    /// Se abre la Base de datos JuegoDeMesa.db
    /// </summary>
    /// <param name="dbName"></param>
    public void OpenDB(string dbName)
    {
        conexion = new SqliteConnection(dbName);
        conexion.Open();
    }
    /// <summary>
    /// Se selecciona todos los datos de una tabla
    /// </summary>
    public void SelectData()
    {
        query = "SELECT * FROM Virus";
        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();

        if (reader != null)
        {
            while (reader.Read())
            {
                print(reader.GetValue(1).ToString() + " - " + reader.GetValue(2).ToString());
            }
        }
    }
    /// <summary>
    /// Para insertar datos a una tabla
    /// </summary>
    /// <param name="puntos"></param>
    /// <param name="nombre"></param>
    public void InsertData(int puntos, string nombre)
    {
        query = "INSERT INTO Virus VALUES(2, '" + puntos + "', '" + nombre + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }
    /// <summary>
    /// Se cargan los datos de una tabla referenciando un atributo
    /// </summary>
    /// <param name="name"></param>
    public void UpdateData(string name)
    {
        query = "UPDATE Partida SET nombre = '" + name + "' WHERE id = 1";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }
    /// <summary>
    /// Se cierra la base de datos
    /// </summary>
    public void CloseDB()
    {
        reader.Close();
        reader = null;

        command = null;

        conexion.Close();
        conexion = null;
    }
}
