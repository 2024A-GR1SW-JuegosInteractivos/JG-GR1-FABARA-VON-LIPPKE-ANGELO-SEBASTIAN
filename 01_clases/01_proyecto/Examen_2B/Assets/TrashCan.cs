using UnityEngine;
using UnityEngine.UI; // Necesario para usar UI

public class TrashCan : MonoBehaviour
{
    public int totalTrash = 5; // Define el número total de basura en la escena
    public Text messageText; // UI Text para mostrar mensajes al jugador

    private PlayerController playerController;
    private int trashCollected = 0;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        messageText.text = ""; // Inicialmente el mensaje está vacío
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject collectedTrash = playerController.GetCurrentTrash();
            if (collectedTrash != null)
            {
                trashCollected++;
                playerController.DropTrash();
                Debug.Log("Basura depositada en el basurero. Total depositada: " + trashCollected);

                if (trashCollected == totalTrash)
                {
                    messageText.text = "¡Bien hecho! Has recogido toda la basura.";
                    Debug.Log("¡Toda la basura ha sido recogida y depositada en el basurero!");
                }
            }
            else
            {
                Debug.Log("No tienes basura para depositar.");
            }
        }
    }
}
