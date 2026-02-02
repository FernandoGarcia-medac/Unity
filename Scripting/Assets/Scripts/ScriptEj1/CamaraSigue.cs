using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    public Transform jugador; 

    void LateUpdate()
    {
        if (jugador != null)
        {
            transform.position = new Vector3(jugador.position.x, jugador.position.y, transform.position.z);
            
        } 
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
