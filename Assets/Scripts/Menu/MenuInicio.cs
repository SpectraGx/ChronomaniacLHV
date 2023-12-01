using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void Jugar (string nombre)
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(nombre);
        Debug.Log("Funciona");
    }

    public void Salir ()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void Back(){
        Debug.Log("Regresa");
        SceneManager.LoadScene("MainMenu");
    }
}
