using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaludBandera : MonoBehaviour
{
    public int salud = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(salud < 1){
            //SceneManager.LoadScene("Nivel 0");
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }


    public void dañar(){
        print("me dañe");
        salud--;
    }



}
