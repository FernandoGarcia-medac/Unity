using UnityEngine;

public class ColisionesJugador : MonoBehaviour {
    public GameManager gameManager;

    void Start() {
        // Busca el objeto GameManager en la escena al empezar
        gameManager = Object.FindAnyObjectByType<GameManager>();
    }

    // Cambiado a OnTriggerEnter y Collider (versiones 3D)
    void OnTriggerEnter(Collider objetoTocado) { 
        if (gameManager == null) return;

        if (objetoTocado.CompareTag("Moneda")) {
            gameManager.sumarPuntos(10);
            Destroy(objetoTocado.gameObject);
        } 
        else if (objetoTocado.CompareTag("bomba")) {
            gameManager.perderVida(1);
            Destroy(objetoTocado.gameObject);
        }
        else if (objetoTocado.gameObject.name == "zombie") { 
            gameManager.perderVida(1);
            Debug.Log("¡Cuidado! El zombie te ha quitado una vida.");
        }
    }
}