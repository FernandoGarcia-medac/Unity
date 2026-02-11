using UnityEngine;

public class ColisionesJugador : MonoBehaviour 
{
    public GameManager gameManager; 

    void Start() 
    {
        if (gameManager == null) 
            gameManager = Object.FindAnyObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider objetoTocado) 
    { 
        if (gameManager == null) return;

        if (objetoTocado.CompareTag("Moneda")) 
        {
            gameManager.sumarMoneda(); 
            Destroy(objetoTocado.gameObject);
        } 
        else if (objetoTocado.CompareTag("Muerte")) 
        {
            gameManager.MostrarPantallaDerrota();
        }
    }
}