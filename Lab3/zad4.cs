using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad4 : MonoBehaviour
{
    
    public GameObject myPrefab;

    void Start()
    {
        List<int> listaX = new List<int>();
        List<int> listaZ = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            int x = Random.Range(1, 10);
            int z = Random.Range(1, 10);
            if (listaX.Count == 0)
            {
                Instantiate(myPrefab, new Vector3(x, 0, z), Quaternion.identity);
                listaX.Add(x);
                listaZ.Add(z);
            }
            else
            {
                if (czyPowtorka(x, z, listaX, listaZ) == true)
                {
                    i--;
                }
                else
                {
                    Instantiate(myPrefab, new Vector3(x, 0, z), Quaternion.identity);
                    listaX.Add(x);
                    listaZ.Add(z);
                }
            }
        }
    }
    bool czyPowtorka(int x, int z, List<int> listaX, List<int> listaZ)
    {
        bool czypowt = false;
        for (int j = 0; j < listaX.Count; j++)
        {
            if (listaX[j] == x && listaZ[j] == z)
            {
                czypowt = true;
            }
        }
        return czypowt;
    }
}
