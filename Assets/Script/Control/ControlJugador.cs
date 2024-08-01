using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mathf;

public class ControlJugador : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public GameObject camaraPrimeraPersona;
    public GameObject camaraAerea;
    private bool aerea;

    void Start(){
        aerea = false;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update(){
    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");
    
    if(vertical != 0){
        float angulo = transform.rotation.eulerAngles.y;
        m_Rigidbody.velocity = new Vector3(vertical * Mathf.Cos((Mathf.PI / 180) * angulo), m_Rigidbody.velocity.y, -vertical * Mathf.Sin((Mathf.PI / 180) * angulo)) * 2;
        //m_Rigidbody.velocity = new Vector3(-vertical * Mathf.Sin((Mathf.PI / 180) * angulo), m_Rigidbody.velocity.y, vertical * Mathf.Cos((Mathf.PI / 180) * angulo));

    }
    //
    
    if(horizontal != 0){
        Vector3 angulos = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, angulos.y + horizontal, 0f);
        }

    if (Input.GetKeyDown("y"))
        {
            if(aerea){
                camaraAerea.SetActive(false);
                camaraPrimeraPersona.SetActive(true);
            }else
            {
                camaraAerea.SetActive(true);
                camaraPrimeraPersona.SetActive(false);
            }
            aerea = !aerea;
        }

    }
}
