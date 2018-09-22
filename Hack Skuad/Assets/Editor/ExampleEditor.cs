using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// @autor Kevin Acevedo 
/// Esta clase se creo como un ejemplo de la manera de extender el editor
/// @Version 1
/// </summary>
public class ExampleEditor : EditorWindow {

    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    int myInt = 3;
    float myFloat = 1.23f;


    [MenuItem("GameDev Cafe/Informacion")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ExampleEditor));
    }

    void OnGUI()
    {
        
        GUILayout.Label("Configuraciones de Ejemplo", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Caja de texto", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Configuraciones Opcionales", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider de float", myFloat, -3, 3);
        myInt = EditorGUILayout.IntSlider("Slider de Int", myInt, 0, 5);
        EditorGUILayout.EndToggleGroup();
        GUILayout.Label("\n \n Version 1 \n 2018", EditorStyles.boldLabel);
    }
}
