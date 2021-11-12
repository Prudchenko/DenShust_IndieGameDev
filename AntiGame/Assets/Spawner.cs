using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject creaturePref;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        Instantiate(creaturePref, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4);
        StartCoroutine(Spawn());
    }
}
