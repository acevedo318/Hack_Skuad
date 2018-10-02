using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour {

	public string versionName = "0.1";

	public GameObject sectionView1,sectionView2,sectionView3;

	private void Awake(){
		PhotonNetwork.ConnectUsingSettings(versionName);

		Debug.Log("connecting to photon");
	}

	private void OnConnectedToMaster(){
		PhotonNetwork.JoinLobby(TypedLobby.Default);

		Debug.Log("We are conneted to Master");
	}

	private void OnDisconnectedFromPhoton(){

		if(sectionView1.activeSelf)
			sectionView1.SetActive(false);
		if(sectionView2.activeSelf)
			sectionView2.SetActive(false);

		sectionView3.SetActive(true);

		Debug.Log("Dis from photon services");
	}

	private void OnFailedToConnectToPhoton(){
		
	}

	private void OnJoinedLobby(){
		sectionView1.SetActive(false);
		sectionView2.SetActive(true);


		Debug.Log("On Joined Lobby");
	}

    private void OnGUI()
    {
        GUILayout.TextArea(PhotonNetwork.countOfPlayers.ToString());
        GUILayout.TextArea(PhotonNetwork.connectionState.ToString());
		GUILayout.TextArea(PhotonNetwork.GetPing().ToString());
		
    }


    // Use this for initialization
    void Start () {
		

	}
	
	
}
