using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    [Header("Estadísticas de Partida")]
    public int puntos = 0;
    public int objetivoPuntos = 50; 

    [Header("Interfaz de Usuario (UI)")]
    public Text textoPuntos; 
    public GameObject panelGanar;
    public GameObject panelPerder;

    void Start()
    {
        Time.timeScale = 1f;
        
        ActualizarInterfaz();

        if (panelGanar != null) panelGanar.SetActive(false);
        if (panelPerder != null) panelPerder.SetActive(false);
    }

    public void sumarMoneda()
    {
        puntos += 10;
        ActualizarInterfaz();

        if (puntos >= objetivoPuntos)
        {
            Ganar();
        }
    }

    void ActualizarInterfaz()
    {
        if (textoPuntos != null)
        {
            textoPuntos.text = "PUNTOS: " + puntos;
        }
    }

    public void MostrarPantallaDerrota()
    {
        if (panelPerder != null)
        {
            panelPerder.SetActive(true);
            FinalizarPartida(); 
        }
    }

    void Ganar()
    {
        if (panelGanar != null)
        {
            panelGanar.SetActive(true);
            FinalizarPartida(); 
        }
    }

    void FinalizarPartida()
    {
        Time.timeScale = 0f; 
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}