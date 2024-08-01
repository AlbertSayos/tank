using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SaludObjetos : MonoBehaviour
{
    public int salud = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(salud < 1){
            //gameObject.SetActive(False);
            //gameObject.BuildNavMesh();
            //gameObject.SetActive(false);
           // NavMeshSurface navAux = gameObject.GetComponent<NavMeshSurface>();
           // navAux.BuildNavMesh();
        
            Destroy(gameObject);
        }
    }


    public void dañar(){
        //print("me dañe");
        salud--;
    }

}
