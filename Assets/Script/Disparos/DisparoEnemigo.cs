using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject proyectil;
    public Transform posicionDelTanque;
    private int rapidez = 600;
    private float temportizador = 0f;
    private float tiempoActual = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > temportizador)
        {
            GameObject ClonProyectil = Instantiate(proyectil, transform.position, transform.rotation);
            
            Rigidbody p = ClonProyectil.GetComponent<Rigidbody>();
            float angulo = posicionDelTanque.rotation.eulerAngles.y;
            
            //Vector3 direccionDelDisparo = new Vector3(posicionDelTanque.position.x * Mathf.Sin((Mathf.PI / 180) * angulo), 0f, posicionDelTanque.position.x * Mathf.Cos((Mathf.PI / 180) * angulo));
            //p.AddForce(direccionDelDisparo * rapidez);
            p.AddForce( transform.forward * rapidez );
            temportizador = Time.time + tiempoActual;
        }

    }
}
