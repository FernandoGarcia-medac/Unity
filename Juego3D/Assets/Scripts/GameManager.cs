using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int puntos = 0;
    public int vidas = 3;

    public void sumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Debug.Log("Puntos: " + puntos);
    }

    public void perderVida(int cantidad)
    {
        vidas -= cantidad;
        if (vidas <= 0) Debug.Log("Game Over");
    }
}