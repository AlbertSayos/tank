using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ControlDeJuegoDos : MonoBehaviour
{
   //public GameObject[] enemigos;
    public List<ControlDeSpawn> controlDeSpawn = new List<ControlDeSpawn>();
    public GameObject bandera;
    public GameObject Jugador;
    public Transform posSpawn;
    public GameObject menuDePausa;
    private int fotogramas = 60;
    private int longitud;
    private int pos;
    private float tiempoDeSpawn = 5f;
    private float tiempoAuxiliar = 0f;
    private bool estaEnPausa = false;
    private bool finDeJuego = false;
    private string[] arrayOfNames;
    private int cantidadDeEscenas;

    // Start is called before the first frame update
    void Start(){
        cantidadDeEscenas = SceneManager.sceneCountInBuildSettings;
         //string[] arrayOfNames;
         arrayOfNames = new string[cantidadDeEscenas];
         int j = 0;
         for (int i = 2; i < cantidadDeEscenas; i++){
            arrayOfNames[j] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            j++;
         }
        cantidadDeEscenas = cantidadDeEscenas -2;

        //int cantidad = SceneManager.sceneCountInBuildSettings;
        /*
        cantidadDeEscenas--;
        for (int i = 0; i < cantidadDeEscenas; i++)
        {
            print(arrayOfNames[i]);
        }*/
    }

    // Update is called once per frame
    void Update(){
        /*
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
        */
        for (var i = 0; i < controlDeSpawn.Count; i++){
            //finDeJuego = !(controlDeSpawn.quedanEnemigos());
            if(controlDeSpawn[i].quedanEnemigos()){
                finDeJuego = false;
                break;
            }else{
                finDeJuego = true;
            }
            //finDeJuego = (controlDeSpawn.quedanEnemigos());
        }

        if(finDeJuego){
            print("enemigos eliminados");
            nextEscene();
            //SceneManager.LoadScene("Nivel 0");
        }


        if(!bandera.activeSelf){
            print("Juego Acabado");
            SceneManager.LoadScene("Nivel 1");
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
        //nextEscene();
    }

    public void ResumeGame (){
        menuDePausa.SetActive(false);
        Time.timeScale = 1;
        estaEnPausa = !estaEnPausa;
    }

    public void nextEscene(){
        
        int cantidad = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < cantidad; i++)
        {
            print(arrayOfNames[i]);
        }
        Scene scene = SceneManager.GetActiveScene();
        string nameScene = scene.name;
        int position = BuscarPosision(nameScene);
        print(cantidadDeEscenas);
        int nextPosition = (position + 1) % cantidadDeEscenas;
        print(nextPosition);
        SceneManager.LoadScene(arrayOfNames[nextPosition]);
    }

    private int BuscarPosision(string nombre){
        int contador = 0;
        for (int i = 0; i < cantidadDeEscenas; i++){
            if( arrayOfNames[i] == nombre ){
                contador = i;
            }
        }
        return contador; 
    }

    void Awake(){
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = fotogramas;
    }

    

}
