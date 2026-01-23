using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour 
{

    public float velocidad = 5f;
    private Rigidbody2D rb;  

    private Vector2 movimiento;
    private Vector2 direccion;
    void Start()
    {
        //Obtengo el componente Rigidbody2D del jugador
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); //Detecta si se presionan las teclas movimiento horizontal
        float y = Input.GetAxisRaw("Vertical");  //Detecta si se presionan las teclas movimiento vertical

        //Creamos el vector de direccion
        direccion = new Vector2(x, y);

        //Normalizar: si nos movemos en diagonal, la longitud es 1.41 (hipotenusa)
        // .nomalized recorta el vector a 1 para no correr mas rapido en diagonal
        if (direccion.magnitude > 1)
        {
            direccion = direccion.normalized;
        }
    }

    //FixedUpdate se usa para fisicas
    void FixedUpdate()
    {
        //Calculamos cuanto movernos: Direccion * Velocidad * Tiempo
        Vector2 desplazamiento = direccion * velocidad * Time.fixedDeltaTime;

        //Movemos el Rigidbody2D a la nueva posicion
        rb.MovePosition(rb.position + desplazamiento);
    }
}
