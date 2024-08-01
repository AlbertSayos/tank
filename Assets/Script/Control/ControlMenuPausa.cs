using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenuPausa : MonoBehaviour
{

    public GameObject control;
    private ControlDelJuego controlDejuego;

    void Start() {
        controlDejuego = control.GetComponent<ControlDelJuego>();
    }

    public void reinciar(){
        controlDejuego.ResumeGame();
        SceneManager.LoadScene("Nivel 1");
    }

    public void salir(){
        Application.Quit();
    }

    public void continuar(){
        controlDejuego.ResumeGame();
    }

}
