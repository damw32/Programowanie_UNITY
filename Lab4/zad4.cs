using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad4 : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 200f;
    float Rotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseXMove);

        Rotation += mouseYMove;
        Rotation = Mathf.Clamp(Rotation, -90f, 90f);

        //transform.Rotate(new Vector3(-Rotation, 0f, 0f), Space.Self);
        transform.localRotation = Quaternion.Euler(-Rotation, 0f, 0f);
    }
}