using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustGenerator : MonoBehaviour
{
    [SerializeField]
    private AnimationClip[] FacesArray;
    [SerializeField]
    public AnimationClip[] HandsArray;
    [SerializeField]
    private AnimationClip[] LegsArray;
    [SerializeField]
    private AnimationClip[] HeadsArray;
    Color[] colors =  new Color[] { Color.red, Color.green, Color.blue };
    Color blue = Color.blue;
    Color green = Color.red;

    public void SetAppearence(Customer customer)
    {
        Color color = colors[Random.Range(0,3)];
        GetComponent<SpriteRenderer>().color = color;
        for(int i = 0; i<FacesArray.Length;i++)
        {
            int r = Random.Range(0, FacesArray.Length);
            FacesArray[i].GetComponent<Animator>().Play(FacesArray[i].name + r.ToString());
        }

        for (int i = 0; i < HandsArray.Length; i++)
        {
            HandsArray[i].GetComponent<SpriteRenderer>().color = color;
            int r = Random.Range(0, HandsArray.Length);
            HandsArray[i].GetComponent<Animator>().Play(HandsArray[i].name + r.ToString());
        }

        for (int i = 0; i < LegsArray.Length; i++)
        {
            LegsArray[i].GetComponent<SpriteRenderer>().color = color;
            int r = Random.Range(0, LegsArray.Length);
            LegsArray[i].GetComponent<Animator>().Play(LegsArray[i].name + r.ToString());
        }

        for (int i = 0; i < HeadsArray.Length; i++)
        {
            HeadsArray[i].GetComponent<SpriteRenderer>().color = color;
            int r = Random.Range(0, HeadsArray.Length);
            HeadsArray[i].GetComponent<Animator>().Play(HeadsArray[i].name + r.ToString());
        }
    }
}
