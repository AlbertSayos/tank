using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludJugador : MonoBehaviour{

    public int salud = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(salud < 1){
            gameObject.SetActive(false);
        }
    }


    public void dañar(){
        //print("me dañe");
        salud--;
    }

    public void restaurar(){
        salud = 1;
        gameObject.SetActive(true);
    }

}
