using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterUIViewer : MonoBehaviour
{
    public Button[] CharacterActionButtons = new Button[4];//ボタン四つありますよ～
    public bool CenterUIVisible = false;

    public bool CheckCenterUIVisible(float gaugeRate)
    {
        return gaugeRate >= 1f;//1以上になるまで繰り返す
    }
    public void SetCenterUIVisible(bool active)
    {
        this.gameObject.SetActive(active);//
    }

    public void SetCharacterActionButtons(CharacterParam characterParam)
    { for (int i = 0; i < CharacterActionButtons.Length; i++)
        {
            CharacterActionButtons[i].onClick.RemoveAllListeners();//聞く人、支持きいて、行動するremoveで外出す
        }
        CharacterActionButtons[0].onClick.AddListener
           (() =>characterParam.FirstButtonAction()); //ラムダ式、（無記名関数）=>は矢印プロはよく使う
    CharacterActionButtons[1].onClick.AddListener(() => characterParam.SecondButtonAction());
    CharacterActionButtons[2].onClick.AddListener(() => characterParam.ThirdButtonAction());
    CharacterActionButtons[3].onClick.AddListener(() => characterParam.FourthButtonAction());

    }
      
}
