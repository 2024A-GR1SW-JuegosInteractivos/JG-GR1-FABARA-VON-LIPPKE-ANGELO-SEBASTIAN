using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpeed : MonoBehaviour
{
    
    public float speedMultiplier = 2f;
    public float duration = 5f;
    private bool hasBeenActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Personaje player = collision.GetComponent<Personaje>();
            if (player != null)
            {
                player.ChangeSpeed(speedMultiplier, duration);
                hasBeenActivated = true;
            }
        }
    }
}
