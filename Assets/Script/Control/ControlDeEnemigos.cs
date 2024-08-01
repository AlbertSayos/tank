using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeEnemigos : MonoBehaviour
{
    public List<GameObject> destinos = new List<GameObject>();
    public GameObject enemigo;
    public int cantidadMaxima;
    public Transform puntosDeSpawn;
    private int posActual = 0;

    private GameObject enemigoActual;

    // Start is called before the first frame update
    void Start(){
        /*
        for (var i = 0; i < cantidadMaxima; i++){
            GameObject enemigoAux = Instantiate(enemigo, puntosDeSpawn.position, puntosDeSpawn.rotation);
            enemigoAux.SetActive(false);
            enemigos.Add(enemigo);
            GameObject enemigoAuxDos = enemigos[0]; 
            print(enemigoAuxDos.activeSelf);
        }*/
        crearEnemigo();
    }

    // Update is called once per frame
    void Update(){
        if( posActual >= cantidadMaxima ){
            return;
        }
        if( enemigoActual == null ){
            crearEnemigo();
        }

    }

    public GameObject verEnemigo(){
        
        if(enemigoActual == null){
            return null;
        }
        return enemigoActual;
    }

    private void crearEnemigo(){
        enemigoActual = Instantiate(enemigo, puntosDeSpawn.position, puntosDeSpawn.rotation);
        enemigoActual.SetActive(false);
        posActual++;
        IA ia = enemigoActual.GetComponent<IA>();
        for (var i = 0; i < destinos.Count; i++){
            ia.agregarDestino( destinos[i],i);
        }
    }

    public bool quedanEnemigos(){
        /*
        print(posActual);
        if( posActual > cantidadMaxima ){
            return false;
        }else{
            return true;
        }
        */
        if(enemigoActual == null){
            return false;
        }
        return true;
        //return !(posActual >= cantidadMaxima);
    }

}
