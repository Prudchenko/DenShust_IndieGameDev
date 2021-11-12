using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    int[] check_ids;
    public GameObject[] slots;
    public Text scoreText;
    public int score = 100;
    bool passed ;
    bool isRed;
    public GameObject spawner;
    public SpriteRenderer shop;
    public Sprite open, close;
    void Start()
    {
        
    }

    void Update()
    {
        int counter = 0;
        for (int i = 0; i < 4; i++)
        {
            if (slots[i].transform.childCount > 0)
            {
                counter++;
            }
          
        }
        if(counter==4)
            spawner.SetActive(true);
    }

    void Check(GameObject creature)
    {
        
        for (int i = 0; i < 4; i++)
        {
            if(slots[i].transform.childCount>0)
            {
                int[] ids = slots[i].transform.GetChild(0).GetComponent<Draggable_2>().partID;
                if (check_ids[ids[0]] == ids[1]) 
                {
                    passed = false;
                }
            }
        }
    }

    void ChangeScore(int value)
    {
        score += value;
        if (score < 0)
            score =0;
        scoreText.text = score.ToString();
    }
    IEnumerator OpenDoor()
    {
        shop.sprite = open;
        yield return new WaitForSeconds(0.5f);
        shop.sprite = close;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Creature"))
        {
            isRed = false;
            passed = true;
            check_ids = collision.GetComponent<Creature>().ids;
            Check(collision.gameObject);
            
            if (check_ids[4] == 0)
            {
                isRed = true;
            }
          
            if (passed)
            {
                if (isRed)
                {
                    ChangeScore(-5);
                    Debug.Log("Red  Passed");
                }
                else
                {
                    ChangeScore(1);
                    Debug.Log("Green  Passed");
                }
                StartCoroutine(OpenDoor());
                Destroy(collision.gameObject);
            }
            else if(!passed)
            {
                if (isRed)
                {
                    Debug.Log("Red  Kicked");
                    ChangeScore(0);
                }
                else
                {
                    Debug.Log("Green  Kicked");
                    ChangeScore(-1);
                }
                collision.GetComponent<Animator>().Play("die", -1, 0f);
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(7, 5), ForceMode2D.Impulse);
                Destroy(collision.gameObject,3f);
            }
            
        }
    }
}
