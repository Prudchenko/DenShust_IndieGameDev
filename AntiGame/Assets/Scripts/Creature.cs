using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public GameObject[] pieces;
    void Start()
    {
        // StartCoroutine(Set());
        SetAppearence();
    }
    void SetAppearence()
    {
        Color color = Random.ColorHSV(0f,1f,1f,1f,1f,1f,1f,1f);
        GetComponent<SpriteRenderer>().color = color;
        foreach (GameObject piece in pieces)
        {
            if(piece.name!="face")
            piece.GetComponent<SpriteRenderer>().color = color;
            int r = Random.Range(1, 5);
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
