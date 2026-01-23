using UnityEngine;

public class EnemigoPerseguir : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 3f;
    private Rigidbody2D rb;
    public GameManager migameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(objetivo != null)
        {
            Vector2 direccion = (Vector2)objetivo.position - (Vector2)transform.position;
            direccion = direccion.normalized;
            rb.MovePosition(rb.position + (direccion * velocidad * Time.deltaTime));
        }       
    }

    void OnCollisionEnter2D(Collision2D objetoTocado)
    {
        // CORRECCIÓN: Se accede a gameObject y luego al método .CompareTag()
        if (objetoTocado.gameObject.CompareTag("jugador1"))
        {
            if (migameManager != null) 
            {
                migameManager.perderVida(5);
            }
        }
    }
}