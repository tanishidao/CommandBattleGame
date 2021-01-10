using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParamManager : MonoBehaviour
{
    public CharacterParam CharacterParam = new CharacterParam();

    public CharacterParam GetCharacterParam
    {
        get { return CharacterParam; }
    }
    //本来サーバーあkら送られるが、今回は各キャラごとに設定
    public int CharacterHP = 0;
    public int CharacterMP = 0;
    public float CharacterSpeed = 0;
    public CharacterParam.GameCharacterType CharacterType = CharacterParam.GameCharacterType.invalide;

    private void Init()
        {
        CharacterParam.HitPoint = CharacterHP;
        CharacterParam.MagicPoint = CharacterMP;
        CharacterParam.Speed = CharacterSpeed;
        CharacterParam.CharacterType = CharacterType;
        }
private void Awake()
{
    Init();
}
        

         
}
