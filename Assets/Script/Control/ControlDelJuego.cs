using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDelJuego : MonoBehaviour{

    //public GameObject[] enemigos;
    public List<GameObject> enemigos = new List<GameObject>();
    public GameObject bandera;
    public GameObject Jugador;
    public Transform posSpawn;
    public GameObject menuDePausa;
    private int longitud;
    private int pos;
    private float tiempoDeSpawn = 5f;
    private float tiempoAuxiliar = 0f;
    private bool estaEnPausa = false;

    // Start is called before the first frame update
    void Start(){
        longitud = enemigos.Count;
        pos = longitud-1;
    }

    // Update is called once per frame
    void Update(){

        if(enemigos.Count != 0){
            if(enemigos[pos] == null){
                enemigos.RemoveAt(pos);
                longitud = enemigos.Count;
                pos = longitud-1;
            }
        }else{
            print("enemigos eliminados");
            SceneManager.LoadScene("Nivel 0");
        }
        if(!bandera.activeSelf){
            print("Juego Acabado");
            SceneManager.LoadScene("Nivel 0");
        }
        if(!Jugador.activeSelf){
            print("Respawn");
            if(tiempoAuxiliar == 0){
                tiempoAuxiliar= Time.time + tiempoDeSpawn;
            }
            if(Time.time > tiempoAuxiliar){
                Jugador.transform.position = posSpawn.position;
                SaludJugador saludJugador = Jugador.GetComponent<SaludJugador>();
                saludJugador.restaurar();
                tiempoAuxiliar = 0f;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(estaEnPausa){
                
                ResumeGame();
                
            }else{
                
                PauseGame();

            }
            
        }
    }

    private void PauseGame (){
        menuDePausa.SetActive(true);
        Time.timeScale = 0;
        estaEnPausa = !estaEnPausa;
    }

    public void ResumeGame (){
        menuDePausa.SetActive(false);
        Time.timeScale = 1;
        estaEnPausa = !estaEnPausa;
    }

}
