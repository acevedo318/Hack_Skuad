using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticOpciones : MonoBehaviour {

	
    /// <summary>
    /// Finaliza el juego
    /// </summary>
    public void SalirDeJuego()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                     Application.Quit();
        #endif
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
}
