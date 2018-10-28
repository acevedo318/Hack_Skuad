using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La clase Principal del jugador
/// </summary>
[System.Serializable]
public class Player : MonoBehaviour {

	[SerializeField]
	private string nombre;
    /// <summary>
    /// Posicion Actual del Player
    /// </summary>
	[SerializeField]
	private Vector2 posicion;
	[SerializeField]
	private bool turno = false;
    public string jugada;

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
	/// <param name="posicion">Posicion inicial.</param>
	/// <param name="turno">Si es el turno del jugador <c>true</c> turno.</param>
	public Player(string nombre,Vector2 posicion,bool turno)
	{

		this.nombre = nombre;
		this.posicion = posicion;
		this.turno = turno;
	}

	public string Nombre
	{
		get { return this.nombre; }
		set { this.nombre = value; }
	}

	public Vector2 PosicionInicial
	{
		get { return this.posicion; }
		set { this.posicion = value; }
	}

	public bool Turno
	{
		get { return this.turno; }
		set { this.turno = value; }
	}

}
