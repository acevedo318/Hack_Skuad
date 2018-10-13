using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class Conexion : MonoBehaviour
{

    private SqliteConnection conexion;
    private SqliteCommand command;
    private SqliteDataReader reader;

    private string query;

    public void OpenDB(string dbName)
    {
        conexion = new SqliteConnection(dbName);
        conexion.Open();
    }

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

    public void InsertData(int puntos, string nombre)
    {
        query = "INSERT INTO Virus VALUES(2, '" + puntos + "', '" + nombre + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    public void UpdateData(string name)
    {
        query = "UPDATE Partida SET nombre = '" + name + "' WHERE id = 1";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    public void CloseDB()
    {
        reader.Close();
        reader = null;

        command = null;

        conexion.Close();
        conexion = null;
    }
}
