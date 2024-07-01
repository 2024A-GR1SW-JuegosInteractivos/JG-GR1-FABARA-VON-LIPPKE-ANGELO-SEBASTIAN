using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaEnMovimiento : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    private Vector3 startPosition;
    private bool move = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void StartMoving()
    {
        move = true;
    }
}
