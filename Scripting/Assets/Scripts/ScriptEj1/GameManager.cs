using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //VARIABLES ESTATICAS (Compartidas por los scripts)
    public int puntos = 0;
    public int vidas = 3;
    //Referencias a los textos de la UI
    public Text textoPuntos;
    public Text textoVidas;
    public GameObject panelGameOver;

    public void sumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Debug.Log(puntos);
        textoPuntos.text = "Puntos: " + puntos;
    }

    public void perderVida(int cantidad)
{
    vidas -= cantidad; // Restamos primero

    if (vidas <= 0)
    {
        vidas = 0; 
        textoVidas.text = "Vidas: " + vidas;
        panelGameOver.SetActive(true);
        Debug.Log("¡GAME OVER! Has muerto.");
        
    }
    else
    {
        Debug.Log("Te quedan " + vidas + " vidas.");
        textoVidas.text = "Vidas: " + vidas;
    }
}

    
}
