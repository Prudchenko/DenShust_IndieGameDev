using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public GameObject[] pieces;
    void Start()
    {
        StartCoroutine(Set());
    }
    void SetAppearence()
    {
        foreach (GameObject piece in pieces)
        {
            int r = Random.Range(1, 5);
            piece.GetComponent<Animator>().enabled = false;
            piece.GetComponent<Animator>().enabled = true;
            piece.GetComponent<Animator>().Play(piece.name + r.ToString());
        }
    }

    IEnumerator Set()
    {
       
        SetAppearence();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Set());
    }
    void Update()
    {
        
    }
}
