using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.SqlClient;
using System;
using Mono.Data.Sqlite;

/// <summary>
/// Conexion a la base de datos 
/// </summary>
public class Conexion : MonoBehaviour
{
    private IDbConnection dbconn;
    private IDbCommand dbcmd;
    private IDataReader dbreader;

    private string query;

    private Acces accede;

    public void OpenDB(string DBName)
    {
        dbconn = (IDbConnection)new SqliteConnection(DBName);
        dbconn.Open();
    }

    public void SelectDataVirus()
    {
        query = "SELECT * FROM Virus";
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        dbreader = dbcmd.ExecuteReader();

        if (dbreader != null)
        {
            while (dbreader.Read())
            {
                print(dbreader.GetValue(1).ToString() + " - " + dbreader.GetValue(2).ToString() + " - " + dbreader.GetValue(3).ToString()
                    + " - " + dbreader.GetValue(4).ToString());
            }
        }
    }

    public void SelectDataAntivirus()
    {
        query = "SELECT * FROM Antivirus";
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        dbreader = dbcmd.ExecuteReader();

        if (dbreader != null)
        {
            while (dbreader.Read())
            {
                print(dbreader.GetValue(1).ToString() + " - " + dbreader.GetValue(2).ToString() + " - " + dbreader.GetValue(3).ToString()
                    + " - " + dbreader.GetValue(4).ToString() + " - " + dbreader.GetValue(5).ToString());
            }
        }
    }

    public void SelectDataPartida()
    {
        query = "SELECT * FROM Partida";
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        dbreader = dbcmd.ExecuteReader();

        if (dbreader != null)
        {
            while (dbreader.Read())
            {
                print(dbreader.GetValue(1).ToString() + " - " + dbreader.GetValue(2).ToString() + " - " + dbreader.GetValue(3).ToString()
                    + " - " + dbreader.GetValue(4).ToString() + " - " + dbreader.GetValue(5).ToString());
            }
        }
    }

    public void InsertarDatosAntivirus(int puntosResto, int capturaString, int capturaDouble, int capturaInteger, int capturaBoolean)
    {
        query = "INSERT INTO Antivirus VALUES(NULL,'" + puntosResto + "', '" + capturaString + "', '" + capturaDouble + "', '" + capturaInteger + "', '" + capturaBoolean + "')";
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        dbcmd.ExecuteReader();
    }

    public void InsertarDatosVirus(int puntosString, int puntosDouble, int puntosInteger, int puntosBoolean)
    {
        query = "INSERT INTO Virus VALUES(NULL,'" + puntosString + "', '" + puntosDouble + "', '" + puntosInteger + "', '" + puntosBoolean + "')";
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        dbcmd.ExecuteReader();
    }

    public void InsertarDatosPartida(int idAntivirus, int idVirus, int puntosGlobal, string time, string nombreSala)
    {
        query = "INSERT INTO Partida VALUES(NULL,'" + idAntivirus + "', '" + idVirus + "', '" + puntosGlobal + "', '" + time + "', '" + nombreSala + "')";
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        dbcmd.ExecuteReader();
    }

    public void CloseDB()
    {
        dbreader.Close();
        dbreader = null;

        dbcmd.Dispose();
        dbcmd = null;

        dbconn.Close();
        dbconn = null;
    }

    void Start()
    {
        Conexion conexion = FindObjectOfType<Conexion>();
        SqlVirus virus = new SqlVirus(10, 20, 30, 5);
        SqlAntivirus Antivirus = new SqlAntivirus(1, 90, 1, 2, 3, 5);
        accede.Llamado(virus);
    }

}
