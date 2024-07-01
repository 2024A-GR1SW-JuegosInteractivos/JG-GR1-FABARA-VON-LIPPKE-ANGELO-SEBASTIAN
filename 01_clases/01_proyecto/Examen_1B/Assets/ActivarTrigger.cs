using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public PlataformaEnMovimiento platform;
    private bool hasBeenActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            platform.StartMoving();
            hasBeenActivated = true;
        }
    }
}
