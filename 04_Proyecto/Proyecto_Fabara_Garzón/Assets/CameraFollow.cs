using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float yOffset = 0f; // Desplazamiento vertical de la cámara

    void Update()
    {
        if (player != null)
        {
            // Seguir al jugador solo en el eje X
            transform.position = new Vector3(player.position.x, transform.position.y + yOffset, transform.position.z);
        }
    }
}
