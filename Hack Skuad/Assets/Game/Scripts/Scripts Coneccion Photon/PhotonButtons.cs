using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour {

    
    public InputField joinRoomInput, createRoomInput;

public photonHandler pHandler;

	public void OnClickJoinRoom()
    {
       pHandler.joinOrCreateRoom();
    }

    public void OnClickCreateRoom()
    {
        if(createRoomInput.text.Length > 1)
        {
            pHandler.createNewRoom();
        }
        
    }


    private void OnLeftRoom()
    {

    }

}
