using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitGaugeViewer : MonoBehaviour
{
    public Image[] CharacterGaugeImages = new Image[3];
    public float[] CharacterSpeeds = new float[3];
<<<<<<< HEAD
    private bool gaugeStop = false;
         
=======
    public float[] WaitGaugePoints = new float[3];
>>>>>>> d0be461ec3ff5820fdd105405bdc019530c14ee5
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
            if(CharacterGaugeImages[i].fillAmount >= 1)
            {
                gaugeStop = true;
            }
            if(gaugeStop)
            {
                return;
            }
            
            CharacterGaugeImages[i].fillAmount += CharacterSpeeds[i] / 10000f;
        }
    }

<<<<<<< HEAD
    public void ResetWaitGaugeRate(int characterPos)
    {
        CharacterGaugeImages[characterPos].fillAmount= 0;
        gaugeStop = false;
    }

    public float GetWaitGaugeRate(int waitGaugeCharacter)
    {
        return CharacterGaugeImages[waitGaugeCharacter].fillAmount;
    }
        //Update
        private void LateUpdate()
=======
    public void GetWaitGaugeRate()
    {
        for (int i = 0; i < 3; i++)
        {
            return;
        }

    }
    //Update
    private void LateUpdate()
>>>>>>> d0be461ec3ff5820fdd105405bdc019530c14ee5
    {
        WaitGaugeUpDate();
    }
}
