using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParam
{
   
    
   public enum GameCharacterType
    {
        invalide,
        Attacker,
        SpellCaster,
        Healer,
    }
    public int HitPoint;
    public int MagicPoint;

    public int Attack;

    public float Speed;
    public GameCharacterType CharacterType;

    public Action FirstButtonAction;//各ボタンの命名、宣言
    public Action SecondButtonAction;
    public Action ThirdButtonAction;
    public Action FourthButtonAction;

    public bool IsEnemy;
    public int CharacterPos;
}
