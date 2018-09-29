using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Main : MonoBehaviour {
	private string usuario;
	public Text mensaje;
	ConexionConsultas db = null;

	void Start () {
		

		db = GetComponent<ConexionConsultas>();

		db.OpenDB("JuegoDeMesa.db");

		usuario = db.retornarUsuarioPorId (2);

		mensaje.text = usuario;
			
		db.CloseDB();
	}


}
