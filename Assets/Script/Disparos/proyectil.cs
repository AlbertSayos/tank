using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class proyectil : MonoBehaviour
{
    private Rigidbody rigi;
    private SaludObjetos saludObjetos;
    private SaludBandera saludBandera;
    public GameObject superficie;


    // Start is called before the first frame update
    void Start()
    {
        //agregar velocidad incial
        rigi = gameObject.GetComponent<Rigidbody>();
        //Destroy(gameObject, 5);
    }

    
    private void OnCollisionEnter(Collision collision) {
        /*
        if (collision.gameObject.CompareTag("Enemigo")) {
            
            rigi.velocity = new Vector3(0f,-2f,0f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Pared concreto")) {
            
            rigi.velocity = new Vector3(0f,-2f,0f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Estatua enemiga")) {
            
            rigi.velocity = new Vector3(0f,-2,0f);
            Destroy(collision.gameObject);
            //SceneManager.LoadScene("Nivel 1");
        }
        //Untagged
        */
        /*
        if (!collision.gameObject.CompareTag("Untagged")) {
            saludObjetos = collision.gameObject.GetComponent<saludObjetos>();
        }
        */
        
        if (collision.gameObject.CompareTag("Pared concreto")) {
            
            saludObjetos = collision.gameObject.GetComponent<SaludObjetos>();
            saludObjetos.dañar();
            //ActualizarNav nav = superficie.GetComponent<ActualizarNav>();
            //print("mori");
            //nav.Actualizar();
        }
        
        if (collision.gameObject.CompareTag("Estatua enemiga")) {
            
            //rigi.velocity = new Vector3(0f,-2,0f);
            saludBandera = collision.gameObject.GetComponent<SaludBandera>();
            saludBandera.dañar();
        }
        if (collision.gameObject.CompareTag("Enemigo")) {
            
            //rigi.velocity = new Vector3(0f,-2f,0f);
            saludObjetos = collision.gameObject.GetComponent<SaludObjetos>();
            saludObjetos.dañar();
        }
        
        rigi.velocity = new Vector3(0f,-2,0f);
        rigi.useGravity = true;
        Destroy(gameObject, 0.5f);
    }
    
    public void setSuperficie(GameObject super){
        superficie = super;
    }
    
}
