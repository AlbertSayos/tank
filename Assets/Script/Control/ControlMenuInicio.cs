using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenuInicio : MonoBehaviour
{

    //public GameObject control;
    //private ControlDelJuego controlDejuego;

    void Start() {
        //controlDejuego = control.GetComponent<ControlDelJuego>();s
    }

    public void Iniciar(){
        //controlDejuego.ResumeGame();
        SceneManager.LoadScene("Nivel 1");
    }

    public void salir(){
        Application.Quit();
    }


}
