using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour {

	public string versionName = "0.1";
    private photonHandler photonHandler;

	private void Awake(){
		PhotonNetwork.ConnectUsingSettings(versionName);
        this.photonHandler = GetComponent<photonHandler>();

		Debug.Log("connecting to photon");
	}

    /// <summary>
    /// Cuando se conecta al master
    /// </summary>
	private void OnConnectedToMaster(){
		PhotonNetwork.JoinLobby(TypedLobby.Default);

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

    private void OnGUI()
    {
        GUI.enabled = false;
        GUILayout.TextArea(PhotonNetwork.countOfPlayers.ToString());
        GUILayout.TextArea(PhotonNetwork.connectionState.ToString());
		GUILayout.TextArea(PhotonNetwork.GetPing().ToString());
        //Centro
        GUILayout.BeginArea(new Rect((Screen.width / 2) - 50, /*(Screen.height / 2)*/0, 200, 200));
        GUILayout.TextArea(this.photonHandler.Identificador);
        GUILayout.EndArea();
        
        GUI.enabled = true;
       
        
		
    }
	
}
