using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesJugador : MonoBehaviour
{
    //Referencia al GameManager para poder avisarle
    public GameManager gameManager;

    //1. OntriggerEnter2D para objetos fantasma que atravesamos (monedas)
    void OnTriggerEnter2D(Collider2D objetoTocado)
    {
        //Comprobamos si el objeto con el que hemos chocado es una moneda
        if (objetoTocado.gameObject.CompareTag("Moneda"))
        {
            //Sumamos puntos al GameManager
            gameManager.sumarPuntos(10);

            //Destruimos la moneda
            Destroy(objetoTocado.gameObject);
        }else if (objetoTocado.CompareTag("bomba"))
        {
            gameManager.perderVida(1);

            Destroy(objetoTocado.gameObject);
        }
        
    }
    


 
   
}
