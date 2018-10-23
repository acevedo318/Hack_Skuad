using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour {

    
    public InputField createRoomInput;
    public Dropdown dropdownJoinRoom;

public photonHandler pHandler;

    public void Awake()
    {
        CargarSalas();
    }

    public void OnClickJoinRoom()
    {
       pHandler.joinOrCreateRoom();
    }

    /// <summary>
    /// Verifica que el nombre de la sala tengo mas de dos caracteres y cuando se cumpla se procede a crear una nueva sala
    /// </summary>
    public void OnClickCreateRoom()
    {
        if(createRoomInput.text.Length > 1)
        {
            pHandler.createNewRoom();
        }
        
    }

    /// <summary>
    /// Busca las salas disponibles y las agrega como opciones en el Dropdown
    /// </summary>
    public void CargarSalas()
    {
        dropdownJoinRoom.options.Clear();
        
        foreach (var item in PhotonNetwork.GetRoomList())
        {
            Dropdown.OptionData opcion = new Dropdown.OptionData();
            opcion.text = item.Name;
            dropdownJoinRoom.options.Add(opcion);
        }
    }


    private void OnLeftRoom()
    {

    }

}
