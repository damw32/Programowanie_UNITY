using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    [SerializeField] float speed = 1;
    float x = 0;
    float z = 0;

    void Update()
    {
        x = transform.position.x;
        z = transform.position.z;

        if (x >= 10 && z <= 0)
        {
            transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }
        if (x >= 10 && z >= 10)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (x <= 0 && z >= 10)
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        if (x <= 0 && z <= 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        transform.Translate(Time.deltaTime * speed, 0, 0);
    }
}
