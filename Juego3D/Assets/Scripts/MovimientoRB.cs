using UnityEngine;

public class MovimientoRB : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float velocidadCaminar = 7f;
    public float velocidadCorrer = 12f;
    public float aceleracion = 10f;
    public float fuerzaSalto = 10f;
    public float sensibilidad = 2f;

    [Header("Referencias")]
    public Camera camaraJugador;

    private Rigidbody rb;
    private float rotacionX = 0f;
    private bool estaEnSuelo;
    private float velocidadActualTarget;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.freezeRotation = true; 
        rb.interpolation = RigidbodyInterpolation.Interpolate; 
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; 
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);
        
        if (camaraJugador != null)
            camaraJugador.transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKey(KeyCode.LeftShift) && estaEnSuelo)
        {
            velocidadActualTarget = velocidadCorrer;
        }
        else
        {
            velocidadActualTarget = velocidadCaminar;
        }

        if (Input.GetButtonDown("Jump") && estaEnSuelo)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); 
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            estaEnSuelo = false;
        }
    }

    void FixedUpdate()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movZ = Input.GetAxisRaw("Vertical");

        Vector3 direccion = (transform.right * movX + transform.forward * movZ).normalized;
        Vector3 velocidadObjetivo = direccion * velocidadActualTarget;

        Vector3 velActualHorizontal = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Vector3 fuerzaMov = (velocidadObjetivo - velActualHorizontal) * aceleracion;

        rb.AddForce(fuerzaMov, ForceMode.Acceleration);
    }

    void OnCollisionStay(Collision col)
    {
        foreach (ContactPoint contacto in col.contacts)
        {
            if (contacto.normal.y > 0.6f) 
            {
                estaEnSuelo = true;
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        estaEnSuelo = false;
    }
}