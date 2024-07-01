using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform respawnPoint;
    public Text deathCounterText;
    public GameObject winMessage; // Panel o texto de ganaste

    private Rigidbody2D rb;
    private bool isGrounded;
    private int deathCount = 0;
    private float originalSpeed;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;
    private bool controlsInverted = false;
    private GameObject[] platforms;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        originalSpeed = speed;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
        platforms = GameObject.FindGameObjectsWithTag("Platform"); // Encuentra todas las plataformas etiquetadas
        UpdateDeathCounterUI();
        winMessage.SetActive(false); // Asegúrate de que el mensaje de ganaste esté oculto al inicio
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (controlsInverted)
        {
            move = -move;
        }
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("DeathZone"))
        {
            ResetGame();
        }
        else if (collision.gameObject.CompareTag("WinZone"))
        {
            WinGame();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position;
        deathCount++;
        UpdateDeathCounterUI();
    }

    private void UpdateDeathCounterUI()
    {
        if (deathCounterText != null)
        {
            deathCounterText.text = "Deaths: " + deathCount;
        }
    }

    public void ChangeSpeed(float multiplier, float duration)
    {
        speed *= multiplier;
        Invoke("ResetSpeed", duration);
    }

    private void ResetSpeed()
    {
        speed = originalSpeed;
    }

    public void ResetGame()
    {
        // Resetea la posición y configuración del jugador
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        transform.localScale = initialScale;
        speed = originalSpeed;
        deathCount = 0;
        controlsInverted = false;
        UpdateDeathCounterUI();

        // Resetea las plataformas
        foreach (var platform in platforms)
        {
            platform.GetComponent<ReseteoDePlataforma>().ResetPlatform();
        }
    }

    public void InvertMovement()
    {
        controlsInverted = !controlsInverted;
    }

    private void WinGame()
    {
        winMessage.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
    }
}
