using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    private Rigidbody rigi;
    private SaludObjetos saludObjetos;
    private SaludBandera saludBandera;
    private SaludJugador saludJugador;


    // Start is called before the first frame update
    void Start()
    {
        //agregar velocidad incial
        rigi = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        //rigi.velocity = new Vector3(0f,-2,0f);
        //rigi.useGravity = true;
        if (collision.gameObject.CompareTag("Aliado")) {
            
            saludJugador = collision.gameObject.GetComponent<SaludJugador>();
            saludJugador.dañar();
            Destroy(gameObject, 0.5f);
        }
        if (collision.gameObject.CompareTag("Pared concreto")) {
            
            saludObjetos = collision.gameObject.GetComponent<SaludObjetos>();
            saludObjetos.dañar();
            Destroy(gameObject, 0.5f);
        }
        
        if (collision.gameObject.CompareTag("Estatua enemiga")) {
            
            //rigi.velocity = new Vector3(0f,-2,0f);
            saludBandera = collision.gameObject.GetComponent<SaludBandera>();
            saludBandera.dañar();
            Destroy(gameObject, 0.5f);
        }
        
    }

}
