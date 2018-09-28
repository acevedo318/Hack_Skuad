using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectRolController : MonoBehaviour
{

    [SerializeField]
    private GameObject botonIniciarPartida; // Botón para iniciar el juego al momento de chequear todos los toggles.

    void Start()
    {
        botonIniciarPartida.SetActive(false); // Al iniciar el menú SeleccionarRol, el botón está deshabilitado.
    }

    bool checkInteger = false; // Variable booleana para chequear el estado del Toggle Integer
    bool checkString = false; // Variable booleana para chequear el estado del Toggle String
    bool checkBoolean = false; // Variable booleana para chequear el estado del Toggle Boolean
    bool checkDouble = false; // Variable booleana para chequear el estado del Toggle Double
    bool checkAntivirus = false; // Variable booleana para chequear el estado del Toggle Antivirus

    // Método para cambiar el estado de la variable booleana checkInteger a "true" y se verifica el método "Validación"
    public void VerificacionInteger()
    {
        checkInteger = !checkInteger;
        ValidacionTodosToggles();
    }

    // Método para cambiar el estado de la variable booleana checkString a "true" y se verifica el método "Validación"
    public void ValidacionString()
    {
        checkString = !checkString;
        ValidacionTodosToggles();
    }

    // Método para cambiar el estado de la variable booleana checkBoolean a "true" y se verifica el método "Validación"
    public void ValidacionBoolean()
    {
        checkBoolean = !checkBoolean;
        ValidacionTodosToggles();
    }

    // Método para cambiar el estado de la variable booleana checkDouble a "true" y se verifica el método "Validación"
    public void ValidacionDouble()
    {
        checkDouble = !checkDouble;
        ValidacionTodosToggles();
    }

    // Método para cambiar el estado de la variable booleana checkAntivirus a "true" y se verifica el método "Validación"
    public void ValidacionAntivirus()
    {
        checkAntivirus = !checkAntivirus;
        ValidacionTodosToggles();
    }

    // Método para verificar el estado de todas las variables booleanas, si son todas verdaderas, el botón "Iniciar" se activa, de lo contrario no
    private void ValidacionTodosToggles()
    {
        if (checkBoolean && checkDouble && checkInteger && checkString && checkAntivirus)
        {
            botonIniciarPartida.SetActive(true);
        }
        else
        {
            botonIniciarPartida.SetActive(false);
        }
    }

    // Método para cambiar de la escena actual a la del juego principal
    public void CambioEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
