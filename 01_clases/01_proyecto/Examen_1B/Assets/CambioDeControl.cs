using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeControl : MonoBehaviour
{
    private bool hasBeenActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasBeenActivated && collision.CompareTag("Player"))
        {
            Personaje player = collision.GetComponent<Personaje>();
            if (player != null)
            {
                player.InvertMovement();
                hasBeenActivated = true;
            }
        }
    }
}
