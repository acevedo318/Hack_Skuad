using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Text;
using Mono.Data.SqliteClient;

public class ConexionConsultas : MonoBehaviour
{
    private string connection;
    private IDbConnection dbcon;
    private IDbCommand dbcmd;
    private IDataReader reader;
    private StringBuilder builder;

    void Start()
    {
        OpenDB();
    }

    public void OpenDB()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/JuegoDeMesa.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM Partida WHERE idPartida = 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);

            Debug.Log("id= " + id);
        }

        reader.Close();
        reader = null;

        dbcmd.Dispose();
        dbcmd = null;

        dbconn.Close();
        dbconn = null;
    }

}