using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    public float maxOtwarcie = 20f;
    public float maxZamkniecie = 0f;
    public float szybkosc = 1f;
    bool czyGraczJestBlisko;
    void Start()
    {
        czyGraczJestBlisko = false;
    }
    void FixedUpdate()
    {
        if (czyGraczJestBlisko)
        {
            if (transform.position.x < maxOtwarcie)
            {
                transform.Translate(szybkosc * Time.deltaTime, 0f, 0f);
            }
            if (transform.position.x >= maxOtwarcie)
            {
                czyGraczJestBlisko = false;
            }
        }
        else
        {
            if (transform.position.x > maxZamkniecie)
            {
                transform.Translate(-szybkosc * Time.deltaTime, 0f, 0f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            czyGraczJestBlisko = true;
        }
    }
}
