using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public GameObject[] pieces;
    public int[] ids;

    Color[] colors = new Color[] { new Color(1,0.3f,0.3f), new Color(0.3f,1,0.3f), new Color(0.3f, 0.3f,1) };
    void Start()
    {
        SetAppearence();
       
    }
    void SetAppearence()
    {
        int colorId = Random.Range(0, 3);
        Color color = colors[colorId];
        GetComponent<SpriteRenderer>().color = color;
        int i = 0;
        ids[i] = colorId;
        foreach (GameObject piece in pieces)
        {
            if(piece.name!="face")
            piece.GetComponent<SpriteRenderer>().color = color;
            int id = Random.Range(1, 5);
            i++;
            ids[i] = id;
            piece.GetComponent<Animator>().Play(piece.name + id.ToString());
        }
       
    }
    void Update()
    {
        
    }
}
