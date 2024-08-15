using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    public Transform startPoint; // Asigna esto en el Inspector
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Usar la posición del objeto StartPoint como la posición inicial
        if (startPoint != null)
        {
            startPosition = startPoint.position;
        }
        else
        {
            // Si no se asignó StartPoint, usar la posición actual
            startPosition = transform.position;
        }

        // Imprimir la posición inicial en la consola
        Debug.Log("Posición inicial guardada: " + startPosition);
    }


    void Update()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Verificar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Opcional: Dibuja un círculo en la posición de "groundCheck" en el editor
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            // Si el personaje colisiona con un "Hazard", regresa al punto de inicio
            transform.position = startPosition;
            Debug.Log("Personaje ha colisionado con Hazard y regresado al punto inicial.");
        }
    }
}
