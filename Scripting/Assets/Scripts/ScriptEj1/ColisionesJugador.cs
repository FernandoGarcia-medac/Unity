using UnityEngine;

public class ColisionesJugador : MonoBehaviour {
    public GameManager gameManager;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D objetoTocado) {
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