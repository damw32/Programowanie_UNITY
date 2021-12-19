using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    private bool isRunningBack = false;
    private int indexPosition = 0;
    private Vector3 StartPosition;
    public List<Vector3> EndPositions;

    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {


        if (isRunning)
        {
            float step = elevatorSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, EndPositions[indexPosition], step);
            if (transform.position == EndPositions[indexPosition])
            {
                if (indexPosition == EndPositions.Count - 1)
                {
                    isRunning = false;
                    isRunningBack = true;
                }
                else
                {
                    indexPosition++;
                }

            }
        }
        if (isRunningBack)
        {
            float step = elevatorSpeed * Time.deltaTime;
            if (indexPosition > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, EndPositions[indexPosition], step);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, StartPosition, step);
            }

            if (transform.position == EndPositions[indexPosition])
            {
                indexPosition--;
            }
            if (transform.position == StartPosition)
            {
                isRunningBack = false;
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position == StartPosition)
            {
                isRunning = true;
            }
        }
    }
}
