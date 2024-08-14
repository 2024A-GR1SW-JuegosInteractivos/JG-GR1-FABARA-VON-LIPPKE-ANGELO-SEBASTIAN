using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject currentTrash = null; // Referencia a la basura recogida

    void Update()
    {
        // Movimiento del personaje
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash") && currentTrash == null)
        {
            currentTrash = collision.gameObject;
            currentTrash.SetActive(false); // Desactivar la basura recogida
            Debug.Log("Basura recogida: " + currentTrash.name);
        }
    }

    public GameObject GetCurrentTrash()
    {
        return currentTrash;
    }

    public void DropTrash()
    {
        currentTrash = null;
    }
}
