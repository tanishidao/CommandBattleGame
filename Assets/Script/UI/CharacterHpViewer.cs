using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterHpViewer : MonoBehaviour
{
    public int[] CharacterHps = new int[3];
    public int[] CharacterMaxHps = new int[3];
    public TextMeshProUGUI[] CharacterHPTexts = new TextMeshProUGUI[3];
    public void SetHP(int characterPos, int hp)//いんとでHP管理
    {
        CharacterHps[characterPos] = hp;
    }
   public void SetMaxHp(int characterPos, int maxHp)
    {
        CharacterMaxHps[characterPos] = maxHp;
    }
    public void HpTextUPDate()
    {
        for(int i =0; i < 3; i++ )
        {
            CharacterHPTexts[i].text = $"{CharacterHps[i]}/{CharacterMaxHps[i]}";
        }
    }
   //Updateで
    private void LateUpdate()
    {
        HpTextUPDate();
    }
}
