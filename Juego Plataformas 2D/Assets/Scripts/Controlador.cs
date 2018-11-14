using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour {

    public void CambiarEscena(string nombre)
    {
        print("cambiando escena a " + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        print("saliendo del juego");
        Application.Quit();
    }
}
