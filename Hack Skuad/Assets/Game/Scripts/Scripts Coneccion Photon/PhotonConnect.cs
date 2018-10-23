using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// Crea y permite la conección entre el servidor de Photon y el usuario, muestra los datos de esta conección
    /// </summary>
public class PhotonConnect : Photon.MonoBehaviour {

	public string versionName = "0.1";
    private photonHandler photonHandler;
    private bool joinRoom = false;

	// En el caso de que no haya coneccion se procede a crear una nueva coneccion y se le asigna la version 
	// se llama la funcion para mantener la pantalla siempre encendida.
	private void Awake(){
        if (!PhotonNetwork.connected)
        {
           PhotonNetwork.ConnectUsingSettings(versionName);
            
            Debug.Log("connecting to photon");
        }
		
        this.photonHandler = GetComponent<photonHandler>();
        PantallaSiempreEncendida();
		
	}

    /// <summary>
    /// Cuando se conecte al servidor se le da un nombre al player en el servidor.
    /// </summary>
	private void OnConnectedToMaster(){
		PhotonNetwork.JoinLobby(TypedLobby.Default);
        PhotonNetwork.player.NickName = SystemInfo.deviceName;
        //print(PhotonNetwork.player.NickName);
		//Debug.Log("We are conneted to Master");
	}

    /// <summary>
    /// Cuando se pierda la coneccion se imprime en consola
    /// </summary>
	private void OnDisconnectedFromPhoton(){


		Debug.Log("Dis from photon services");
	}

 
	private void OnFailedToConnectToPhoton(){
		
	}


	private void OnJoinedLobby(){

		Debug.Log("On Joined Lobby");
	}

    /// <summary>
    /// No permite que se apague la pantalla en el caso de un dispositivo movil
    /// </summary>
    public void PantallaSiempreEncendida()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    /// <summary>
    /// Verifica que se haya unido a una sola y se asigna en el booleano joinRoom
    /// </summary>
    private void OnJoinedRoom()
    {
        joinRoom = true;
    }

    /// <summary>
    /// Muestra en pantalla datos de conección, como el estado de coneccion o el nombre de sala en la que se encuentra,
    /// ping y usuarios conectados.
    /// </summary>
    private void OnGUI()
    {
        GUI.enabled = false;
        GUILayout.TextArea(PhotonNetwork.countOfPlayers.ToString());
        GUILayout.TextArea(PhotonNetwork.connectionState.ToString());
		GUILayout.TextArea(PhotonNetwork.GetPing().ToString());
        GUILayout.TextArea("In Room= " + PhotonNetwork.countOfPlayersInRooms);
        //Centro
        GUILayout.BeginArea(new Rect((Screen.width / 2) - 50, 0, 200, 200));
        GUILayout.TextArea(this.photonHandler.Identificador);
        GUILayout.EndArea();

        if (joinRoom)
        {
            GUILayout.BeginArea(new Rect((Screen.width) - 200, 0, 200, 200));
            GUILayout.TextArea("Nombre de sala: \n"+ PhotonNetwork.room.Name);
            GUILayout.TextArea("Jugadores");
            foreach (var item in PhotonNetwork.playerList)
            {
                GUILayout.TextArea(item.NickName);
            }
            GUILayout.EndArea();
        }

        GUI.enabled = true;
       
        
		
    }
	
}
