using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    private float downPosition;
    private float upPosition;
    Transform oldParent;
    void Start()
    {
        upPosition = transform.position.z + distance;
        downPosition = transform.position.z;
    }

    void FixedUpdate()
    {
        if (isRunningUp && transform.position.z >= upPosition)
        {
            isRunning = false;
        }
        else if (isRunningDown && transform.position.z <= downPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
        if (transform.position.z >= upPosition)
        {
            isRunningDown = true;
            isRunningUp = false;
            elevatorSpeed = -elevatorSpeed;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;
            if (transform.position.z <= downPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }
}
