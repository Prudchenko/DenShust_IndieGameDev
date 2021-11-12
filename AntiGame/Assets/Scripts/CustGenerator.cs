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
}
