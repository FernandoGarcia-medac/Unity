using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{   
    //Asigna esta funcion al evento OnClick() del boton
    public void EmpezarJuego()
    {
        //Cargamos la escena del juego
        SceneManager.LoadScene("Juego1");
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego..."); 
        Application.Quit(); 
    }

}
