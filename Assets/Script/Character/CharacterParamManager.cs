﻿using System.Collections;
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

    public int CharacterAttack = 0;

    public int ButtonNo = 0;
    

    public float CharacterSpeed = 0;
    public CharacterParam.GameCharacterType CharacterType = CharacterParam.GameCharacterType.invalide;
    public CharacterAnimatonController CharacterAnimationController = null;

    public bool IsEnemy = false ;

    private float attackSpan;
 
    private void Init()
    {
        CharacterParam.HitPoint = CharacterHP;
        CharacterParam.MagicPoint = CharacterMP;
        CharacterParam.Speed = CharacterSpeed;
        CharacterParam.CharacterType = CharacterType;

        CharacterParam.Attack = CharacterAttack;

        
        if(!IsEnemy)
        {
            CharacterParam.IsEnemy = IsEnemy;
            CharacterParam.FirstButtonAction = FirstButtonAction;
            CharacterParam.SecondButtonAction = SecondButtonAction;
            CharacterParam.ThirdButtonAction = ThirdButtonAction;
            CharacterParam.FourthButtonAction = FourthButtonAction;
        }
        else
        {
            attackSpan = 10f;
        }
        
        CharacterAnimationController = GetComponent<CharacterAnimatonController>();

       
    }
    private void Update()
    {
        if(IsEnemy)
        {
            attackSpan -= Time.deltaTime;
            if(attackSpan < 0)
            {
                StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));
                attackSpan = 10f;
            }
        }
    }





    private void Awake()
    {
        Init();
    }
    
    private void FirstButtonAction()
    {
        
        if (IsEnemy)
        {
            return;
        }
        
      else  
        {
           
            
                Debug.Log("aaaaaaa");
                StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));
                ButtonNo += 0;
           /// Damage();

        }

    }
    private void SecondButtonAction()
    {
        ButtonNo += 1;
        if (IsEnemy)
        {
            return;
        }

       else 
        {
            if (CharacterType == CharacterParam.GameCharacterType.SpellCaster)
            {
                Debug.Log("bbbb");
                StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));
            }

            
            
                
        }






    }
    private void ThirdButtonAction()
    {
        ButtonNo += 3;
        if (IsEnemy)
        {
            return;
        }

        else
        {



            StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));
            Debug.Log("cc");
        }
    }
    private void FourthButtonAction()
    {
        Debug.Log("dd");
    }

    public CharacterHpViewer CharacterHpViewer = null;
    public void Damage(int damage)
    {
        var characterPos = CharacterParam.CharacterPos;

        CharacterParam.HitPoint -= damage;
        CharacterParam.HitPoint = CharacterHP;

        if (!IsEnemy)
        {
            if(damage < -1 && CharacterHpViewer.CharacterMaxHps[characterPos] < CharacterHP)
            {
                CharacterHP = CharacterHpViewer.CharacterMaxHps[characterPos];
                CharacterParam.HitPoint = CharacterHP;
            }
            CharacterHpViewer.SetHP(characterPos, CharacterHP);
        }
        Debug.Log("Hit");
    }


}
