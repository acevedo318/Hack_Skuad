using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMenu : MonoBehaviour {


	public string connectionIP = "127.0.0.1";
	public int portNumber = 8632;
	private bool connected = false;

	public void OnGUI()
	{

		if(connected){

		GUILayout.Label("Connection: "+Network.connections.Length.ToString());
			print("Connection: "+Network.connections.Length.ToString());

		}else{

		connectionIP = GUILayout.TextField(connectionIP);
		portNumber = int.Parse(GUILayout.TextField(portNumber.ToString()));

		if(GUILayout.Button("Connect"))
		{
			Network.Connect(connectionIP,portNumber);
				OnConnectedToServer();
		}

		if(GUILayout.Button("Host"))
		{
			Network.InitializeServer(4,portNumber,true);
				OnServerInitialiced();
		}
		}
	}

	private void OnConnectedToServer()
	{
		//Server conectado
		connected = true;
		
	}

	private void OnDisconnectedToServer()
	{
		//Server desconectado
		connected = false;
	}

	private void OnServerInitialiced()
	{
		//Server Inicualized
		connected = true;
	}
}
