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
        foreach (GameObject piece in pieces)
        {
            int id = Random.Range(1, 5);
            ids[i] = id-1;
            i++;
            piece.GetComponent<Animator>().Play(piece.name + id.ToString(),-1,0f);
        }
        GetComponent<Animator>().Play("standart", -1, 0f);
        foreach (GameObject piece in pieces)
        {
            if (piece.name != "face")
                piece.GetComponent<SpriteRenderer>().color = color;
        }
        ids[i] = colorId;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime*2f, transform.position.y);
    }
}
