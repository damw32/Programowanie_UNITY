using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad6 : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Contact")
        {
            Debug.Log("Doszło do kontaktu");
        }
    }
}
