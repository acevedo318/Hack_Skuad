using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

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
    [SerializeField]
    private GameObject textoSala;

    public string nombreDeSala;
    
    /// <summary>
    /// Asigna el nombre del dispositivo al servidor y no permite que este GameObject se destruya en caso de cambiar de escena
    /// </summary>
	private void Awake()
	{
        ConfigurarIdentificador();
        
        

        DontDestroyOnLoad(this.transform);
	}

    /// <summary>
    /// Crea una nueva sala tomando los datos del script PhotonButtons y asignando un limite de 5 jugadores como maximo
    /// </summary>
	public void createNewRoom()
	{
		PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 5 },TypedLobby.Default);
	}

    /// <summary>
    /// Se une a una nueva sala tomando los datos del script PhotonButtons solo solicitando el nombre de la sala a unir
    /// </summary>
	public void joinOrCreateRoom()
	{
        PhotonNetwork.JoinRoom(photonB.dropdownJoinRoom.options[photonB.dropdownJoinRoom.value].text);
        
	}

    /// <summary>
    /// ***
    /// </summary>
	public void moveScene()
	{
		PhotonNetwork.LoadLevel("Test");
	}

    /// <summary>
    /// Cuando el usuario se haya unido a una sala se obtiene el nombre y se muestra en pantalla
    /// </summary>
	private void OnJoinedRoom()
    {
        nombreDeSala = PhotonNetwork.room.Name;
        Debug.Log("Estamos conectados a una Sala");
        textoSala.GetComponent<TextMeshProUGUI>().text = "Sala: \n" + nombreDeSala;
    }

    /// <summary>
    /// Cuando se haya terminado de cargar una escena se verifica que sea la de juego y si esta en la escena de juego se crea una instancia del jugador
    /// </summary>
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

    /// <summary>
    /// Cuando se llama verifica que este en la escena del Menu de juego y si es correcto activa la corrutina para generar una lista de usuarios conectados
    /// </summary>
    public void ListarPlayers()
    {
        if (SceneManager.GetActiveScene().name == "UIGame")
        {
            

            StartCoroutine(GenerarLista());
        }
    }

    
    /// <summary>
    /// Crea unas instancias de botones dependiendo del numero de usuarios conectados en la misma sala y muestra los Nicknames de los usuarios conectados
    /// Se sigue verificando cada 6 Segundos si se ha unido un nuevo usuario.
    /// </summary>
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

    /// <summary>
    /// Crea una instancia del jugador el cual tiene una posicion central
    /// </summary>
	private void spawPlayer()
	{
		PhotonNetwork.Instantiate(playerMain.name,playerMain.transform.position,playerMain.transform.rotation,0);
	}

    /// <summary>
    /// Si no se encuentra un nombre de usuario como identificador se le asigna de forma predeterminada el nombre del dispositivo
    /// </summary>
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
