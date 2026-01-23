using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    public Transform jugador; // Arrastrar al jugador aqui

    // Usamos LateUpdate para mover la camara DESPUES de que el jugador se haya movido
    void LateUpdate()
    {
        if (jugador != null)
        {
            // Copiamos la x y la y del jugador, pero mantenemos la z de la camara
            transform.position = new Vector3(jugador.position.x, jugador.position.y, transform.position.z);
            
        } 
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
