using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementDistanse;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private bool moving;
    private float upEdge;
    private float downEdge;

    private void Awake()
    {
        upEdge = transform.position.y - movementDistanse;
        downEdge = transform.position.y + movementDistanse;
    }
    private void Update()
    {
        if (moving)
        {
            if (transform.position.y > upEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
                moving = false;
        }
        else
        {
            if (transform.position.y < downEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
                moving = true;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
