using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(PhotonConnect))]
public class photonHandler : MonoBehaviour {

	[SerializeField]
	PhotonButtons photonB;
	public GameObject playerMain;
    private string identificador;
    /// <summary>
    /// Contiene los jugadores
    /// </summary>
    public GameObject contentPlayerUI;

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

    public void ListarPlayers()
    {
        if (SceneManager.GetActiveScene().name == "UIGame")
        {
            

            StartCoroutine(GenerarLista());
        }
    }

    

    IEnumerator GenerarLista()
    {
        GameObject butonPlayer = Resources.Load("ButtonPlayers") as GameObject;
        GameObject instancia;
        List<GameObject> instanciasArray = new List<GameObject>();
        int numeroDeJugadores = 0;

        yield return new WaitForSeconds(3f);
        do
        {
            if (PhotonNetwork.inRoom)
            {
                if (numeroDeJugadores != PhotonNetwork.playerList.Length)
                {
                    foreach (var item in instanciasArray)
                    {
                        Destroy(item);
                    }
                    instanciasArray.Clear();
                    yield return new WaitForSeconds(0.1f);

                    foreach (var item in PhotonNetwork.playerList)
                    {
                        instancia = Instantiate(butonPlayer);
                        instancia.transform.SetParent(contentPlayerUI.transform);
                        instancia.GetComponent<RectTransform>().localScale = Vector3.one;
                        instancia.GetComponentInChildren<Text>().text = item.NickName;
                        instanciasArray.Add(instancia);
                    }
                   
                }
                
                
            }
            
            numeroDeJugadores = PhotonNetwork.playerList.Length;
            yield return new WaitForSeconds(6f);

            

        } while (true);


        
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
