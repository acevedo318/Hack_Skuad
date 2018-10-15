using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : Photon.MonoBehaviour {

	public string versionName = "0.1";
    private photonHandler photonHandler;
    private bool joinRoom = false;

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
    /// Cuando se conecta al master
    /// </summary>
	private void OnConnectedToMaster(){
		PhotonNetwork.JoinLobby(TypedLobby.Default);
        PhotonNetwork.player.NickName = SystemInfo.deviceName;
        print(PhotonNetwork.player.NickName);
		Debug.Log("We are conneted to Master");
	}

    /// <summary>
    /// Se desconecta del Photon
    /// </summary>
	private void OnDisconnectedFromPhoton(){


		Debug.Log("Dis from photon services");
	}

    /// <summary>
    /// Falla la conexion
    /// </summary>
	private void OnFailedToConnectToPhoton(){
		
	}

    /// <summary>
    /// Se ha unido
    /// </summary>
	private void OnJoinedLobby(){

		Debug.Log("On Joined Lobby");
	}

    /// <summary>
    /// No permite que se apague la pantalla
    /// </summary>
    public void PantallaSiempreEncendida()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    /// <summary>
    /// Se ha unido a una sala
    /// </summary>
    private void OnJoinedRoom()
    {
        joinRoom = true;
    }

    /// <summary>
    /// GUI PRUEBAS
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
