using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonajesController : MonoBehaviour
{

    [SerializeField]
    private Animator animadorMovimientoPersonajes; // Llamado al animator que controla el movimiento de los personajes en la UI

    [SerializeField]
    private GameObject panelSeleccionRol; // Llamado al panel de Seleccion Rol, donde se deben ubicar los personajes

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UbicacionPersonajes();
    }

    //Método para ubicar a los personajes en sus respectivos Toggles, con el fin de ayudar al usuario a identificarlos mejor
    public void UbicacionPersonajes()
    {

        if (panelSeleccionRol.activeSelf.Equals(true)) // Se evalua si el panel de seleccion de rol esta activo, si lo está, se setea un disparador para dar paso a la transición
        {

            animadorMovimientoPersonajes.SetTrigger("DisparadorMovimiento");

        }

    }
}
