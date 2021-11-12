using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject tilePrefab;
    public Sprite[] sprites;
    void Start()
    {
        SetTiles();
    }
    void SetTiles()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            GameObject tile = Instantiate(tilePrefab, slots[i].transform.position, Quaternion.identity);
            tile.GetComponent<SpriteRenderer>().sprite = sprites[i];
            tile.transform.parent = slots[i].transform;
            tile.GetComponent<Draggable_2>().partID[0] = Mathf.FloorToInt(i / 4);
            tile.GetComponent<Draggable_2>().partID[1] = i%4;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
