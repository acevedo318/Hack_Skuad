using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PhotonConnect))]
public class photonHandler : MonoBehaviour {

	[SerializeField]
	PhotonButtons photonB;
	public GameObject playerMain;
    private string identificador;

    public string nombreDeSala;
	private void Awake()
	{
        ConfigurarIdentificador();
        
        

        DontDestroyOnLoad(this.transform);
	}

	public void createNewRoom()
	{
		PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 5 },TypedLobby.Default);
	}

	public void joinOrCreateRoom()
	{
        PhotonNetwork.JoinRoom(photonB.dropdownJoinRoom.options[photonB.dropdownJoinRoom.value].text);
        
	}

	public void moveScene()
	{
		PhotonNetwork.LoadLevel("Test");
	}

	private void OnJoinedRoom()
    {
        nombreDeSala = PhotonNetwork.room.Name;
        foreach (var item in PhotonNetwork.playerList)
        {
            print(item.NickName);
        }
        Debug.Log("Estamos conectados a una Sala");
    }


    private void OnFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		if(scene.name == "Test")
		{
			spawPlayer();
		}
        foreach (var item in PhotonNetwork.playerList)
        {
            print(item.NickName);
        }

    }

	private void spawPlayer()
	{
		PhotonNetwork.Instantiate(playerMain.name,playerMain.transform.position,playerMain.transform.rotation,0);
	}

    private void ConfigurarIdentificador()
    {
        if (PlayerPrefs.GetString("Identificador",null) != null)
        {
            identificador = SystemInfo.deviceName.ToString();
        }
        
    }

    public string Identificador
    {
        get
        {
            return this.identificador;
        }
        set
        {
            this.identificador = value;
        }
    }

    public void AgregarVirus()
    {

    }

    public void AgregarAntiVirus()
    {

    }
}
