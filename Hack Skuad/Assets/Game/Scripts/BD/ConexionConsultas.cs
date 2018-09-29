using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Text;
using Mono.Data.SqliteClient;

public class ConexionConsultas : MonoBehaviour {
	private string connection;
	private IDbConnection dbcon;
	private IDbCommand dbcmd;
	private IDataReader reader;
	private StringBuilder builder;


	public void OpenDB(string p)
	{
		string filepath = Application.persistentDataPath + "/" + p;
		if(!File.Exists(filepath))
		{
			WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
			while(!loadDB.isDone) {}
			File.WriteAllBytes(filepath, loadDB.bytes);
		}

		connection = "URI=file:" + filepath;
		Debug.Log("Stablishing connection to: " + connection);
		dbcon = new SqliteConnection(connection);
		dbcon.Open();
	}


	public void CloseDB(){
		reader.Close(); 
  	 	reader = null;
   		dbcmd.Dispose();
   		dbcmd = null;
   		dbcon.Close();
   		dbcon = null;
	}


	public string retornarUsuarioPorId(int id){ 
		string consulta,usuario="";
		consulta = "SELECT * FROM Usuarios WHERE idUsuario = "+id+"";	
		dbcmd = dbcon.CreateCommand();
		dbcmd.CommandText = consulta;
		reader = dbcmd.ExecuteReader();


		while(reader.Read()){
			
			usuario = reader.GetString (1);
		}

		return usuario;
	}

}