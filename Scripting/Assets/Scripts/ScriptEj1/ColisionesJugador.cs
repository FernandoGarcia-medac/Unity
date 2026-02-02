using UnityEngine;

public class ColisionesJugador : MonoBehaviour {
    public GameManager gameManager;

    void Start() {
        // Busca el GameManager automáticamente al empezar
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D objetoTocado) {
        if (gameManager == null) return;

        // Detección por etiquetas (Tags) para monedas y bombas
        if (objetoTocado.CompareTag("Moneda")) {
            gameManager.sumarPuntos(10);
            Destroy(objetoTocado.gameObject);
        } 
        else if (objetoTocado.CompareTag("bomba")) {
            gameManager.perderVida(1);
            Destroy(objetoTocado.gameObject);
        }
        // Detección por nombre exacto para el zombie
        else if (objetoTocado.gameObject.name == "zombie") { 
            gameManager.perderVida(1);
            
            // Te empuja un poco a la izquierda para que no te quite todas las vidas seguidas
            
            Debug.Log("¡Cuidado! El zombie te ha quitado una vida.");
        }
    }
}