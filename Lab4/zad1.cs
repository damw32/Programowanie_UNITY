using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int Ileobiektow = 10;
    int objectCounter = 5;
    public Material[] materials = new Material[5];
    public GameObject block;

    void Start()
    {        
        MeshCollider mesh = GetComponent<MeshCollider>();
        float pozx = mesh.bounds.center.x - mesh.bounds.extents.x;
        float pozy = mesh.bounds.center.z - mesh.bounds.extents.z;

        List<int> pozycje_x = new List<int>(Enumerable.Range((int)pozx, (int)mesh.bounds.size.x).OrderBy(x => Guid.NewGuid()).Take(Ileobiektow));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)pozy, (int)mesh.bounds.size.z).OrderBy(x => Guid.NewGuid()).Take(Ileobiektow));

        for (int i = 0; i < Ileobiektow; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 10, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("coroutine start");
        foreach (Vector3 pos in positions)
        {
            GameObject objec = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            objec.GetComponent<MeshRenderer>().material = this.materials[UnityEngine.Random.Range(0, this.materials.Length)];
            yield return new WaitForSeconds(this.delay);
        }
        StopCoroutine(GenerujObiekt());
    }
}