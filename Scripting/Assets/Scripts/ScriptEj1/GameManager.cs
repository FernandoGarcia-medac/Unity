using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int puntos = 0;
    public int vidas = 3;
    
    public Text textoPuntos;
    public Text textoVidas;
    public GameObject panelGameOver;
    public GameObject panelVictoria;

    public AudioSource sonidoMoneda;
    public AudioSource sonidoBomba;

    public void sumarPuntos(int cantidad)
    {
        puntos += cantidad;
        textoPuntos.text = "Puntos: " + puntos;
        
        if (sonidoMoneda != null) sonidoMoneda.Play();

        if (puntos >= 120)
        {
            ganarJuego();
        }
    }

    public void perderVida(int cantidad)
    {
        vidas -= cantidad;
        
        if (sonidoBomba != null) sonidoBomba.Play();

        if (vidas <= 0)
        {
            vidas = 0;
            textoVidas.text = "Vidas: " + vidas;
            panelGameOver.SetActive(true);
            Time.timeScale = 0f; 
        }
        else
        {
            textoVidas.text = "Vidas: " + vidas;
        }
    }

    void ganarJuego()
    {
        panelVictoria.SetActive(true);
        Time.timeScale = 0f; 
        Debug.Log("¡Has ganado!");
    }

    public void IrAlInicio() 
    {
        Time.timeScale = 1f; 
        UnityEngine.SceneManagement.SceneManager.LoadScene("Inicio");
    }
}