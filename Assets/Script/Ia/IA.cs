using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.Random;

public class IA : MonoBehaviour
{
    public NavMeshAgent nav;
    //public GameObject destinoUno;
    public Transform[] destinos;
    private int Pos;
    private int longitud;
    private float distancia;
    private float distanciaSiguiente;

    void Start(){
        longitud = destinos.Length;
        Pos = Random.Range(0,longitud);
        distanciaSiguiente = 2.0f;
        nav.destination = destinos[Pos].position;
    }

    // Update is called once per frame
    void Update()
    {
        //nav.destination = destinoUno.transform.position;
        //print(longitud);
        distancia = Vector3.Distance(transform.position, destinos[Pos].position);
        //print(distancia);
        if(distancia < distanciaSiguiente  ){
            
            //Pos =  (Pos + 1) % longitud;
            Pos =  Random.Range(0,longitud);
            nav.destination = destinos[Pos].position;
        }
        //print(Random.Range(0,longitud));
    }


    public void agregarDestino(GameObject destino, int posicion){
        destinos[posicion] = destino.transform;
    }


}
