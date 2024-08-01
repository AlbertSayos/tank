using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeSpawn : MonoBehaviour
{

    //public List<GameObject> puntosDeSpawn = new List<GameObject>();
    public GameObject puntoDeSpawn;
    private ControlDeEnemigos control;
    private GameObject enemigoActual;


    // Start is called before the first frame update
    void Start(){
        control = puntoDeSpawn.GetComponent<ControlDeEnemigos>();
    }

    // Update is called once per frame
    void Update(){
        enemigoActual = control.verEnemigo();
        if (enemigoActual  == null ){
            return;
        }
        //print(enemigoActual.activeSelf);
        if(!enemigoActual.activeSelf){
            print("enemigo activado");
            enemigoActual.SetActive(true);
            enemigoActual.transform.position = puntoDeSpawn.transform.position;
            enemigoActual.transform.rotation = puntoDeSpawn.transform.rotation;
        }

    }

    public bool quedanEnemigos(){
        return control.quedanEnemigos();
    }

}
