using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    [SerializeField] float speed = 1;
    float move = 1;
    void Update()
    {
        if (transform.position.x >= 10)
        {
            move = -1;
        }
        else if (transform.position.x <= 0)
        {
            move = 1;
        }
        transform.Translate(speed * Time.deltaTime * move, 0, 0);
    }
}
