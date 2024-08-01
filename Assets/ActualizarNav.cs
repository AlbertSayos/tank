using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActualizarNav : MonoBehaviour
{
    private NavMeshSurface navAux;
    void Start()
    {
        navAux = gameObject.GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Actualizar(){
        
        navAux.BuildNavMesh();
    }
}
