﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase Principal del jugador
/// </summary>
[System.Serializable]
public class Player {

	[SerializeField]
	private string nombre;
	[SerializeField]
	private Vector2 posicionInicial;
	[SerializeField]
	private bool turno = false;

	/// <summary>
	/// Inicializa una nueva instancia de la clase <see cref="Player"/>.
	/// </summary>
	public Player ()
	{
	
	}

	/// <summary>
	/// Inicializa una nueva instancia de la clase <see cref="Player"/>
	/// </summary>
	/// <param name="nombre">Nombre del usuario</param>
	/// <param name="posicionInicial">Posicion inicial.</param>
	/// <param name="turno">Si es el turno del jugador <c>true</c> turno.</param>
	public Player(string nombre,Vector2 posicionInicial,bool turno)
	{

		this.nombre = nombre;
		this.posicionInicial = posicionInicial;
		this.turno = turno;
	}

	public string Nombre
	{
		get { return this.nombre; }
		set { this.nombre = value; }
	}

	public Vector2 PosicionInicial
	{
		get { return this.posicionInicial; }
		set { this.posicionInicial = value; }
	}

	public bool Turno
	{
		get { return this.turno; }
		set { this.turno = value; }
	}


}
