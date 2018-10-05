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
		PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 5 }, null);
	}

	public void joinOrCreateRoom()
	{
		RoomOptions rooms = new RoomOptions();
        rooms.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(photonB.joinRoomInput.text,rooms,TypedLobby.Default);
	}

	public void moveScene()
	{
		PhotonNetwork.LoadLevel("MainGame");
	}

	private void OnJoinedRoom()
    {
        nombreDeSala = PhotonNetwork.room.Name;
        Debug.Log("Estamos conectados a una Sala");
    }

	private void OnFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		if(scene.name == "MainGame")
		{
			spawPlayer();
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
