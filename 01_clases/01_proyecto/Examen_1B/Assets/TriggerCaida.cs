using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCaida : MonoBehaviour
{
    public PlataformaCaida platform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            platform.StartFalling();
        }
    }
}