using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitGaugeViewer : MonoBehaviour
{
    public Image[] CharacterGaugeImages = new Image[3];
    public float[] CharacterSpeeds = new float[3];

    public void Init()
    {
        for (int i = 0; i < 3; i++)
        {
            CharacterGaugeImages[i].fillAmount = 0;
        }

    }
    public void WaitGaugeUpDate()
    {
        for(int i = 0; i < 3; i++)
        {
            CharacterGaugeImages[i].fillAmount += CharacterSpeeds[i] / 10000f;
        }
    }
    //Update
    private void LateUpdate()
    {
        WaitGaugeUpDate();
    }
}
